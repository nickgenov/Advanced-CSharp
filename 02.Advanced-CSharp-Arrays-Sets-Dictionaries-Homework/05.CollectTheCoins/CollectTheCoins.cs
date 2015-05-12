using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CollectTheCoins
{
    static void Main()
    {
        //parse input
        string[] input = new string[4];
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = Console.ReadLine();
        }
        string commands = Console.ReadLine();

        int coinsCollected = 0;
        int wallHits = 0;
        int row = 0;
        int col = 0;

        //check the starting position [0,0]
        if (input[0][0] == '$')
        {
            coinsCollected++;
        }

        //perform commands
        for (int commandPos = 0; commandPos < commands.Length; commandPos++)
        {
            char command = commands[commandPos];
            //position of the character to check (if it is a coin)
            int[] charPos = ReturnCharPos(row, col, commands, commandPos);
            row = charPos[0];
            col = charPos[1];

            //check if the row or column is wrong
            //adjust the row or col
            if (row < 0 || row > 3 || col < 0 || (col > input[row].Length - 1))               
            {
                wallHits++;
                if (command == 'V')
                {
                    row--;
                }
                else if (command == '^')
                {
                    row++;
                }
                else if (command == '>')
                {
                    col--;
                }
                else if (command == '<')
                {
                    col++;
                }
            }           
            else
            {
                char letter = input[row][col];
                if (letter == '$')
                {
                    coinsCollected++; 
                }                
            }
        }

        //print the result
        Console.WriteLine("Coins collected: {0}", coinsCollected);
        Console.WriteLine("Walls hit: {0}", wallHits);
    }
    public static int[] ReturnCharPos(int row, int col, string commands, int commandPos)
    {
        int[] result = new int[2];
        char command = commands[commandPos];
        switch (command)
        {
            case 'V':
                row++;
                break;
            case '^':
                row--;
                break;
            case '>':
                col++;
                break;
            case '<':
                col--;
                break;
        }
        result[0] = row;
        result[1] = col;

        return result;
    }
}