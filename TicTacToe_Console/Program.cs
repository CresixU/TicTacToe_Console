using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var statistics = new Statistics();
            var menu = new Menu(statistics);
            statistics.players = FileManager.LoadData("players.json");
            while (true)
            {
                Console.WriteLine("Tic Tac Toe Game\n\n1 - New Game\n2 - Statistics\n3 - Top Players\n7 - Exit Game");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        menu.NewGame();
                        break;
                    case '2':
                        menu.Stats();
                        break;
                    case '3':
                        menu.TopStats();
                        break;
                    case '7':
                        FileManager.SaveData(statistics.players, "players.json");
                        menu.Exit();
                        break;
                    default:
                        break;

                }
            }
        }


        

    }
}
