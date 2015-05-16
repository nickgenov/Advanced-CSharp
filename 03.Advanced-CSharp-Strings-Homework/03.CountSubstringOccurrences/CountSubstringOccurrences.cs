using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CountSubstringOccurrences
{
    static void Main()
    {
        //use ToLower() because character casing is ignored
        string text = Console.ReadLine().ToLower();
        string search = Console.ReadLine().ToLower();

        //calculate the last index once instead of on every iteration
        int lastIndex = text.Length - search.Length + 1;
        int matchesCount = 0;

        for (int i = 0; i < lastIndex; i++)
        {
            //check if a match was found and increase the counter
            string match = text.Substring(i, search.Length);
            if (search == match)
            {
                matchesCount++;
            }
        }
        //print the result
        Console.WriteLine(matchesCount);
    }
}