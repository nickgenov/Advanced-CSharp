using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class PhoneNumbers
{
    static void Main()
    {
        //parse the input rows
        string text = string.Empty;
        StringBuilder buildText = new StringBuilder();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            buildText.Append(input);
        }
        text = buildText.ToString();

        //store the result rows in this list
        List<string> personNumber = new List<string>();

        //use match groups to capture the name and phone number
        string pattern = @"(?<name>[A-Z]{1}[A-Za-z]*)([^A-Za-z0-9+]*)(?<number>[+]*[0-9]{1}[0-9()\/.\s-]*[0-9]{1})";
        MatchCollection matches = Regex.Matches(text, pattern);

        foreach (Match match in matches)
        {
            string name = match.Groups["name"].Value;
            string phoneNumber = match.Groups["number"].Value;

            //replace all symbols except numbers and +
            phoneNumber = Regex.Replace(phoneNumber, "[^0-9+]+", "");

            string line = string.Format("<li><b>{0}:</b> {1}</li>", name, phoneNumber);
            personNumber.Add(line);
        }

        //print the result
        if (personNumber.Count == 0)
        {
            Console.WriteLine("<p>No matches!</p>");
        }
        else
        {
            StringBuilder buildResult = new StringBuilder();
            buildResult.Append("<ol>");
            foreach (var line in personNumber)
            {
                buildResult.Append(line);
            }
            buildResult.Append("</ol>");

            string result = buildResult.ToString();
            Console.WriteLine(result);
        }
    }
}