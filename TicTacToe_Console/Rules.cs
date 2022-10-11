using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Console
{
    internal class Rules
    {
        public Rules(Grid grid)
        {
            _grid = grid;
        }

        private readonly Grid _grid;

        public bool CheckGameStatus(Player player1, Player player2)
        {
            if (CheckWinner(_grid.CROSS))
            {
                Console.WriteLine($"Player X won");
                player1.Win();
                player2.Lose();
                return true;
            }
            if (CheckWinner(_grid.CIRCLE))
            {
                Console.WriteLine($"Player O won");
                player1.Lose();
                player2.Win();
                return true;
            }
            if (CheckDraw())
            {
                Console.WriteLine($"Draw");
                player1.Draw();
                player2.Draw();
                return true;
            }
            return false;
        }

        private bool CheckWinner(int player)
        {
            int sum = 0;
            //Poziomo
            for (int i = 0; i < _grid.GRID_SIZE; i++)
            {
                for (int j = 0; j < _grid.GRID_SIZE; j++)
                {
                    sum += _grid.table[i, j];
                    if (sum == player * _grid.GRID_SIZE)
                        return true;
                }
                sum = 0;
            }
            //Pionowo
            for (int j = 0; j < _grid.GRID_SIZE; j++)
            {
                for (int i = 0; i < _grid.GRID_SIZE; i++)
                {
                    sum += _grid.table[i, j];
                    if (sum == player * _grid.GRID_SIZE)
                        return true;
                }
                sum = 0;
            }
            //Na skos
            for (int j = 0; j < _grid.GRID_SIZE; j++)
            {
                sum += _grid.table[j, j];
                if (sum == player * _grid.GRID_SIZE)
                    return true;
            }
            sum = 0;
            //Na skos 2
            int a = 0;
            for (int i = _grid.GRID_SIZE - 1; i >= 0; i--)
            {
                a = _grid.GRID_SIZE - 1 - i;
                sum += _grid.table[i, a];
                if (sum == player * _grid.GRID_SIZE)
                    return true;
            }

            return false;
        }

        private bool CheckDraw()
        {
            for (int i = 0; i < _grid.GRID_SIZE; i++)
            {
                for (int j = 0; j < _grid.GRID_SIZE; j++)
                {
                    if (_grid.table[i, j] == 0) return false;
                }
            }
            return true;
        }
    }
}
