using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class ExtractHyperlinks
{
    static void Main()
    {
        const string pattern = @"(<\s*a\s*)([^<>]*\s+)?href\s*=\s*(?:(?:'(?<match1>[^'>]+)')|(?:""(?<match2>[^""]+)"")|(?<match3>[^\s>]+))[^>]*>";

        StringBuilder buildHTML = new StringBuilder();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            buildHTML.Append(input);
        }
        string html = buildHTML.ToString();
        
        MatchCollection matches = Regex.Matches(html, pattern);
        foreach (Match match in matches)
        {
            string match1 = match.Groups["match1"].Value;
            string match2 = match.Groups["match2"].Value;
            string match3 = match.Groups["match3"].Value;

            if (match1 != string.Empty)
            {
                Console.WriteLine(match1);
            }
            else if (match2 != string.Empty)
            {
                Console.WriteLine(match2);
            }
            else if (match3 != string.Empty)
            {
                Console.WriteLine(match3);
            }
            else
            {
                Console.WriteLine("<p>This text has no links</p>");
            }
        }
    }
}