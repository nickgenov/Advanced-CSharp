using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class SemanticHTML
{
    public static void Main()
    {
        const string openingTagPattern = @"<\s*div\s+(?<first>.*?)(?:id|class)\s*=\s*""(?<tagName>main|header|nav|article|section|aside|footer)""(?<second>.*?)\s*>";
        const string closingTagPattern = @"<\/div>\s*<!--\s*(?<tagName>main|header|nav|article|section|aside|footer)\s*-->";

        List<string> result = new List<string>();
        string input = Console.ReadLine();

        while (input != "END")
        {
            if (Regex.IsMatch(input, openingTagPattern))
            {
                var match = Regex.Match(input, openingTagPattern);

                string first = match.Groups["first"].ToString();
                string second = match.Groups["second"].ToString();
                string tagName = match.Groups["tagName"].ToString();

                string tag = string.Format("{0} {1} {2}", tagName, first, second);
                tag = Regex.Replace(tag, @"\s+", " ").Trim();
                tag = "<" + tag + ">";

                result.Add(tag);
            }
            else if (Regex.IsMatch(input, closingTagPattern))
            {
                var match = Regex.Match(input, closingTagPattern);

                string tagName = match.Groups["tagName"].ToString();

                string tag = string.Format("</{0}>", tagName);

                result.Add(tag);
            }
            else
            {
                result.Add(input);
            }

            input = Console.ReadLine();
        }

        foreach (var line in result)
        {
            Console.WriteLine(line);
        }
    }
}