using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Console
{
    internal class Menu
    {

        private readonly Statistics statistics;
        private readonly Grid grid;
        private readonly Rules rules;
        public Menu()
        {
            statistics = new Statistics();
            grid = new Grid();
            rules = new Rules(grid);
        }


        public void NewGame()
        {
            Console.Clear();
            var name = Validation.StringValidation("First Player's name: ");
            if(!statistics.IsPlayerExists(name))
            {
                statistics.CreateNewPlayer(name);
            }
                var player1 = statistics.players.FirstOrDefault(p => p.Name == name);

            name = Validation.StringValidation("Second Player's name: ");
            if (!statistics.IsPlayerExists(name))
            {
                statistics.CreateNewPlayer(name);
            }
                var player2 = statistics.players.FirstOrDefault(p => p.Name == name);


            grid.Create();

            while(true)
            {
                grid.Display();
                grid.Insert(grid.CROSS);
                if (rules.CheckGameStatus(player1,player2)) break;
                grid.Display();
                grid.Insert(grid.CIRCLE);
                if (rules.CheckGameStatus(player1,player2)) break;
            }
        }

        public void Stats()
        {
            Console.Clear();
            statistics.ShowStats();
            
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
