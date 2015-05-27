using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Parachute
{
    static void Main()
    {
        List<string> input = new List<string>();
        while (true)
        {
            string line = Console.ReadLine();
            if (line == "END")
            {
                break;
            }
            input.Add(line);
        }

        int position = -1;
        for (int row = 0; row < input.Count - 1; row++)
        {
            if (input[row].Contains("o"))
            {
                position = input[row].IndexOf("o");
            }
            if (position >= 0)
            {
                string nextLine = input[row + 1];
                int wind = CalculateWind(nextLine);

                position += wind;
                int landingType = CheckLandingType(nextLine, position);
                if (landingType > 0)
                {
                    PrintOutcome(landingType, row + 1, position);
                    break;
                }
            }
        }
    }
    public static int CalculateWind(string line)
    {
        int wind = 0;
        foreach (var character in line)
        {
            if (character == '>')
            {
                wind++;
            }
            else if (character == '<')
            {
                wind--;
            }
        }
        return wind;
    }
    public static int CheckLandingType(string nextLine, int position)
    {
        char obstacle = nextLine[position];
        if (obstacle == '_')
        {
            return 1;
        }
        else if (obstacle == '~')
        {
            return 2;
        }
        else if (obstacle == '/' || obstacle == '\\' || obstacle == '|')
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }
    public static void PrintOutcome(int landingType, int row, int col)
    {
        if (landingType == 1)
        {
            Console.WriteLine("Landed on the ground like a boss!");
        }
        else if (landingType == 2)
        {
            Console.WriteLine("Drowned in the water like a cat!");
        }
        else if (landingType == 3)
        {
            Console.WriteLine("Got smacked on the rock like a dog!");
        }
        Console.WriteLine("{0} {1}", row, col);
    }
}