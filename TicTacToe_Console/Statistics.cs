using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Console
{
    internal class Statistics
    {
        public List<Player> players = new List<Player>();

        public void CreateNewPlayer(string name)
        {
            if (name is null) throw new ArgumentNullException("No name.");
            
            players.Add(new Player(name));

        }

        public bool IsPlayerExists(string name) => players.Any(p => p.Name == name);

        public void ShowStats()
        {
            if (!players.Any<Player>())
            {
                Console.WriteLine("There are no statistics yet");
                return;
            }

            Console.WriteLine($"Players List\n{"Name",10} {"Total",10} {"Wins",5} {"Loses",5} Win/Total(%)");
            foreach (var item in players)
            {
                Console.WriteLine($"{item.Name,10} {item.TotalGames,10} {item.WinGames,5} {item.LoseGames,5} {item.WinRatio,5}%");
            }
        }
    }
}
