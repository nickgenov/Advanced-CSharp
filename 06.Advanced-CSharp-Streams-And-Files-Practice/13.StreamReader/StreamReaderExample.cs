using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class StreamReaderExample
{
    static void Main()
    {
        StreamReader reader = new StreamReader("../../StreamReaderExample.cs");

        using (reader)
        {
            int lineNumber = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                lineNumber++;
                Console.WriteLine("Line {0, 2}: {1}", lineNumber, line);
                line = reader.ReadLine();
            }
        }

    }
}