using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class NumberCalculations
{
    static void Main()
    {
        double[] realNumbers = { 1323232.2322, 4.23, -324.232, 0, 132 };
        int[] integers = { 1, 2, 4, 5400, 32, 44, -3243 };

        Console.WriteLine(FindMin(realNumbers));
        Console.WriteLine(FindMin(integers));

        Console.WriteLine(FindMax(realNumbers));
        Console.WriteLine(FindMax(integers));

        Console.WriteLine(FindAvg(realNumbers));
        Console.WriteLine(FindAvg(integers));

        Console.WriteLine(FindSum(realNumbers));
        Console.WriteLine(FindSum(integers));

        Console.WriteLine(FindProduct(realNumbers));
        Console.WriteLine(FindProduct(integers));

    }
    public static double FindMin(double[] numbers)
    {
        double min = double.MaxValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }
        return min;
    }
    public static int FindMin(int[] numbers)
    {
        int min = int.MaxValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }
        return min;
    }

    public static double FindMax(double[] numbers)
    {
        double max = double.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        return max;
    }
    public static int FindMax(int[] numbers)
    {
        int max = int.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        return max;
    }

    public static double FindAvg(double[] numbers)
    {
        double sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        double average = sum / numbers.Length;
        return average;
    }
    public static double FindAvg(int[] numbers)
    {
        double sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        double average = sum / numbers.Length;
        return average;
    }

    public static double FindSum(double[] numbers)
    {
        double sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }
    public static int FindSum(int[] numbers)
    {
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }

    public static double FindProduct(double[] numbers)
    {
        double product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }
        return product;
    }
    public static int FindProduct(int[] numbers)
    {
        int product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }
        return product;
    }
}