using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class CloseStreamsTryFinally
{
    static void Main()
    {
        FileStream inputStream = new FileStream("file.txt", FileMode.Open);
        FileStream outputStream = new FileStream("output.txt", FileMode.Create);

        try
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
        //this block always executes
        //whatever happens, the streams will be closed
        finally
        {
            //.Close() calls .Flush() 
            inputStream.Close();
            outputStream.Close();
        }
    }
}