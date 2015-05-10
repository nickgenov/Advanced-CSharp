using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CategorizeNumbers
{
    static void Main()
    {
        //parse input
        string[] input = Console.ReadLine().Trim().Split(' ');
        double[] numbers = new double[input.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = double.Parse(input[i]);
        }

        List<int> integers = new List<int>();
        List<double> floatNums = new List<double>();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 1 > 0)
            {
                floatNums.Add(numbers[i]);
            }
            else
            {
                integers.Add((int)numbers[i]);
            }
        }

        integers.Sort();
        floatNums.Sort();

        double floatSum = 0;
        foreach (var item in floatNums)
        {
            floatSum += item;
        }
        double floatAverage = floatSum / floatNums.Count;
        double floatMin = floatNums[0];
        double floatMax = floatNums[floatNums.Count - 1];


        int intSum = 0;
        foreach (var item in integers)
        {
            intSum += item;
        }
        double intAverage = intSum / (double)integers.Count;
        int intMin = integers[0];
        int intMax = integers[integers.Count - 1];

        for (int i = 0; i < integers.Count; i++)
        {
            if (i == 0)
            {
                Console.Write("[");
            }
            Console.Write(integers[i]);
            if (i < integers.Count - 1)
            {
                Console.Write(", ");
            }
            if (i == integers.Count - 1)
            {
                Console.WriteLine("] -> min: {0}, max: {1}, sum: {2}, avg: {3:F2}", intMin, intMax, intSum, intAverage);
            }
        }

        for (int i = 0; i < floatNums.Count; i++)
        {
            if (i == 0)
            {
                Console.Write("[");
            }
            Console.Write(floatNums[i]);
            if (i < floatNums.Count - 1)
            {
                Console.Write(", ");
            }
            if (i == floatNums.Count - 1)
            {
                Console.WriteLine("] -> min: {0}, max: {1}, sum: {2}, avg: {3:F2}", floatMin, floatMax, floatSum, floatAverage);
            }
        }

    }
}