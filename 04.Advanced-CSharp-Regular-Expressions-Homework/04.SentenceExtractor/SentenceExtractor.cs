using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class SentenceExtractor
{
    static void Main()
    {
        string keyword = Console.ReadLine();
        string text = Console.ReadLine();

        string pattern = @"[\w\s’]+(–)?[\w\s’]+[!.?]";
        Regex regex = new Regex(pattern);
        MatchCollection validSentences = regex.Matches(text);

        Regex findKeyword = new Regex(keyword);

        foreach (var sentence in validSentences)
        {
            string currentSentence = sentence.ToString();
            if (findKeyword.IsMatch(currentSentence))
            {
                Console.WriteLine(currentSentence.Trim());
            }
        }
    }
}