using System;

namespace TicTacToe_Console
{
    public static class Grid
    {
        public const int GRID_SIZE = 3;
        public const int CROSS = 1;
        public const int CIRCLE = -1;
        public const int EMPTY = 0;

        public static int[,] table;
        static int currentPlayer = -1;

        public static void Create()
        {
            table = new int[GRID_SIZE, GRID_SIZE];
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    table[i, j] = 0;
                }
            }
        }

        public static void Display()
        {
            Console.Clear();
            Console.WriteLine("    0   1   2 ");
            Console.WriteLine("   ___________");
            for (int i = 0; i < GRID_SIZE; i++)
            {
                Console.WriteLine("  |   |   |   |");
                Console.Write($"{i} |");

                for (int j = 0; j < GRID_SIZE; j++)
                {
                    if (table[i, j] == EMPTY) 
                        Console.Write("   ");
                    else if (table[i, j] == CROSS) 
                        Tools.WriteWithColor(" X ", ConsoleColor.Red);
                    else if (table[i, j] == CIRCLE) 
                        Tools.WriteWithColor(" O ", ConsoleColor.Green);

                    Console.Write("|");
                }
                Console.WriteLine("\n  |___|___|___|");
            }

            Console.WriteLine($"Current player: {(currentPlayer == CROSS ? "O" : "X")}");
        }

        public static void Insert(int player)
        {
            currentPlayer = player;
            while (true)
            {
                int x = Tools.IntValidation("Axis X: ");
                int y = Tools.IntValidation("Axis Y: ");
                if (table[y, x] == 0)
                {
                    table[y, x] = player;
                    break;
                }
                else Console.WriteLine("You cant do this");
            }
        }
    }
}
