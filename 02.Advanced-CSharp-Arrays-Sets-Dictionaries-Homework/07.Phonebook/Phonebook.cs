using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Phonebook
{
    static void Main()
    {
        Dictionary<string, string> phonebook = new Dictionary<string, string>();

        string input = Console.ReadLine();
        while (input != "search")
        {
            string[] entry = input.Split('-');
            string key = entry[0];
            string value = entry[1];

            phonebook[key] = value;
            input = Console.ReadLine();
        }

        while (true)
        {
            input = Console.ReadLine();
            if (input == "end")
            {
                break;
            }
            if (phonebook.ContainsKey(input))
            {
                Console.WriteLine("{0} -> {1}", input, phonebook[input]);
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", input);
            }            
        }
    }
}