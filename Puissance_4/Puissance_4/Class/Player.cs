using System;

namespace Puissance_4.Class
{
    public class Player
    {
        private ConsoleColor team;
        public ConsoleColor Team => team;

        private Game party;
        public Game Party => party;

        public Player(ConsoleColor _team, Game _party)
        {
            team = _team;
            party = _party;
        }
        
        public static int GetNumber(string s)
        {
            int res = 0;
            bool ok = true;

            for (int i = 0; i < s.Length && ok; i++)
            {
                if (s[i] >= '0' && s[i] <= '9')
                {
                    res = res * 10 + (s[i] - 48);
                }
                else
                {
                    ok = false;
                }
            }

            if (!ok)
                return -1;
            return res;
        }

        public Tuple<int,int> DropPiece()
        {
            Console.Write("Where do you want to drop your ");
            Console.ForegroundColor = team;
            Console.Write("piece");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" ? ==> ");

            int abcsisse = -1;
            int ordonnée = -1;
            bool isGood = false;

            while (!isGood)
            {
                var x = Console.ReadLine();
                int val = GetNumber(x);
                while ( x == null || (val <= 0 || val > party.Plate.Size))
                {
                    Console.WriteLine();
                    Console.WriteLine("Your answer must be a number between 1 and " + party.Plate.Size + " !");
                    Console.Write(" Try again ==> ");
                
                    x = Console.ReadLine(); 
                    val = GetNumber(x);
                }

                int li = (int) Math.Sqrt(party.Plate.Board.Length)-1;

                while (li >= 0 && party.Plate.Board[li,val-1] != null)
                {
                    li -= 1;
                }

                if (li >= 0)
                {
                    isGood = true;
                    party.Plate.Board[li, val-1] = new Piece(team);
                    abcsisse = val-1;
                    ordonnée = li;
                }
                else
                {
                    Console.Write("You can't drop any pieces here anymore !");
                    Console.Write(" Try again ==> ");
                }
            }

            return new Tuple<int, int>(abcsisse, ordonnée);
        }
    }
}