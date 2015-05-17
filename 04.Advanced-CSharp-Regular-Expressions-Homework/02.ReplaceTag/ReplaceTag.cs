using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class ReplaceTag
{
    static void Main()
    {
        string text = "<ul><li><a href=http://softuni.bg>SoftUni</a></li></ul>";
        string pattern = @"<a href=http:\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+>[A-Za-z0-9]+<\/a>";

        string aStartPattern = @"<a href=";
        string aEndPattern = @"</a>";

        Regex regex = new Regex(pattern);
        if (regex.IsMatch(text))
        {
            string result = text;
            result = result.Replace(aStartPattern, "[URL href=");
            result = result.Replace(aEndPattern, "[/URL]");
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }
}