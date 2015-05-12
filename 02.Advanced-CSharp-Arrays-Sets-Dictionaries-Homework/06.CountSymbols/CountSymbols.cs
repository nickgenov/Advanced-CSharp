using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CountSymbols
{
    static void Main()
    {
        //parse input
        SortedDictionary<char, int> symbolsCount = new SortedDictionary<char, int>();
        string input = Console.ReadLine();

        //store the data in the dictionary
        for (int i = 0; i < input.Length; i++)
        {
            char symbol = input[i];
            if (symbolsCount.ContainsKey(symbol) == false)
            {
                symbolsCount[symbol] = 1;
            }
            else
            {               
                symbolsCount[symbol]++;
            }
        }

        //print the result
        foreach (KeyValuePair<char, int> entry in symbolsCount)
        {
            Console.WriteLine("{0}: {1} time/s", entry.Key, entry.Value);
        }
    }
}