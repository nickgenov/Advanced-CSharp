using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StuckNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(' ');
        List<int> numbers = new List<int>();
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != string.Empty)
            {
                numbers.Add(int.Parse(input[i]));
            }
        }

        bool validSolution = false;
        for (int num1 = 0; num1 < numbers.Count; num1++)
        {
            for (int num2 = 0; num2 < numbers.Count; num2++)
            {
                for (int num3 = 0; num3 < numbers.Count; num3++)
                {
                    for (int num4 = 0; num4 < numbers.Count; num4++)
                    {
                        int a = numbers[num1];
                        int b = numbers[num2];
                        int c = numbers[num3];
                        int d = numbers[num4];
                        if (a != b && a != c & a != d &&
                            b != c && b != d && c != d)
                        {
                            String first = "" + a + b;
                            String second = "" + c + d;
                            if (first == second)
                            {
                                Console.WriteLine("{0}|{1}=={2}|{3}", a, b, c, d);
                                validSolution = true;
                            }
                        }
                    }
                }
            }
        }
        if (validSolution == false)
        {
            Console.WriteLine("No");
        }
    }
}