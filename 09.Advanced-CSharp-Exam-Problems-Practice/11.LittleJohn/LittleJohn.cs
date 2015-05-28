using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class LittleJohn
{
    static void Main()
    {
        string smallArrowPattern = @">----->";
        string mediumArrowPattern = @">>----->";
        string largeArrowPattern = @">>>----->>";

        Regex smallRegex = new Regex(smallArrowPattern);
        Regex mediumRegex = new Regex(mediumArrowPattern);
        Regex largeRegex = new Regex(largeArrowPattern);

        int smallArrowsCount = 0;
        int mediumArrowsCount = 0;
        int largeArrowsCount = 0;

        for (int row = 0; row < 4; row++)
        {
            string input = Console.ReadLine();
            MatchCollection largeArrows = largeRegex.Matches(input);
            largeArrowsCount += largeArrows.Count;
            input = largeRegex.Replace(input, "*");

            MatchCollection mediumArrows = mediumRegex.Matches(input);
            mediumArrowsCount += mediumArrows.Count;
            input = mediumRegex.Replace(input, "*");

            MatchCollection smallArrows = smallRegex.Matches(input);
            smallArrowsCount += smallArrows.Count;
        }

        string result = string.Empty + smallArrowsCount + mediumArrowsCount + largeArrowsCount;

        string binaryResult = Convert.ToString(int.Parse(result), 2);
        string binaryResultReversed = ReverseString(binaryResult);
        string combinedResult = binaryResult + binaryResultReversed;

        long finalResult = Convert.ToInt64(combinedResult, 2);
        Console.WriteLine(finalResult);
    }
    public static string ReverseString(string word)
    {
        char[] characters = word.ToCharArray();
        Array.Reverse(characters);
        return new string(characters);
    }
}