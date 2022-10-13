using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Console
{
    public class Grid
    {
        public readonly int GRID_SIZE = 3;
        public readonly int CROSS = 1;
        public readonly int CIRCLE = -1;
        public readonly int EMPTY = 0;

        public int[,] table;
        int currentPlayer = -1;

        public void Create()
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

        public void Display()
        {
            Console.Clear();
            for (int i = 0; i < GRID_SIZE; i++)
            {
                Console.Write("|");
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    if (table[i, j] == EMPTY) Console.Write(" ");
                    else if (table[i, j] == CROSS) Console.Write("X");
                    else if (table[i, j] == CIRCLE) Console.Write("O");
                }
                Console.WriteLine("|");
            }
            
            Console.WriteLine($"Current player: {(currentPlayer == CROSS ? "O" : "X")}");
        }

        public void Insert(int player)
        {
            currentPlayer = player;
            while (true)
            {
                int x = Validation.IntValidation("Axis X: ");
                int y = Validation.IntValidation("Axis Y: ");
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
