using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Palindromes
{
    static void Main()
    {
        string[] words = Console.ReadLine().
            Split(new char[] { ' ', ',', '.', '?', '!' }, 
            StringSplitOptions.RemoveEmptyEntries);

        //initialize a sorted set to store the palindromes
        SortedSet<string> uniquePalindromes = new SortedSet<string>();

        //add found palindromes to the set
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            bool isPalindrome = checkPalindrome(word);
            if (isPalindrome)
            {
                uniquePalindromes.Add(word);
            }
        }

        //print the result in the requested format
        for (int i = 0; i < uniquePalindromes.Count; i++)
        {
            Console.Write(uniquePalindromes.ElementAt(i));
            if (i < uniquePalindromes.Count - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
    }
    public static bool checkPalindrome(string word) {
        bool isPalindrome = false;
        if (word.Length == 1)
        {
            isPalindrome = true;
        }
        else
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                char compare1 = word[i];
                char compare2 = word[word.Length - 1 - i];

                isPalindrome = true;
                if (compare1 != compare2)
                {
                    isPalindrome = false;
                    break;
                }
            }
        }
        return isPalindrome;
    }
}