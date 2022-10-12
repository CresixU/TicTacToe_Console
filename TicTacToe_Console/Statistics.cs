using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Console
{
    public class Statistics
    {
        public List<Player> players = new List<Player>();

        public void CreateNewPlayer(string name)
        {
            if (name is null) throw new ArgumentNullException("No name.");
            
            players.Add(new Player(name));

        }

        public bool IsPlayerExists(string name) => players.Any(p => p.Name == name);

        public void ShowTopPlayers()
        {
            if (!players.Any<Player>())
            {
                Console.WriteLine("There are no statistics yet");
                return;
            }

            var topPlayers = players.OrderByDescending(p => p.WinRatio).ToList();
            Console.WriteLine($"TOP 10 Players by WinRatio\n{"Name",10} {"Total",10} {"Wins",5} {"Loses",5} Win/Total(%)");
            foreach (var item in topPlayers)
            {
                Console.WriteLine($"{item.Name,10} {item.TotalGames,10} {item.WinGames,5} {item.LoseGames,5} {item.WinRatio,5}%");
            }

        }

        public void ShowPaginatedStats(int page = 0)
        {
            if (!players.Any<Player>())
            {
                Console.WriteLine("There are no statistics yet");
                return;
            }
            Console.Clear();
            if (players.Count >= page * 10)
            {
                int i = 1;
                var list = players.Skip(page*10).Take(10).ToList();
                Console.WriteLine($"Players List\n{"N",-4}{"Name",-15} {"Total",-10} {"Wins",-5} {"Loses",-5} Win/Total(%)");
                foreach (var item in list)
                {
                    Console.WriteLine($"{i,-4}{item.Name,-15} {item.TotalGames,-10} {item.WinGames,-5} {item.LoseGames,-5} {item.WinRatio,-5}%");
                    i++;
                }

                Console.WriteLine($"\n{"<<-- A ",10} Page{page+1} {"D -->>",-10}");
                switch(Console.ReadKey().KeyChar)
                {
                    case 'a':
                        {
                            if (page == 0) break;
                            else
                            {
                                page--;
                                ShowPaginatedStats(page);
                            }
                        }
                        break;
                    case 'd':
                        {
                            page++;
                            ShowPaginatedStats(page);
                        }
                        break;
                    default:
                        break;
                        
                }
            }
        }
    }
}
