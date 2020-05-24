using System;
using Ex02.ConsoleUtils;

namespace Concentration
{
    public class UI
    {
        //private Player m_player1, m_player2;
        // private GameManager m_newGame;
        //private Board m_gameBoard;
        //private bool m_isEndOfGame = false;

        public static void RunMenu()
        {
            Console.WriteLine("Welcome To Concentration Game!");
            // getPlayerInfoFromUser(ref m_player1);

            ///////////////////////////////////////////////////////////Check validity
            Console.WriteLine("Press 1 for game against other player\nPress 2 for game against computer");
            string rivalType = Console.ReadLine();
            if (rivalType == "1")
            {
                //        getPlayerInfoFromUser(ref m_player2);
            }
            else
            {

            }
            ////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////Check validity
            Console.WriteLine("Please enter the height of the game-board");
            string height = Console.ReadLine();
            Console.WriteLine("Please enter the width of the game-board");
            string width = Console.ReadLine();
            //        m_gameBoard = new Board(int.Parse(height), int.Parse(width));
            ///////////////////////////////////////////////////////////

            //     m_newGame = new GameManager(m_player1, m_player2, m_gameBoard);
        }

        private static void getPlayerInfoFromUser(ref Player player)
        {
            ///////////////////////////////////////////////////////////Check validity
            Console.WriteLine("Please enter player name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName);
            ///////////////////////////////////////////////////////////

        }

        public static string GetPlayerName()
        {
            Console.WriteLine("Please enter player name: ");
            string playerName = Console.ReadLine();
            //$$$$Check valid name
            return playerName;
        }

        public static string GetCardLocation()
        {
            ///Check Validity (check if already flipped. check if valid chars) - if Card1Location == Q ----> Exit 
            Console.WriteLine("Please enter card location: ");
            string cardLocation = Console.ReadLine();
            return cardLocation;
        }



        public static void AnnounceWinnerAndCheckRematch()
        {
            //PrintEndGameStatus();
            if (/*want rematch*/true)
            {
                //
            }
            else
            {
                //PrintEndGameStatus();
                //15 : 0
                //The winner is Liran
                ExitGame();
            }
        }
        private static void ExitGame()
        {

            Console.WriteLine("Thanks For Playing Concentration, See You Next Time (:");

        }

        public static void PrintBoard()
        {
            Screen.Clear();
            //Call Board.Show()

        }
    }
}


