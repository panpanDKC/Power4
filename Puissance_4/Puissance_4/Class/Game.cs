using System;
using System.Collections.Generic;

namespace Puissance_4.Class
{
    public class Game
    {
        private Grid plate;
        public Grid Plate => plate;

        private List<Player> playerList;
        public List<Player> PlayerList;

        private Player redPlayer;
        public Player RedPlayer => redPlayer;
        
        private Player yellowPlayer;
        public Player YellowPlayer => yellowPlayer;
        
        private Player greenPlayer;
        public Player GreenPlayer => greenPlayer;
        
        private Player bluePlayer;
        public Player BluePlayer => bluePlayer;

        public Game(int nb)
        {
            plate = new Grid(nb);

            redPlayer = new Player(ConsoleColor.Red, this);
            yellowPlayer = new Player(ConsoleColor.Yellow, this);
            greenPlayer = new Player(ConsoleColor.Green, this);
            bluePlayer = new Player(ConsoleColor.Blue, this);
            
            playerList = new List<Player>{redPlayer,yellowPlayer,greenPlayer,bluePlayer};

            for (int i = 0; i < 4-nb; i++)
            {
                playerList.RemoveAt(playerList.Count-1);
            }
        }

        private bool CheckEnd()
        {
            bool res = false;

            for (int i = 0; !res && i < Math.Sqrt(plate.Board.Length); i++)
            {
                for (int j = 0; !res && j < Math.Sqrt(plate.Board.Length); j++)
                {
                    if (plate.Board[i, j] == null)
                    {
                        res = true;
                    }
                }
            }

            return !res;
        }

        public void Play()
        {
            bool stop = false;
            while (!CheckEnd() && !stop)
            {
                foreach (var player in playerList)
                {
                    if (!stop)
                    {
                        Console.Clear();
                        plate.Print();
                        for (int i = 0; i < Plate.Size && !stop; i++)
                        {
                            for (int j = 0; j < plate.Size && !stop; j++)
                            {
                                if (plate.Board[i, j] != null)
                                {
                                    Tuple<bool, ConsoleColor> stopANDwho = plate.CheckWin(i,j);
                                    stop = stopANDwho.Item1;
                                
                                    if (stop)
                                    {
                                        Console.Write("The ");
                                        Console.ForegroundColor = stopANDwho.Item2;
                                        Console.Write(stopANDwho.Item2.ToString());
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.WriteLine(" player takes the win !");
                                    }
                                }
                            }
                        }

                        if (!stop)
                        {
                            player.DropPiece();
                        }
                    }
                }
            }
        }
    }
}