using System;

class Program
{
    static void Main()
    {
        int[] numbers = { -7, 1, -38, 8, 11, -20, 17 };

        Console.WriteLine("Початковий масив:");
        PrintArray(numbers);

        RearrangeArray(numbers);

        Console.WriteLine("\nМасив після перестановки:");
        PrintArray(numbers);
    }

    static void RearrangeArray(int[] arr)
    {
        int n = arr.Length;
        int positiveIndex = 0;

        for (int i = 0; i < n; i++)
        {
            if (arr[i] < 0)
            {
                while (positiveIndex < n && arr[positiveIndex] < 0)
                {
                    positiveIndex++;
                }
                if (positiveIndex < n)
                {
                    int temp = arr[i];
                    arr[i] = arr[positiveIndex];
                    arr[positiveIndex] = temp;
                    positiveIndex++;
                }
            }
        }
    }

    static void PrintArray(int[] arr)
    {
        foreach (var num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
