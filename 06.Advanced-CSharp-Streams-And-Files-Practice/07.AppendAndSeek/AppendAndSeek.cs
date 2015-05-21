using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class AppendAndSeek
{
    static void Main()
    {
        FileStream inputStream = new FileStream("file.txt", FileMode.Append);

        //Seek moves the position to End, Beginning or Current
        inputStream.Seek(0, SeekOrigin.End);
        using (inputStream)
        {
            for (int i = 65; i <= 90; i++)
            {
                inputStream.WriteByte((byte)i);
            }
            inputStream.Flush();
        }
    }
}