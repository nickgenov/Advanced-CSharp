using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LongestIncreasingSequence
{
    static void Main()
    {
        string[] input = Console.ReadLine().Trim().Split(' ');
        int[] integers = new int[input.Length];
        for (int i = 0; i < integers.Length; i++)
        {
            integers[i] = int.Parse(input[i]);
        }

        int currentLength = 0;
        int maxLength = 0;
        int index = 0;

        for (int i = 0; i < integers.Length; i++) {
                    
            Console.Write(integers[i] + " ");
            currentLength++;
                    
            if (currentLength > maxLength) {
                    maxLength = currentLength;
                    index = i;
            }
                    
            if ((i < integers.Length - 1) && (integers[i] < integers[i + 1]) == false) {
                    Console.WriteLine();
                    currentLength = 0;
            }
        }

        Console.WriteLine();
        Console.Write("Longest: ");
             
        for (int i = index - maxLength + 1; i <= index; i++) {
            Console.Write(integers[i] + " ");
        }
        Console.WriteLine();
    }
}