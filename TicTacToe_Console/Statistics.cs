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
        public List<Duel> duels = new List<Duel>(); 

        public void CreateNewPlayer(string name)
        {
            if (name is null) throw new ArgumentNullException("No name.");
            
            players.Add(new Player(name));

        }

        public void AddDuelResults(Player p1, Player p2, Player winner, bool isDraw = false)
        {
            if (p1 is null || p2 is null) throw new Exception("Duel failed");
            if(winner is null) isDraw = true;
            duels.Add(new Duel(p1, p2, winner, isDraw));
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

        public void ShowDuelStats(Player p1, Player p2)
        {
            var togetherGames = 
                duels.Where(d => 
                ((d.PlayerOne.Name == p1.Name) && (d.PlayerTwo.Name == p2.Name)) || 
                ((d.PlayerTwo.Name == p1.Name) && (d.PlayerOne.Name == p2.Name)))
                .ToList();

            var numberOfGames = togetherGames.Count;

           var numberOfGamesPlayerOneWin = togetherGames.Where(d => d.IsDraw==false)
                .ToList()
                .Where(d => d.Winner.Name == p1.Name)
                .ToList()
                .Count;

           var numberOfGamesPlayerTwoWin = togetherGames
                .Where(d => d.IsDraw == false).ToList()
                .Where(d => d.Winner.Name == p2.Name).ToList()
                .Count; 

            var numberOfGamesDraw = togetherGames.Where(d => d.IsDraw==true).ToList().Count;

            const int FirstColWidth = 20;
            const int SecondColWidth = 15;

            int numberOfGamesPlayerOneLose = numberOfGames - numberOfGamesDraw - numberOfGamesPlayerOneWin;
            int numberOfGamesPlayerTwoLose = numberOfGames - numberOfGamesDraw - numberOfGamesPlayerTwoWin;

            var playerOneWinRatio = numberOfGamesPlayerOneWin / numberOfGames * 100;
            var playerTwoWinRatio = numberOfGamesPlayerTwoWin / numberOfGames * 100;

            Console.WriteLine($"Statistics for: {p1.Name} vs {p2.Name}");
            Console.WriteLine($"{"",FirstColWidth} {p1.Name,SecondColWidth} {p2.Name,SecondColWidth}");
            Console.WriteLine($"{"Total together games: ",FirstColWidth} {numberOfGames,SecondColWidth} {numberOfGames,SecondColWidth}");
            Console.WriteLine($"{"Wins",FirstColWidth} {numberOfGamesPlayerOneWin,SecondColWidth} {numberOfGamesPlayerTwoWin,SecondColWidth}");
            Console.WriteLine($"{"Loses",FirstColWidth} {numberOfGamesPlayerOneLose,SecondColWidth} {numberOfGamesPlayerTwoLose,SecondColWidth}");
            Console.WriteLine($"{"Draws",FirstColWidth} {numberOfGamesDraw,SecondColWidth} {numberOfGamesDraw,SecondColWidth}");
            Console.WriteLine($"{"% of win games",FirstColWidth} {playerOneWinRatio+"%",SecondColWidth} {playerTwoWinRatio+"%",SecondColWidth}");
        }

    }
}
