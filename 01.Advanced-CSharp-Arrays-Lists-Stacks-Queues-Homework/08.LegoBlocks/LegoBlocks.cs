using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class LegoBlocks
{
    static void Main()
    {
        //parse input
        int n = int.Parse(Console.ReadLine());

        List<List<int>> firstArray = new List<List<int>>();
        List<List<int>> secondArray = new List<List<int>>();

        string pattern = @"\s+";
        Regex regex = new Regex(pattern);

        //fill the two array lists
        for (int i = 0; i < n; i++)
        {
            string[] input = regex.Split(Console.ReadLine());
            List<int> row = new List<int>();
            for (int j = 0; j < input.Length; j++)
            {
                if (input[j] != string.Empty)
                {
                    row.Add(int.Parse(input[j]));
                }               
            }
            firstArray.Add(row);
        }

        for (int i = 0; i < n; i++)
        {
            string[] input = regex.Split(Console.ReadLine());
            List<int> row = new List<int>();
            for (int j = 0; j < input.Length; j++)
            {
                if (input[j] != string.Empty)
                {
                    row.Add(int.Parse(input[j]));
                }           
            }
            secondArray.Add(row);
        }

        //check for a solution
        bool validSolution = true;
        int cellCount = 0;
        int combinedLength = 
            firstArray[0].Count + secondArray[0].Count;

        for (int i = 0; i < n; i++)
        {
            int currentLength = 
                firstArray[i].Count + secondArray[i].Count;
            if (currentLength != combinedLength)
            {
                validSolution = false;
            }
            cellCount += currentLength;
        }

        //print the result
        if (validSolution)
        {
            for (int i = 0; i < n; i++)
            {
                List<int> firstPart = firstArray[i];
                List<int> secondPart = secondArray[i];
                secondPart.Reverse();
                firstPart.AddRange(secondPart);
                Console.WriteLine("[" + String.Join(", ", firstPart) + "]");
            }
        }
        else
        {
            Console.WriteLine("The total number of cells is: {0}", cellCount);
        }
    }
}