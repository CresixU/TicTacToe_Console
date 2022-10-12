using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Console
{
    internal class Menu
    {

        private readonly Statistics _statistics;
        private readonly Grid _grid;
        private readonly Rules _rules;
        public Menu(Statistics stats)
        {
            _statistics = stats;
            _grid = new Grid();
            _rules = new Rules(_grid);
        }


        public void NewGame()
        {
            Console.Clear();
            var name = Validation.StringValidation("First Player's name: ");
            if(!_statistics.IsPlayerExists(name))
            {
                _statistics.CreateNewPlayer(name);
            }
            var player1 = _statistics.players.FirstOrDefault(p => p.Name == name);

            name = Validation.StringValidation("Second Player's name: ");
            if (!_statistics.IsPlayerExists(name))
            {
                _statistics.CreateNewPlayer(name);
            }
            var player2 = _statistics.players.FirstOrDefault(p => p.Name == name);


            _grid.Create();

            while(true)
            {
                _grid.Display();
                _grid.Insert(_grid.CROSS);
                if (_rules.CheckGameStatus(player1,player2)) break;
                _grid.Display();
                _grid.Insert(_grid.CIRCLE);
                if (_rules.CheckGameStatus(player1,player2)) break;
            }
        }

        public void Stats()
        {
            Console.Clear();
            _statistics.ShowStats();
        }

        public void TopStats()
        {
            Console.Clear();
            _statistics.ShowTopPlayers();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
