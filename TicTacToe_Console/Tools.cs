using System;
using System.IO;

namespace TicTacToe_Console
{
    public static class Tools
    {
        public static int IntValidation(string text, int min = 0, int max = 3)
        {
            while (true)
            {
                Console.Write(text);
                try
                {
                    int number = int.Parse(Console.ReadLine());
                    if (number < min || number >= max) throw new Exception("Your number is to big or to small");
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
                    if (string.IsNullOrWhiteSpace(output)) throw new Exception("String is empty");
                    if (output.Length > maxLength) throw new Exception($"Text should not be longer than {maxLength} characters");

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
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static void WriteWithColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
