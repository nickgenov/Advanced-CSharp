using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class StreamWriterNumbers
{
    static void Main()
    {
        using (StreamWriter writer = new StreamWriter("../../numbers.txt"))
        {
            for (int i = 0; i < 100000; i++)
            {
                writer.WriteLine(i);
            }
        }

    }
}

