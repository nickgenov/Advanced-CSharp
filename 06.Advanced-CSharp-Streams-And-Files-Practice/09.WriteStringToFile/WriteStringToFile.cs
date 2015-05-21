using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class WriteStringToFile
{
    static void Main()
    {
        string text = "Кирилица";
        FileStream input = new FileStream("log.txt", FileMode.Create);

        try
        {
            //encodes the characters to bytes
            //and stores them in an array
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            input.Write(buffer, 0, buffer.Length);
        }
        finally
        {
            input.Close();
        }
    }
}