using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class BiggestTableRow
{
    static void Main()
    {
        List<List<string>> rowData = new List<List<string>>();

        while (true)
        {
            string row = Console.ReadLine();
            if (row == "</table>")
            {
                break;
            }
            List<string> numbers = new List<string>();

            string pattern = @"<td>(?<number>[0-9.-]+)<\/td>";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(row);

            foreach (Match match in matches)
            {
                string num = match.Groups["number"].Value;
                if (num != "-")
                {
                    numbers.Add(num);
                }
            }
            
            if (numbers.Count > 0)
            {
                rowData.Add(numbers);
            }
        }

        bool validSolution = false;
        int maxRowIndex = -1;
        double maxSum = double.MinValue;

        for (int row = 0; row < rowData.Count; row++)
        {
            double sum = 0;
            List<string> currentRow = rowData[row];
            foreach (var item in currentRow)
            {
                sum += double.Parse(item);
            }
            if (sum > maxSum)
            {
                maxSum = sum;
                maxRowIndex = row;
                validSolution = true;
            }
        }

        if (validSolution)
        {
            List<string> maxRow = rowData[maxRowIndex];
            Console.WriteLine(string.Format("{0} = {1}", maxSum, string.Join(" + ", maxRow)));
        }
        else
        {
            Console.WriteLine("no data");
        }
    }
}