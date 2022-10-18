using System;

namespace TicTacToe_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var statistics = new Statistics();
            var menu = new Menu(statistics);
            statistics.players = FileManager<Player>.LoadData("players.json");
            statistics.duels = FileManager<Duel>.LoadData("duels.json");
            char key = default;
            do
            {
                Console.Clear();
                Console.WriteLine("Tic Tac Toe Game\n\n1 - New Game\n2 - Statistics\n3 - Top Players\n4 - Duel Statistics\n7 - Exit Game");
                switch (key = Console.ReadKey().KeyChar)
                {
                    case '1':
                        menu.NewGame();
                        FileManager<Player>.SaveData(statistics.players, "players.json");
                        FileManager<Duel>.SaveData(statistics.duels, "duels.json");
                        break;
                    case '2':
                        menu.Stats();
                        break;
                    case '3':
                        menu.TopStats();
                        break;
                    case '4':
                        menu.DuelStats();
                        break;
                    case '7':
                        break;
                    default:
                        break;
                }
            } while (key != '7');
        }


        

    }
}
