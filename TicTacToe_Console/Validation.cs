using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Console
{
    public static class Validation
    {
        public static int IntValidation(string text, int min = 0, int max = 3)
        {
            while (true)
            {
                Console.Write(text);
                try
                {
                    int number = int.Parse(Console.ReadLine());
                    if (number < min || number >= max) throw new OverflowException("Your number is to big or to small");
                    return number;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("There is no data");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not a number");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static string StringValidation(string text, int maxLength = 10)
        {
            while(true)
            {
                Console.Write(text);
                try
                {
                    string output = Console.ReadLine();
                    if (output == null) throw new ArgumentNullException("String is empty");
                    if (output.Length > maxLength) throw new Exception($"Max length of text should be {maxLength} characters");

                    return output;
                }
                catch (OutOfMemoryException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
