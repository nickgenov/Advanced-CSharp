using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class SumOfAllValues
{
    static void Main()
    {
        string keysString = RemoveSpaces(Console.ReadLine());
        string textString = Console.ReadLine();

        string startKeyPattern = @"^(?<key>[a-zA-Z_]+)([0-9]+)";
        string endKeyPattern = @"[0-9]+(?<key>[a-zA-Z_]+)$";

        string startKey = Regex.Match(keysString, startKeyPattern).Groups["key"].ToString();
        string endKey = Regex.Match(keysString, endKeyPattern).Groups["key"].ToString();

        if (startKey == string.Empty || endKey == string.Empty)
        {
            Console.WriteLine("<p>A key is missing</p>");
            return;
        }

        string textValuesPattern = startKey + @"(?<number>\.?[0-9]+\.?[0-9]*)" + endKey;

        List<double> numbers = new List<double>();
        MatchCollection matches = Regex.Matches(textString, textValuesPattern);
        foreach (Match match in matches)
        {
            string num = match.Groups["number"].Value;
            numbers.Add(double.Parse(num));
        }

        double sum = numbers.Sum();
        if (sum == 0)
        {
            Console.WriteLine("<p>The total value is: <em>nothing</em></p>");
        }
        else if (sum > 0)
        {
            Console.WriteLine("<p>The total value is: <em>{0}</em></p>", sum);
        }
    }
    public static string RemoveSpaces(string text)
    {
        StringBuilder build = new StringBuilder();
        foreach (var character in text)
        {
            if (character != ' ')
            {
                build.Append(character);
            }
        }
        return build.ToString();
    }
}