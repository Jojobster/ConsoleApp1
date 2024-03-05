using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Приклад послідовності цілих чисел
        int[] sequence = { 43, 47, 87 };

        // Використовуємо метод Aggregate для знаходження твору останніх цифр
        double productOfLastDigits = CalculateProductOfLastDigits(sequence);

        Console.WriteLine($"Твір останніх цифр: {productOfLastDigits}");
    }

    static double CalculateProductOfLastDigits(int[] sequence)
    {
        // Використовуємо метод Aggregate для обчислення добутку останніх цифр
        return sequence.Aggregate(1.0, (product, number) =>
        {
            // Отримуємо останню цифру числа за допомогою % 10
            int lastDigit = Math.Abs(number % 10);

            // Множимо поточний добуток на останню цифру
            return product * lastDigit;
        });
    }
}

