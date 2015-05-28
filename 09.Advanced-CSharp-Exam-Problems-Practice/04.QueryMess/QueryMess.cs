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
        string pattern = @"(?<field>[A-Za-z]+)[+]*=[+]*(?<value>[A-Za-z0-9%+:\/.*-_]+)";
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }

            HashSet<string> fields = new HashSet<string>();
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();

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

                fields.Add(field);
                if (data.ContainsKey(field))
                {
                    data[field].Add(value);
                }
                else
                {
                    List<string> dataValues = new List<string>();
                    data[field] = dataValues;
                    dataValues.Add(value);
                }
            }
            foreach (var field in fields)
            {
                Console.WriteLine(string.Join(", ", data[field]));
            }
        }
    }
}

/* login=student&password=student
END

login=[student]password=[student]
............
foo=%20foo&value=+val&foo+=5+%20+203
foo=poo%20&value=valley&dog=wow+
url=https://softuni.bg/trainings/coursesinstances/details/1070
https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php
END

foo=[foo, 5 203]value=[val]
foo=[poo]value=[valley]dog=[wow]
url=[https://softuni.bg/trainings/coursesinstances/details/1070]
trainer=[nakov]course=[oop, php]
............
field=value1&field=value2&field=value3
http://example.com/over/there?name=ferret
END

field=[value1, value2, value3]
name=[ferret]
..........
For each row of the input, the query string contains pairs field=value. Within each pair, the field name and value are separated by an equals sign, '='. The series of pairs are separated by an ampersand, '&'. The question mark is used as a separator and is not part of the query string. A URL query string may contain another URL as value. 

•	SPACE is encoded as '+' or "%20". Letters (A-Z and a-z), numbers (0-9), the characters '*', '-', '.', '_' and other non-special symbols are left as-is.
For each input line, print on the console a line containing the processed string as follows:  key=[value]nextkey=[another  value] … etc. 

Multiple whitespace characters should be reduced to one inside value/key names, but there shouldn’t be any whitespaces before/after extracted keys and values. If a key already exists, the value is added with comma and space after other values of the existing key in the current string.  See the examples below.  

*/

