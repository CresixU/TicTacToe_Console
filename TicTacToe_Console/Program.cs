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
            Menu menu = new Menu();
            while(true)
            {
                Console.WriteLine("Tic Tac Toe Game\n\n1 - New Game\n2 - Statistics\n3 - Exit Game");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        menu.NewGame();
                        break;
                    case '2':
                        menu.Stats();
                        break;
                    case '3':
                        menu.Exit();
                        break;
                    default:
                        break;

                }

            }
        }


        

    }
}
