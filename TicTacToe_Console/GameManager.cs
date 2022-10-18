using System;

namespace TicTacToe_Console
{
    public class GameManager
    {
        public GameManager(Grid grid, Statistics statistics)
        {
            _grid = grid;
            _statistics = statistics;
        }

        private readonly Grid _grid;
        private readonly Statistics _statistics;

        public void Start(Player player1, Player player2)
        {
            while (true)
            {
                _grid.Display();
                _grid.Insert(_grid.CROSS);
                if (CheckGameStatus(player1, player2)) break;
                _grid.Display();
                _grid.Insert(_grid.CIRCLE);
                if (CheckGameStatus(player1, player2)) break;
            }
        }

        public bool CheckGameStatus(Player player1, Player player2)
        {
            if (CheckWinner(_grid.CROSS))
            {
                Console.WriteLine($"Player X has won");
                player1.Win();
                player2.Lose();
                _statistics.AddDuelResults(player1, player2, player1);
                return true;
            }
            if (CheckWinner(_grid.CIRCLE))
            {
                Console.WriteLine($"Player O has won");
                player1.Lose();
                player2.Win();
                _statistics.AddDuelResults(player1, player2, player2);
                return true;
            }
            if (CheckDraw())
            {
                Console.WriteLine($"Draw");
                player1.Draw();
                player2.Draw();
                _statistics.AddDuelResults(player1, player2, null, true);
                return true;
            }
            return false;
        }

        private bool CheckWinner(int player)
        {
            int sum = 0;
            //Horizontal checking
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
            //Vertical checking
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
            //Diagonally \
            for (int j = 0; j < _grid.GRID_SIZE; j++)
            {
                sum += _grid.table[j, j];
                if (sum == player * _grid.GRID_SIZE)
                    return true;
            }
            sum = 0;
            //Diagonally /
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
