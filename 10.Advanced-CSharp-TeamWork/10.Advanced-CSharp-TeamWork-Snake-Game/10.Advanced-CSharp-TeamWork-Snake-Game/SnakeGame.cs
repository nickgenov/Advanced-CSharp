using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace TeamworkProject
{
    struct Position
    {
        public int row;
        public int col;

        public Position(int x, int y)
        {
            this.row = x;
            this.col = y;
        }
    }

    class SnakeGame
    {
        static void Main()
        {
            Console.Title = "SNAKE - Team Aratoht";
            Console.CursorVisible = false;
            Console.WindowHeight = 30;
            Console.WindowWidth = 60;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            //print title

            Console.SetCursorPosition(0, 0);
            Console.WriteLine(@"     _____  _   _            _  __ ______ ");
            Console.WriteLine(@"    / ____|| \ | |    /\    | |/ /|  ____|");
            Console.WriteLine(@"   | (___  |  \| |   /  \   | ' / | |__   ");
            Console.WriteLine(@"    \___ \ | . ` |  / /\ \  |  <  |  __|  ");
            Console.WriteLine(@"    ____) || |\  | / ____ \ | . \ | |____ ");
            Console.WriteLine(@"   |_____/ |_| \_|/_/    \_\|_|\_\|______|");

            Console.SetCursorPosition(5, 18);
            Console.Write("Use up/down arrow and press enter to make your choice.");
            Console.SetCursorPosition(15, 21);
            Console.Write("Exit");
            Console.SetCursorPosition(15, 20);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("New Game");
            Console.ResetColor();

            //Main menu

            bool inMenu = true;

            while (inMenu)
            {
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input = Console.ReadKey(true);

                    switch (input.Key)
                    {
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.DownArrow:
                            {
                                if (Console.CursorTop == 20)
                                {
                                    Console.SetCursorPosition(15, 20);
                                    Console.Write("New Game");
                                    Console.SetCursorPosition(15, 21);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("Exit");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.SetCursorPosition(15, 21);
                                    Console.Write("Exit");
                                    Console.SetCursorPosition(15, 20);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("New Game");
                                    Console.ResetColor();
                                }
                            }
                            break;
                        case ConsoleKey.Enter:
                            {
                                if (Console.CursorTop == 20)
                                {
                                    Console.Clear();
                                    inMenu = false;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            break;
                        default: break;
                    }
                }
            }

            //Draws board
            Position boardStart = new Position(4, 8);
            Position boardEnd = new Position(25, 45);

            for (int i = boardStart.row; i < boardEnd.row; i++)
            {
                Console.SetCursorPosition(8, i);
                for (int j = boardStart.col; j < boardEnd.col; j++)
                {
                    if (i == 4 || i == 24)
                    {
                        Console.Write("=");
                    }
                    else if (j == 8 || j == 44)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }

            //Random Generator
            Random randomNumberGenerator = new Random();

            //starting snake size
            Queue<Position> snake = new Queue<Position>();

            for (int i = 0; i < 10; i++)
            {
                snake.Enqueue(new Position(boardStart.row + 1, boardStart.col + 1));
            }

            //array to hold the directions
            int direction = 0;

            Position[] directions = new Position[]
            {
            new Position(0, 1), //right
            new Position(0, -1),//left
            new Position(1, 0), //down
            new Position(-1, 0) //up
            };

            //Food - random coordinates for first food
            Position food;
            int foodPushTime;
            do
            {
                food = new Position(randomNumberGenerator.Next(boardStart.row + 1, boardEnd.row - 1), randomNumberGenerator.Next(boardStart.col + 1, boardEnd.col - 1));
                foodPushTime = Environment.TickCount;
            }
            while (snake.Contains(food));

            //Print food 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(food.col, food.row);
            Console.Write("$");
            Console.ResetColor();

            //Obstacle
            List<Position> obsts = new List<Position>();
            for (int i = 0; i < randomNumberGenerator.Next(4, 16); i++)//
            {
                do
                {
                    obsts.Add(new Position(randomNumberGenerator.Next(boardStart.row + 1, boardEnd.row - 1), randomNumberGenerator.Next(boardStart.col + 1, boardEnd.col - 1)));
                }
                while (snake.Contains(obsts[i]) ||
                       (food.row == obsts[i].row && food.col == obsts[i].col));
            }

            //Print obstacles
            foreach (Position rock in obsts)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(rock.col, rock.row);
                Console.Write("@");
                Console.ResetColor();
            }

            //counter for the food eaten
            int foodEatenCount = 0;

            //Main game loop
            while (true)
            {
                //user input check
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input = Console.ReadKey(true);

                    switch (input.Key)
                    {
                        case ConsoleKey.UpArrow: direction = 3; break;
                        case ConsoleKey.DownArrow: direction = 2; break;
                        case ConsoleKey.LeftArrow: direction = 1; break;
                        case ConsoleKey.RightArrow: direction = 0; break;
                        case ConsoleKey.Escape: return;
                        default: break;
                    }
                }
                //where the next element will appear
                Position snakeHead = snake.Last();
                Position newSnakeHead = new Position(snakeHead.row + directions[direction].row, snakeHead.col + directions[direction].col);

                //logic for snake eating itself - game over
                if (snake.Contains(newSnakeHead))
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("The snake passed through itself. Game over.");
                    Console.WriteLine("Score: {0}", CalculateScore(foodEatenCount));
                    return;
                }

                //logic for passing through walls

                if (newSnakeHead.col == boardEnd.col - 1)
                {
                    newSnakeHead.col = boardStart.col + 1;
                }
                if (newSnakeHead.col == boardStart.col)
                {
                    newSnakeHead.col = boardEnd.col - 2;
                }
                if (newSnakeHead.row == boardEnd.row - 1)
                {
                    newSnakeHead.row = boardStart.row + 1;
                }
                if (newSnakeHead.row == boardStart.row)
                {
                    newSnakeHead.row = boardEnd.row - 2;
                }

                //check if snake crashed into an obstacle

                if (obsts.Contains(newSnakeHead))
                {
                    Console.WriteLine("The snake hit an obstacle. Game over.");
                    Console.WriteLine("Score: {0}", CalculateScore(foodEatenCount));
                    return;
                }

                //eat food, spawn new food

                if (newSnakeHead.col == food.col &&
                    newSnakeHead.row == food.row)
                {
                    // feeding the snake
                    do
                    {
                        food = new Position(randomNumberGenerator.Next(boardStart.row + 1, boardEnd.row - 1), randomNumberGenerator.Next(boardStart.col + 1, boardEnd.col - 1));
                        foodEatenCount++;
                    }
                    while (snake.Contains(food) ||
                        obsts.Contains(food));

                    Console.SetCursorPosition(food.col, food.row);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("$");
                    Console.ResetColor();

                }


                snake.Enqueue(newSnakeHead);

                //snake animation draw the new element, delete last element

                Console.SetCursorPosition(newSnakeHead.col, newSnakeHead.row);
                Console.WriteLine("*");

                Position snakeTail = snake.Dequeue();
                Console.SetCursorPosition(snakeTail.col, snakeTail.row);
                Console.Write(" ");

                //game speed 
                Thread.Sleep(150);
            }
        }
        public static int CalculateScore(int foodEatenCount)
        {
            return foodEatenCount * 100;
        }
    }
}