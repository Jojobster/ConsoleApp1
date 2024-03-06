using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] sequence = { 43, 47, 87 };

        double productOfLastDigits = CalculateProductOfLastDigits(sequence);

        Console.WriteLine($"Твір останніх цифр: {productOfLastDigits}");
    }

    static double CalculateProductOfLastDigits(int[] sequence)
    {
        return sequence.Aggregate(1.0, (product, number) =>
        {
            int lastDigit = Math.Abs(number % 10);

            return product * lastDigit;
        });
    }
}

