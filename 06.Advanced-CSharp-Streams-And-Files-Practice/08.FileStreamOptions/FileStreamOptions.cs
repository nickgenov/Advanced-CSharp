using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class FileStreamOptions
{
    static void Main()
    {
        //FileAccess - operations made to the file
        //FileMode - Open, Create, Append...
        //FileShare - None, Read, Write, ReadWrite
        //and others
        FileStream inputStream = new FileStream("file.txt", FileMode.Create, FileAccess.Write, FileShare.None);

        using (inputStream)
        {
            for (int i = 65; i <= 90; i++)
            {
                inputStream.WriteByte((byte)i);
            }
        }
    }
}