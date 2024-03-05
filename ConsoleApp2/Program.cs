using System;
using System.Collections.Generic;
using System.Linq;
int ElementsNumber, ConnectionsNumber, OPVertsNumber = -1;
List<int>[] ConnectionList, ConnectionListCopy;
string Answer = "";
Console.Write("Введiть кiлькiсть вершин: ");
ElementsNumber = int.Parse(Console.ReadLine());
Console.Write("Введiть кiльксть з'єднань: ");
ConnectionsNumber = int.Parse(Console.ReadLine());
ConnectionList = new List<int>[ElementsNumber];

ConnectionListCopy = new List<int>[ElementsNumber];
for (int i = 0; i < ElementsNumber; i++)
{
    ConnectionList[i] = new List<int>();
    ConnectionListCopy[i] = new List<int>();
}
for (int i = 0; i < ConnectionsNumber; i++)
{
    Console.WriteLine("Уточнюємо деталi для " + (i + 1) + "-го з'єднання.");
    Console.Write("Вкажiть вершину початку з'єднання: ");
    int u = int.Parse(Console.ReadLine()) - 1;
    Console.Write("Вкажiть вершину кiнця з'єднання: ");
    int v = int.Parse(Console.ReadLine()) - 1;
    ConnectionList[v].Add(u);
    ConnectionList[u].Add(v);
    ConnectionListCopy[v].Add(u);
    ConnectionListCopy[u].Add(v);
}
switch (isEiler())
{
    case 0:
        Console.WriteLine();
        Console.WriteLine("У цього графа нема нi цикла, нi ланцюга Ейлера.");
        break;
    case 1:
        EilerPath(OPVertsNumber);
        Console.WriteLine();
        Console.WriteLine("У цього графа є ланцюг Ейлера (маршрут):");
        Console.WriteLine(Answer);
        break;
    case 2:

        EilerPath(0);
        Console.WriteLine();
        Console.WriteLine("У цього графа є Ейлеровий цикл:");
        Console.WriteLine(Answer);
        break;
}
int[] hampatharr = HamiltonivPath();
for (int j = 0; j < hampatharr.Length; j++)
    Console.Write(hampatharr[j] + 1 + " ");
Console.WriteLine();
int isEiler()
{
    int count = 0;
    int currentcount;
    for (int i = 0; i < ElementsNumber; i++)
    {
        currentcount = 0;
        foreach (int ver in ConnectionList[i])
            currentcount++;
        if (currentcount % 2 == 1)
            count++; OPVertsNumber = i;
    }
    if (count == 2)
        return 1;
    if (count == 0)
        return 2;
    return 0;
}
void EilerPath(int ver)
{
    for (int i = 0; i < ConnectionListCopy[ver].Count; i++)

    {
        int p = ConnectionListCopy[ver][i];
        ConnectionListCopy[ver].Remove(p);
        ConnectionListCopy[p].Remove(ver);
        EilerPath(p);
    }
    Answer += (ver + 1) + " ";
}
int[] HamiltonivPath()
{
    Queue<int> q = new Queue<int>();
    for (int i = 0; i < ElementsNumber; i++)
        q.Enqueue(i);
    for (int k = 0; k < ElementsNumber * (ElementsNumber - 1); k++)
    {
        if (!Have(q, 0, 1))
        {
            int i = 2;
            while (!Have(q, 0, i) && !Have(q, 1, i + 1)) i++;
            q = Reverse(q, 1, i);
        }
        q.Enqueue(q.Dequeue());
    }
    int count = 0;
    for (int i = 0; i < ElementsNumber; i++)
        if (Have(q, i, (i + 1) % ElementsNumber)) count++;
    Console.WriteLine();
    if (count == ElementsNumber)
        Console.WriteLine("У цього графа є гамiльтонiв цикл: ");
    else if (count < ElementsNumber - 1)
    {

        Console.WriteLine("У цього графа нема гамiльтонова цикла.");
        q.Clear();
    }
    else
    {
        Console.WriteLine("У цього графа є гамiльтонiв маршрут:");
        for (int i = 0; i < ElementsNumber - 1; ++i)
        {
            if (!Have(q, i, i + 1))
                for (int j = 0; j <= i; ++j)
                    q.Enqueue(q.Dequeue());
        }
    }
    return q.ToArray();
}
bool Have(Queue<int> q, int a, int b)
{
    return ConnectionList[q.ElementAt(a)].Contains(q.ElementAt(b));
}
Queue<int> Reverse(Queue<int> q, int a, int b)
{
    int[] arr = q.ToArray();
    for (int i = 0; i < arr.Length; i++)
        q.Dequeue();
    for (int i = 0; 2 * i <= b - a; i++)
    {
        int x = arr[i + a];
        arr[i + a] = arr[b - i];
        arr[b - i] = x;
    }
    for (int i = 0; i < arr.Length; i++)

        q.Enqueue(arr[i]);
    return q;
}