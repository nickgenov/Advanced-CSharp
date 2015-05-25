using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class CopyBinaryFile
{
    static void Main()
    {
        using (FileStream source = new FileStream("K2.jpg", FileMode.Open))
        {
            using (FileStream destination = new FileStream("K2-copy.jpg", FileMode.Create))
            {
                byte[] buffer = new byte[4096];
                while (true)
                {
                    int readBytes = source.Read(buffer, 0, buffer.Length);
                    if (readBytes == 0)
                    {
                        break;
                    }
                    destination.Write(buffer, 0, readBytes);
                }
            }
        }
    }
}