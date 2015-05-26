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

        string linkPattern = @"<a.+?<\/a>";
        Regex linkRegex = new Regex(linkPattern);

        List<string> links = new List<string>();
        MatchCollection linkMatches = linkRegex.Matches(html);
        foreach (var link in linkMatches)
        {
            links.Add(link.ToString());
        }

        foreach (var link in links)
        {
            Console.WriteLine(link);
        }
    }
}