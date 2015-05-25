using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class LineNumbersTryFinally
{
    static void Main()
    {
        //write data to the new file
        StreamReader reader = new StreamReader("input.txt");
        StreamWriter writer = new StreamWriter("output.txt");

        try
        {
            int lineNumber = 0;
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                string numberedLine = string.Format("Line {0, 2}  {1}", lineNumber, line);
                
                writer.WriteLine(numberedLine);
                lineNumber++;
            }
        }
        finally
        {
            reader.Close();
            writer.Close();
        }

        //print the new file on the console
        FileStream outputStream = new FileStream("output.txt", FileMode.Open);
        try
        {
            byte[] buffer = new byte[4096];
            while (true)
            {
                int readBytes = outputStream.Read(buffer, 0, buffer.Length);
                if (readBytes == 0)
                {
                    break;
                }
                foreach (var storedByte in buffer)
                {
                    Console.Write((char)storedByte);
                }
                Console.WriteLine();
            }
        }
        finally
        {
            outputStream.Close();   
        }
    }
}