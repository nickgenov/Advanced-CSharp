using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


class StopWatchMeasurements
{
    static void Main()
    {
        Stopwatch timer = new Stopwatch();        

        using (StreamWriter writer = new StreamWriter("file.txt"))
        {
            writer.AutoFlush = true;

            timer.Start();
            for (int i = 0; i < 1000000; i++)
            {
                writer.WriteLine(i);
            }
            timer.Stop();
            Console.WriteLine("With AutoFlush: {0}", timer.Elapsed);
        }

        using (StreamWriter writer = new StreamWriter("file.txt"))
        {
            timer.Reset();
            timer.Start();
            for (int i = 0; i < 1000000; i++)
            {
                writer.WriteLine(i);
            }
            timer.Stop();
            Console.WriteLine("Buffered Write: {0}", timer.Elapsed);
        }
    }
}