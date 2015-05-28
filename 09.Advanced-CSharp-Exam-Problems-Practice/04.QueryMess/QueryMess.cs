using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class QueryMess
{
    static void Main()
    {
        string pattern = @"(?<field>[^&=?]+)=(?<value>[^&=?]+)";
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }

            HashSet<string> keys = new HashSet<string>();
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                string field = match.Groups["field"].Value;
                string value = match.Groups["value"].Value;

                field = Regex.Replace(field, @"%20", " ");
                field = Regex.Replace(field, @"[+]", " ");
                field = Regex.Replace(field, @"\s+", " ");
                field = field.Trim();

                value = Regex.Replace(value, @"%20", " ");
                value = Regex.Replace(value, @"[+]", " ");
                value = Regex.Replace(value, @"\s+", " ");
                value = value.Trim();

                keys.Add(field);

                if (result.ContainsKey(field))
                {
                    result[field].Add(value);
                }
                else
                {
                    List<string> values = new List<string>();
                    values.Add(value);
                    result[field] = values;
                }
            }
            foreach (var key in keys)
            {
                Console.Write("{0}=[{1}]", key, string.Join(", ", result[key]));
            }
            Console.WriteLine();
        }
    }
}