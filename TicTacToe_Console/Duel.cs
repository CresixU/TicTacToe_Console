using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe_Console
{
    public class Duel
    {
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public Player Winner { get; set; }
        public bool IsDraw { get; set; }

        public Duel(Player playerOne, Player playerTwo, Player winner, bool isDraw)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
            Winner = winner;
            IsDraw = isDraw;
        }
    }
}
