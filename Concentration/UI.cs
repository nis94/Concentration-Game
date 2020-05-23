using System;
namespace Concentration
{
    class UI
    {
        //Board gameBoard;
        Player player1, player2;
        public static void RunMenu()
        {
            Player player1=null, player2=null;

            Console.WriteLine("Welcome To Concentration Game!");
            getPlayerInfoFromUser(player1);
            
            ///////////////////////////////////////////////////////////Check validity
            Console.WriteLine("Press 1 for game against other player\nPress 2 for game against computer");
            string rivalType=Console.ReadLine();
            if(rivalType=="1")
            {
                getPlayerInfoFromUser(player2);
            }
            else
            {
                player2 = new Player();
            }
            ////////////////////////////////////////////////////////////////////////////




        }
        public static void getPlayerInfoFromUser(Player player)
        {
            Console.WriteLine("Please enter player name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName);
        }





        public static void printBoard(Board brd)
        {
            char ch = 'A';

            Console.Write("     ");
            for (int i = 0; i < brd.Height; i++)
            {
                Console.Write(ch.ToString());
                Console.Write("   ");
                ch++;
            }

            for (int i = 0; i < brd.Height; i++)
            {
                Console.Write(Environment.NewLine);
                Console.Write("   ");
                for (int k = 0; k < brd.Width; k++)
                {
                    Console.Write("====");
                }
                Console.Write("=");
                Console.Write(Environment.NewLine);
                Console.Write((i + 1).ToString());
                Console.Write(" ");
                for (int j = 0; j < brd.Width; j++)
                {
                    Console.Write(" | ");
                    //if (brd.Matrix[i, j].IsFound == true)
                    //{
                    Console.Write(brd.Matrix[i, j].Item.ToString());
                    //}
                    //else
                    //{
                    //    Console.Write(" ");

                    //}
                }
                Console.Write(" |");
            }
            Console.Write(Environment.NewLine);
            Console.Write("   ");
            for (int j = 0; j < brd.Width; j++)
            {
                Console.Write("====");
            }
            Console.Write("=");
        }
    }
}
