using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class XRemoval
{
    static void Main()
    {
        List<char[]> text = new List<char[]>();
        while (true)
        {
            string line = Console.ReadLine();
            if (line == "END")
            {
                break;
            }
            text.Add(line.ToCharArray());
        }

        //calculate the positions to remove and set them to '\0'
        HashSet<string> remove = PositionsToRemove(text);
        foreach (var item in remove)
        {
            int[] coordinates = item.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = coordinates[0];
            int col = coordinates[1];

            text[row][col] = '\0';
        }

        //Assemble and print the result
        List<string> finalResult = AssembleResult(text);
        foreach (var item in finalResult)
        {
            Console.WriteLine(item);
        }

    }
    public static HashSet<string> PositionsToRemove(List<char[]> text)
    {
        HashSet<string> remove = new HashSet<string>();
        for (int row = 0; row < text.Count - 2; row++)
        {
            for (int col = 0; col < text[row].Length - 2; col++)
            {
                string a = text[row][col].ToString().ToLower();
                string b = text[row][col + 2].ToString().ToLower();
                string c = string.Empty;
                string d = string.Empty;
                string e = string.Empty;

                if (text[row + 1].Length >= col + 2)
                {
                    c = text[row + 1][col + 1].ToString().ToLower();
                }
                if (text[row + 2].Length >= col + 3)
                {
                    d = text[row + 2][col].ToString().ToLower();
                    e = text[row + 2][col + 2].ToString().ToLower();
                }

                if (a == b && b == c && c == d && d == e && e != string.Empty)
                {
                    remove.Add(string.Format("{0}|{1}", row, col));
                    remove.Add(string.Format("{0}|{1}", row, col + 2));
                    remove.Add(string.Format("{0}|{1}", row + 1, col + 1));
                    remove.Add(string.Format("{0}|{1}", row + 2, col));
                    remove.Add(string.Format("{0}|{1}", row + 2, col + 2));
                }
            }
        }
        return remove;
    }
    public static List<string> AssembleResult(List<char[]> text)
    {
        List<string> result = new List<string>();
        foreach (var charArray in text)
        {
            StringBuilder build = new StringBuilder();
            foreach (var character in charArray)
            {
                if (character != '\0')
                {
                    build.Append(character);
                }
            }
            result.Add(build.ToString());
        }
        return result;
    }
}