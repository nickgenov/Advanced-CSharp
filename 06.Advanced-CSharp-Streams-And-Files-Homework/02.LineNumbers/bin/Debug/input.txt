using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class OddLines
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("file.txt", System.Text.Encoding.UTF8))
        {
            int lineNumber = 0;
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                if (lineNumber % 2 == 1)
                {
                    Console.WriteLine(line);
                }
                lineNumber++;
            }
        }
    }
}