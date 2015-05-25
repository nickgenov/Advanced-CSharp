using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class LineNumbers
{
    static void Main()
    {
        //write data to the new file
        StreamReader reader = new StreamReader("input.txt");
        StreamWriter writer = new StreamWriter("output.txt");

        int lineNumber = 0;
        using (reader)
        {
            using (writer)
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    string numberedLine = string.Format("Line {0,2}  {1}", lineNumber, line);

                    writer.WriteLine(numberedLine);
                    lineNumber++;
                }
            }
        }
        //print the new file contents on the console
        StreamReader readerOutput = new StreamReader("output.txt");
        using (readerOutput)
        {
            while (true)
            {
                string line = readerOutput.ReadLine();
                if (line == null)
                {
                    break;
                }
                Console.WriteLine(line);
            }
        }
    }
}