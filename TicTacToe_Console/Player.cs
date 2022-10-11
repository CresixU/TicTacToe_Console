using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Console
{
    internal class Player
    {
        public string Name { get; set; }
        public int TotalGames { get; set; }
        public int WinGames { get; set; }
        public int LoseGames { get; set; }
        public int DrawGames { get; set; }
        public int WinRatio
        {
            get
            {
                if(TotalGames!=0) 
                    return WinGames/TotalGames * 100;
                return 0;
            }
            set { _winRatio = value; } 
        }
        private int _winRatio;

        public Player(string name)
        {
            Name = name;
            WinGames = 0;
            LoseGames = 0;
            DrawGames = 0;
            WinRatio = 0;
        }

        public void Win()
        {
            TotalGames++;
            WinGames++;
        }

        public void Lose()
        {
            TotalGames++;
            LoseGames++;
        }

        public void Draw()
        {
            TotalGames++;
            DrawGames++;
        }

    }

}
