using System;

namespace TicTacToe_Console
{
    public class GameManager
    {
        public GameManager(Statistics statistics)
        {
            _statistics = statistics;
        }

        private readonly Statistics _statistics;

        public void Start(Player player1, Player player2)
        {
            while (true)
            {
                Grid.Display();
                Grid.Insert(Grid.CROSS);
                if (CheckGameStatus(player1, player2)) break;
                Grid.Display();
                Grid.Insert(Grid.CIRCLE);
                if (CheckGameStatus(player1, player2)) break;
            }
        }

        public bool CheckGameStatus(Player player1, Player player2)
        {
            if (CheckWinner(Grid.CROSS))
            {
                Console.WriteLine($"Player X has won");
                player1.Win();
                player2.Lose();
                _statistics.AddDuelResults(player1, player2, player1);
                return true;
            }
            if (CheckWinner(Grid.CIRCLE))
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
            for (int i = 0; i < Grid.GRID_SIZE; i++)
            {
                for (int j = 0; j < Grid.GRID_SIZE; j++)
                {
                    sum += Grid.table[i, j];
                    if (sum == player * Grid.GRID_SIZE)
                        return true;
                }
                sum = 0;
            }
            //Vertical checking
            for (int j = 0; j < Grid.GRID_SIZE; j++)
            {
                for (int i = 0; i < Grid.GRID_SIZE; i++)
                {
                    sum += Grid.table[i, j];
                    if (sum == player * Grid.GRID_SIZE)
                        return true;
                }
                sum = 0;
            }
            //Diagonally \
            for (int j = 0; j < Grid.GRID_SIZE; j++)
            {
                sum += Grid.table[j, j];
                if (sum == player * Grid.GRID_SIZE)
                    return true;
            }
            sum = 0;
            //Diagonally /
            int a = 0;
            for (int i = Grid.GRID_SIZE - 1; i >= 0; i--)
            {
                a = Grid.GRID_SIZE - 1 - i;
                sum += Grid.table[i, a];
                if (sum == player * Grid.GRID_SIZE)
                    return true;
            }

            return false;
        }

        private bool CheckDraw()
        {
            for (int i = 0; i < Grid.GRID_SIZE; i++)
            {
                for (int j = 0; j < Grid.GRID_SIZE; j++)
                {
                    if (Grid.table[i, j] == 0) return false;
                }
            }
            return true;
        }
    }
}
