﻿using System;
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
        private readonly GameManager _gameManager;

        private Player _player1;
        private Player _player2;

        public Menu(Statistics stats)
        {
            _statistics = stats;
            _grid = new Grid();
            _gameManager = new GameManager(_grid, _statistics);
        }

        public void NewGame()
        {
            Console.Clear();

            _player1 = AssignPlayer("First player name: ",true);
            _player2 = AssignPlayer("Second player name: ",true);

            _grid.Create();

            _gameManager.Start(_player1, _player2);
        }

        public void Stats()
        {
            Console.Clear();
            _statistics.ShowPaginatedStats();
        }

        public void TopStats()
        {
            Console.Clear();
            _statistics.ShowTopPlayers();
        }

        public void DuelStats()
        {
            Console.Clear();

            _player1 = AssignPlayer("First player name: ");
            _player2 = AssignPlayer("Second player name: ");

            _statistics.ShowDuelStats(_player1, _player2);
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        private Player AssignPlayer(string text, bool createNewPlayer = false)
        {
            var name = Tools.StringValidation(text);
            if (!_statistics.IsPlayerExists(name) && createNewPlayer)
            {
                _statistics.CreateNewPlayer(name);
            }
            var player = _statistics.players.FirstOrDefault(p => p.Name == name);

            return player;
        }
    }
}
