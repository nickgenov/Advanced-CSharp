using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security;


class UppercaseWords
{
    static void Main()
    {
        string text = Console.ReadLine();
        while (text != "END")
        {
            //assemble the result and each word in StringBuilder
            StringBuilder result = new StringBuilder();
            StringBuilder wordBuilder = new StringBuilder();

            //go through the text symbol by symbol
            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];
                //if the symbol is a letter, add it to the word
                if (char.IsLetter(symbol))
                {
                    wordBuilder.Append(symbol);
                }
                //if it is not, process the current word and append it to the result
                else
                {
                    result.Append(ProcessWord(wordBuilder.ToString()));
                    //append the non-letter symbol too
                    result.Append(symbol);

                    //clear the assembled word and start over
                    wordBuilder.Clear();
                }
            }
            //append the last assembled word
            result.Append(ProcessWord(wordBuilder.ToString()));

            //print the result
            Console.WriteLine(SecurityElement.Escape(result.ToString()));

            text = Console.ReadLine();
        }
    }
    public static bool WordIsUppercase(string word)
    {
        bool wordIsUpper = true;
        foreach (var letter in word)
        {
            if (char.IsUpper(letter) == false)
            {
                wordIsUpper = false;
                break;
            }
        }
        return wordIsUpper;
    }
    public static string ReverseWord(string word)
    {
        StringBuilder reversed = new StringBuilder();
        for (int i = word.Length - 1; i >= 0; i--)
        {
            reversed.Append(word[i]);
        }
        return reversed.ToString();
    }
    public static string DoubleWordLetters(string word)
    {
        StringBuilder result = new StringBuilder();
        foreach (var letter in word)
        {
            for (int i = 0; i < 2; i++)
            {
                result.Append(letter);
            }
        }
        return result.ToString();
    }
    public static string ProcessWord(string word)
    {
        if (WordIsUppercase(word))
        {
            string reversedWord = ReverseWord(word);
            if (word == reversedWord)
            {
                return DoubleWordLetters(word);
            }
            else
            {
                return reversedWord;
            }
        }
        else
        {
            return word;
        }
    }
}