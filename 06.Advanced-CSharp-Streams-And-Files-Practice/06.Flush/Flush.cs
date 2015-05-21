using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Flush
{
    static void Main()
    {
        FileStream inputStream = new FileStream("file.txt", FileMode.Create);

        using (inputStream)
        {
            for (int i = 65; i <= 90; i++)
            {
                //all the ASCII codes in the alphabet
                inputStream.WriteByte((byte)i);

                //flush writes each byte instead of groups of 1024 bytes
                inputStream.Flush();
            }
        }
    }
}