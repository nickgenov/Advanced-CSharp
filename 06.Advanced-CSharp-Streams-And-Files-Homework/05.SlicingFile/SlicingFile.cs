using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


class SlicingFile
{
    static void Main()
    {
        string sourceFile = "../../files/K2.jpg";
        string destinationDirectory = "../../files/";
        int parts = 4;

        List<string> files = new List<string>() {
            "Part-0.jpg",
            "Part-1.jpg",
            "Part-2.jpg",
            "Part-3.jpg",
        };

        Slice(sourceFile, destinationDirectory, parts);
        Assemble(files, destinationDirectory);

    }
    public static void Slice(string sourceFile, string destinationDirectory, int parts)
    {
        string fileExtension = GetFileExtension(sourceFile);
        using (FileStream source = new FileStream(sourceFile, FileMode.Open))
        {
            long bytesInSource = source.Length;
            double bytesPerPart = Math.Ceiling(bytesInSource / (double)parts);

            for (int partNumber = 0; partNumber < parts; partNumber++)
            {
                using (FileStream destination = new FileStream(string.Format("{0}Part-{1}{2}", destinationDirectory, partNumber, fileExtension), FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    long bytesWrittenToPart = 0;
                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, readBytes);
                        bytesWrittenToPart += readBytes;
                        if (bytesWrittenToPart >= bytesPerPart)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
    public static void Assemble(List<string> files, string destinationDirectory)
    {
        string fileExtension = string.Empty;
        if (files.Count > 0)
        {
            fileExtension = GetFileExtension(files[0]);
        }

        using (FileStream destination = new FileStream(string.Format("{0}assembled{1}", destinationDirectory, fileExtension), FileMode.Create))
        {
            foreach (var file in files)
            {
                using (FileStream source = new FileStream(string.Format("{0}{1}", destinationDirectory, file), FileMode.Open))
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
    public static string GetFileExtension(string sourceFile)
    {
        string pattern = @"\.[\w]+";
        Regex regex = new Regex(pattern);
        Match fileExtension = regex.Match(sourceFile);
        return fileExtension.ToString();
    }
}