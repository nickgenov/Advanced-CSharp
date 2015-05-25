using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;


class ZippingSlicedFiles
{
    static void Main()
    {
        string sourceFile = "../../files/K2.jpg";
        string destinationDirectory = "../../files/";
        int parts = 4;

        List<string> files = new List<string>() {
            "Part-0.gz",
            "Part-1.gz",
            "Part-2.gz",
            "Part-3.gz",
        };

        Slice(sourceFile, destinationDirectory, parts);
        Assemble(files, destinationDirectory, sourceFile);

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
                using (FileStream destination = new FileStream(string.Format("{0}Part-{1}.gz", destinationDirectory, partNumber), FileMode.Create))
                {
                    using (GZipStream compressionStream = new GZipStream(destination, CompressionMode.Compress, false))
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

                            compressionStream.Write(buffer, 0, readBytes);

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
    }
    public static void Assemble(List<string> files, string destinationDirectory, string sourceFile)
    {
        string fileExtension = GetFileExtension(sourceFile);
        using (FileStream destination = new FileStream(string.Format("{0}assembled{1}", destinationDirectory, fileExtension), FileMode.Create))
        {
            foreach (var file in files)
            {
                using (FileStream source = new FileStream(string.Format("{0}{1}", destinationDirectory, file), FileMode.Open))
                {
                    using (GZipStream compressionStream = new GZipStream(source, CompressionMode.Decompress, false))
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int readBytes = compressionStream.Read(buffer, 0, buffer.Length);
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
    }
    public static string GetFileExtension(string sourceFile)
    {
        string pattern = @"\.[\w]+";
        Regex regex = new Regex(pattern);
        Match fileExtension = regex.Match(sourceFile);
        return fileExtension.ToString();
    }
}