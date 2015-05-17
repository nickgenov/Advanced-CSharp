using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class ExtractEmails
{
    static void Main()
    {
        string text = Console.ReadLine();

        string pattern = @"[A-Za-z0-9]+([._-])?([A-Za-z0-9]+)?@([A-Za-z0-9-]+\.[A-Za-z]+)(\.[A-Za-z]+)?";
        Regex regex = new Regex(pattern);
        MatchCollection validEmails = regex.Matches(text);

        foreach (var email in validEmails)
        {
            Console.WriteLine(email);
        }
    }
}