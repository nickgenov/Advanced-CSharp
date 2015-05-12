using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LargerThanNeighbours
{
    static void Main()
    {
        string[] input = Console.ReadLine().Trim().Split(' ');
        int[] numbers = new int[input.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(input[i]);
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(IsLargerThanNeighbours(numbers, i));
        }
    }
    public static string IsLargerThanNeighbours(int[] numbers, int index)
    {
        int num = numbers[index];
        //check left
        bool largerThanLeft = false;
        if (index > 0)
        {
            if (num > numbers[index - 1])
            {
                largerThanLeft = true;
            }           
        }
        else
        {
            largerThanLeft = true;
        }
        //check right
        bool largerThanRight = false;
        if (index < numbers.Length - 1)
        {
            if (num > numbers[index + 1])
            {
                largerThanRight = true;
            }
        }
        else
        {
            largerThanRight = true;
        }

        //return result
        bool result = largerThanLeft && largerThanRight;
        if (result)
        {
            return "True";
        }
        else
        {
            return "False";
        }      
    }
}