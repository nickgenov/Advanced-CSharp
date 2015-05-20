using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class ReadingFromFiles
{
    static void Main()
    {
        FileStream stream = new FileStream("text.txt", FileMode.Open);

        while (true)
        {
            int readByte = stream.ReadByte();
            //-1 means that no byte was read (end of file)
            if (readByte == -1)
            {
                break;
            }
            Console.WriteLine((char)readByte);
        }
    }
}