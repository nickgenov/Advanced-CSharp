using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SubsetSums
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(' ');
        List<int> numbers = new List<int>();

        for (int i = 0; i < input.Length; i++)
        {
            int num = int.Parse(input[i]);
            if (numbers.Contains(num) == false)
            {
                numbers.Add(num);
            }
        }
        numbers.Sort();




        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }

        


    }
}