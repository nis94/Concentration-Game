using System;
namespace Concentration
{
    public class UI
    {      
        private Player m_player1, m_player2;
        private GameManager m_newGame;
        private Board m_gameBoard;
        private bool m_isEndOfGame = false;

        public void RunMenu()
        {
            Console.WriteLine("Welcome To Concentration Game!");
            getPlayerInfoFromUser(m_player1);
            
            ///////////////////////////////////////////////////////////Check validity
            Console.WriteLine("Press 1 for game against other player\nPress 2 for game against computer");
            string rivalType=Console.ReadLine();
            if(rivalType=="1")
            {
                getPlayerInfoFromUser(m_player2);
            }
            else
            {
                m_player2 = new Player();
            }
            ////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////Check validity
            Console.WriteLine("Please enter the height of the game-board");
            string height = Console.ReadLine();
            Console.WriteLine("Please enter the width of the game-board");
            string width = Console.ReadLine();
            m_gameBoard = new Board(int.Parse(height), int.Parse(width));
            ///////////////////////////////////////////////////////////

            m_newGame=new GameManager(m_player1, m_player2, m_gameBoard);
        }
        public static void getPlayerInfoFromUser(Player player)
        {
            ///////////////////////////////////////////////////////////Check validity
            Console.WriteLine("Please enter player name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName);
            ///////////////////////////////////////////////////////////
           
        }

        public void RunGame()
        {
            while (m_isEndOfGame)
            
                ///Check Validity
                Console.WriteLine("Please enter first card location: ");
                string height = Console.ReadLine();
                ///////////////
                m_newGame.


                ///Check Validity
                Console.WriteLine("Please enter second card location: ");
                string width = Console.ReadLine();
                ///////////////
            }
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
