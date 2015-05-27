using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class TheNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();

        string pattern = @"[0-9]+";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(input);

        List<int> numbers = new List<int>();
        foreach (var match in matches)
        {
            numbers.Add(int.Parse(match.ToString()));
        }

        List<string> hexNumbers = new List<string>();
        foreach (var num in numbers)
        {
            string hex = string.Format("{0:X}", num).PadLeft(4, '0');
            hex = string.Format("0x{0}", hex);
            hexNumbers.Add(hex);
        }

        string result = string.Join("-", hexNumbers);
        Console.WriteLine(result);
    }
}