using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TextFilter
{
    static void Main()
    {
        //remove the empty strings from the array of banned words
        string[] bannedWords = Console.ReadLine()
            .Split(new[]{',', ' '}, StringSplitOptions.RemoveEmptyEntries);
        string text = Console.ReadLine();

        for (int i = 0; i < bannedWords.Length; i++)
        {
            string word = bannedWords[i];
            int asteriskCount = word.Length;
            text = text.Replace(word, new string('*', asteriskCount));
        }

        Console.WriteLine(text);
    }
}