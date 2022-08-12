using System;
using System.Text;

namespace Puissance_4.Class
{
    public class Piece
    {
        private ConsoleColor belong;

        public ConsoleColor Belong => belong;

        public char Graph;

        public Piece()
        {
            belong = ConsoleColor.White;
            Graph = '⬤';
        }

        public Piece(ConsoleColor _belong)
        {
            belong = _belong;
            Graph = '0';
        }

        public void Print()
        {
            Console.ForegroundColor = Belong;
            Console.Write(Graph);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}