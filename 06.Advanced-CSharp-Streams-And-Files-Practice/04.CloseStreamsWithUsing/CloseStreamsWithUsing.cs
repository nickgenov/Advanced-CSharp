using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class CloseStreamsWithUsing
{
    static void Main()
    {
        FileStream inputStream = new FileStream("file.txt", FileMode.Open);
        FileStream outputStream = new FileStream("output.txt", FileMode.Create);

        using (inputStream)
        {
            using (outputStream)
            {
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
            }
            //here the outputStream is closed
        }
        //here the inputStream is closed
    }
}