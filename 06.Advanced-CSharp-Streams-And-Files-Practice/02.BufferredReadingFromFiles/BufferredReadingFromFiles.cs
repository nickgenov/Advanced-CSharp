using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class BufferredReadingFromFiles
{
    static void Main()
    {
        FileStream stream = new FileStream("text.txt", FileMode.Open);

        byte[] buffer = new byte[4096];

        while (true)
        {
            //this time readBytes contains the NUMBER of bytes that
            //were stored in the buffer array
            int readBytes = stream.Read(buffer, 0, buffer.Length);
            if (readBytes == 0)
            {
                break;
            }
            foreach (var storedByte in buffer)
            {
                Console.Write((char)storedByte);
            }
        }
        //.Close() calls .Flush() 
        stream.Close();
    }
}