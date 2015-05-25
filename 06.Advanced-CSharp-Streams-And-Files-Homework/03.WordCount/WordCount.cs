using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class WordCount
{
    static void Main()
    {
        StreamReader readWords = new StreamReader("words.txt");
        StreamReader readText = new StreamReader("text.txt");
        StreamWriter writeResult = new StreamWriter("result.txt");

        Dictionary<string, int> result = new Dictionary<string, int>();
        List<string> words = new List<string>();

        using (readWords)
        {
            using (readText)
            {
                //add the words to search to a list
                while (true)
                {
                    string word = readWords.ReadLine();
                    if (word == null)
                    {
                        break;
                    }
                    word = word.ToLower();

                    result[word] = 0;
                    words.Add(word);
                }

                //search for the words in the list in each line of the text
                while (true)
                {
                    string line = readText.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    string[] lineWords = line.Split(new char[] { '.', ',', '!', '?', ';', ':', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

                    //check the line for all of the words in the list
                    foreach (var listWord in words)
                    {
                        var wordsQuery =
                            from lineWord in lineWords
                            where lineWord.ToLower() == listWord
                            select lineWord;
                        int wordCount = wordsQuery.Count();

                        //store the found words data in a list
                        if (result.ContainsKey(listWord))
                        {
                            result[listWord] += wordCount;
                        }
                    }
                }
            }
        }
        //use LINQ to sort the dictionary by value
        var sortedResult =
            from entry in result
            orderby entry.Value descending
            select entry;

        //write the data to the result.txt file

        using (writeResult)
        {
            foreach (var entry in sortedResult)
            {
                string line = string.Format("{0} - {1}", entry.Key, entry.Value);
                writeResult.WriteLine(line);
            }
        }

        //print the result.txt file to the console to verify
        StreamReader resultPrint = new StreamReader("result.txt");
        using (resultPrint)
        {
            while (true)
            {
                string line = resultPrint.ReadLine();
                if (line == null)
                {
                    break;
                }
                Console.WriteLine(line);
            }
        }
    }
}