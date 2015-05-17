using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class SeriesOfLetters
{
    static void Main()
    {
        string text = Console.ReadLine();
        string pattern = @"([A-Za-z])\1{1,}";

        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(text);

        string result = text;
        foreach (var match in matches)
        {
            char replaceChar = match.ToString()[0];
            string matchReplace = replaceChar.ToString();
            result = result.Replace(match.ToString(), matchReplace);
        }
        Console.WriteLine(result);
    }
}