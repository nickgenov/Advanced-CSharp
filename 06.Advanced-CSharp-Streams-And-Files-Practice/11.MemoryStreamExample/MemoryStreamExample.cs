using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class MemoryStreamExample
{
    static void Main()
    {
        string text = "Text in memory";
        byte[] bytes = Encoding.UTF8.GetBytes(text);

        using (MemoryStream memoryStream = new MemoryStream(bytes))
        {
            while (true)
            {
                int readByte = memoryStream.ReadByte();
                if (readByte == -1)
                {
                    break;
                }

                Console.WriteLine((char)readByte);
            }
        }
    }
}