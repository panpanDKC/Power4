using System;
using System.Reflection.Emit;

namespace Puissance_4.Class
{
    public class Grid
    {
        private Piece[,] board;
        public Piece[,] Board => board;

        private int size;
        public int Size => size;

        public Grid(int nb)
        {
            switch (nb)
            {
                case 2 :
                    board = new Piece[7, 7];
                    size = 7;
                    break;
                
                case 3 : 
                    board = new Piece[9, 9];
                    size = 9;
                    break;
                
                case 4 :
                    board = new Piece[13, 13];
                    size = 13;
                    break;
            }
        }

        public Tuple<bool,ConsoleColor> CheckWin(int l, int c)
        {
            int li = l;
            int col = c;
            ConsoleColor playerCol = board[li, col].Belong;
            int res = 0;
            
            
            // check ↗
            for (int i = 1; li-i >= 0 && col+i < Math.Sqrt(board.Length) && board[li-i,col+i] != null && board[li-i,col+i].Belong == playerCol; i++)
            {
                res += 1;
            }
            if (res >= 3)
            {
                return new Tuple<bool, ConsoleColor>(true,playerCol);
            }
            else
            {
                res = 0;
            }
            
            // check →
            for (int i = 1; col+i < Math.Sqrt(board.Length) && board[li,col+i] != null && board[li,col+i].Belong == playerCol; i++)
            {
                res += 1;
            }
            if (res >= 3)
            {
                return new Tuple<bool, ConsoleColor>(true,playerCol);
            }
            else
            {
                res = 0;
            }
            
            // check ↘
            for (int i = 1; li+i < Math.Sqrt(board.Length)&& col+i < Math.Sqrt(board.Length) && board[li+i,col+i] != null  && board[li+i,col+i].Belong == playerCol; i++)
            {
                res += 1;
            }
            if (res >= 3)
            {
                return new Tuple<bool, ConsoleColor>(true,playerCol);
            }
            else
            {
                res = 0;
            }
            
            // check ↓
            for (int i = 1; li+i < Math.Sqrt(board.Length) && board[li+i,col] != null && board[li+i,col].Belong == playerCol; i++)
            {
                res += 1;
            }
            if (res >= 3)
            {
                return new Tuple<bool, ConsoleColor>(true,playerCol);
            }
            else
            {
                res = 0;
            }
            
            // check ↙
            for (int i = 1; li+i < Math.Sqrt(board.Length) && col-i >= 0 && board[li+i,col-i] != null && board[li+i,col-i].Belong == playerCol; i++)
            {
                res += 1;
            }
            if (res >= 3)
            {
                return new Tuple<bool, ConsoleColor>(true,playerCol);
            }
            else
            {
                res = 0;
            }
            
            // check ←
            for (int i = 1; col-i >= 0 && board[li,col-i] != null && board[li,col-i].Belong == playerCol; i++)
            {
                res += 1;
            }
            if (res >= 3)
            {
                return new Tuple<bool, ConsoleColor>(true,playerCol);
            }
            else
            {
                res = 0;
            }
            
            // check ↖
            for (int i = 1; li-i > 0 && col-i >= 0 && board[li-i,col-i] != null && board[li-i,col-i].Belong == playerCol; i++)
            {
                res += 1;
            }
            if (res >= 3)
            {
                return new Tuple<bool, ConsoleColor>(true,playerCol);
            }

            return new Tuple<bool, ConsoleColor>(false,playerCol);
        }

        public void Print()
        {
            Console.Write("╔═════");
            for (int i = 0; i < size-1; i++)
            {
                Console.Write("╦═════");
            }
            Console.WriteLine("╗");

            for (int i = 0; i < Math.Sqrt(board.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(board.Length); j++)
                {
                    Console.Write("║  ");
                    if (Board[i, j] == null)
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Board[i, j].Print(); 
                    }
                    Console.Write("  ");
                }
                Console.WriteLine("║");
                if (i < size-1)
                {
                    Console.Write("╠═════");
                    for (int n = 0; n < size-1; n++)
                    {
                        Console.Write("╬═════");
                    }
                    Console.WriteLine("╣");
                }
            }
            Console.Write("╚═════");
            for (int n = 0; n < size-1; n++)
            {
                Console.Write("╩═════");
            }
            Console.WriteLine("╝");
            
            Console.Write("|  1  ");
            for (int n = 2; n <= size; n++)
            {
                if (n <= 9)
                {
                    Console.Write("|  " + n + "  ");
                }
                else
                {
                    Console.Write("|  " + n + " ");
                }
            }
            Console.WriteLine("|");
        }
    }
}