using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FirstLargerThanNeighbours
{
    static void Main()
    {
        int[] sequenceOne = { 1, 3, 4, 5, 1, 0, 5};
        int[] sequenceTwo = { 1, 2, 3, 4, 5, 6, 6 };
        int[] sequenceThree = { 1, 1, 1 };

        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceOne));
        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceTwo));
        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(sequenceThree));
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
    public static int GetIndexOfFirstElementLargerThanNeighbours(int[] sequence)
    {
        int result = 0;
        bool foundSolution = false;
        for (int i = 0; i < sequence.Length; i++)
        {
            int element = sequence[i];
            if (IsLargerThanNeighbours(sequence, i) == "True")
            {
                result = sequence[i];
                foundSolution = true;
                break;
            }
        }

        if (foundSolution)
        {
            return result;
        }
        else
        {
            return -1;
        }
    }
}