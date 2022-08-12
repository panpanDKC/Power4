using System;
using System.Security.Permissions;
using Puissance_4.Class;

namespace Puissance_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool play = true;

            while (play)
            {
                Console.WriteLine("How many players want to play ?");
            
                var x = Console.ReadLine();
                while ( x == null || x.Length > 1 || !"234".Contains(x))
                {
                    Console.WriteLine();
                    Console.WriteLine("Your answer must be a number between 2 and 4 !");
                    Console.Write(" Try again ==> ");
                
                    x = Console.ReadLine();
                }

                Game party = new Game(x[0]-48);
                party.Play();
            
                Console.WriteLine("Do you want to rematch ?");
                
                Console.Write("--> Press ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("1");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" to play again");
                
                Console.Write("--> Press ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("2");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" to leave");

                string y = Console.ReadLine();
                int nb = Player.GetNumber(y);
                while (nb != 1 && nb !=2)
                {
                    Console.Write("Please choose between ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("1");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" or ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("2");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(" !");
                    y = Console.ReadLine();
                    nb = Player.GetNumber(y);
                }

                if (nb == 2)
                {
                    play = false;
                }
                else
                {
                    Console.Clear();
                }
            }
            
        }
    }
}