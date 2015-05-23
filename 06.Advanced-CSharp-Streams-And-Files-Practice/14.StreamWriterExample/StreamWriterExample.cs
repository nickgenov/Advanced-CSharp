using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class StreamWriterExample
{
    static void Main()
    {
        StreamReader reader = new StreamReader("../../StreamWriterExample.cs");
        StreamWriter writer = new StreamWriter("file.txt");

        using (reader)
        {
            using (writer)
            {
                int lineCount = 0;
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    lineCount++;
                    writer.WriteLine("Line: {0, 3}: {1}", lineCount, line);
                }
            }
        }
    }
}