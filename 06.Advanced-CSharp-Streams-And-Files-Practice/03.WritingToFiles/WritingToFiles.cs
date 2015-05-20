using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class WritingToFiles
{
    static void Main()
    {
        FileStream stream = new FileStream("text.txt", FileMode.Open);

        byte[] writeBuffer = { 70 };

        for (int i = 0; i < 2; i++)
        {
            stream.Write(writeBuffer, 0, writeBuffer.Length);
        }

        byte[] readBuffer = new byte[4096];

        while (true)
        {
            int readBytes = stream.Read(readBuffer, 0, readBuffer.Length);
            if (readBytes == 0)
            {
                break;
            }
            foreach (var readByte in readBuffer)
            {
                Console.Write((char)readByte);
            }
        }
    }
}