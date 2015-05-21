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
        FileStream inputStream = new FileStream("sourceFile.txt", FileMode.Open);
        FileStream outputStream = new FileStream("destinationFile.txt", FileMode.Create);

        byte[] buffer = new byte[4096];
        while (true)
        {
            int readBytes = inputStream.Read(buffer, 0, buffer.Length);
            if (readBytes == 0)
            {
                break;
            }
            outputStream.Write(buffer, 0, readBytes);
        }
        //.Close() calls .Flush() 
        inputStream.Close();
        outputStream.Close();
    }
}