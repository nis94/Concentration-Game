using System;
using Ex02.ConsoleUtils;
using System.Threading;
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
            getPlayerInfoFromUser(ref m_player1);

            ///////////////////////////////////////////////////////////Check validity
            Console.WriteLine("Press 1 for game against other player\nPress 2 for game against computer");
            string rivalType = Console.ReadLine();
            if (rivalType == "1")
            {
                getPlayerInfoFromUser(ref m_player2);
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

            m_newGame = new GameManager(m_player1, m_player2, m_gameBoard);
        }

        private static void getPlayerInfoFromUser(ref Player player)
        {
            ///////////////////////////////////////////////////////////Check validity
            Console.WriteLine("Please enter player name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName);
            ///////////////////////////////////////////////////////////

        }

        public void RunGame()
        {
            while (m_isEndOfGame==false)
            {
                printBoard();
                ///Check Validity (check if already flipped. check if valid chars) - if Card1Location == Q ----> Exit 
                Console.WriteLine("Please enter first card location: ");
                string Card1Location = Console.ReadLine();
                ///////////////
                
                m_newGame.flipCard(Card1Location);
                Screen.Clear();
                printBoard();

                ///Check Validity (check if already flipped. check if valid chars) - if Card1Location == Q ----> Exit 
                Console.WriteLine("Please enter second card location: ");
                string Card2Location = Console.ReadLine();
                ///////////////
                m_newGame.flipCard(Card2Location);
                Screen.Clear();
                this.printBoard();
                if (m_newGame.isPair(Card1Location, Card2Location)==false)
                {
                    ////////Can move to GM in one method
                    Thread.Sleep(2000);
                    Screen.Clear();
                    m_newGame.flipCard(Card1Location);
                    m_newGame.flipCard(Card2Location);
                    m_newGame.switchPlayersTurn();
                    ////////////////
                }
                else
                {
                    m_newGame.pairWasFounded();
                }
                

                if(m_newGame.NumOfPairsFounded==m_newGame.MaxNumOfPairs)
                {
                    m_isEndOfGame = true;
                }
                Screen.Clear();
            }
            AnnounceWinnerAndCheckRematch();
        }
        private void AnnounceWinnerAndCheckRematch()
        {
            //PrintEndGameStatus();
            if (/*want rematch*/true)
            {

                RunGame();
            }
            else
            {
                //PrintEndGameStatus();
                ExitGame();
            }
        }
        private void ExitGame()
        {
        
            Console.WriteLine("Thanks For Playing Concentration, See You Next Time (:");
            
        }

        private void printBoard()
        {
            char ch = 'A';

            Console.Write("     ");
            for (int i = 0; i < m_gameBoard.Height; i++)
            {
                Console.Write(ch.ToString());
                Console.Write("   ");
                ch++;
            }

            for (int i = 0; i < m_gameBoard.Height; i++)
            {
                Console.Write(Environment.NewLine);
                Console.Write("   ");
                for (int k = 0; k < m_gameBoard.Width; k++)
                {
                    Console.Write("====");
                }
                Console.Write("=");
                Console.Write(Environment.NewLine);
                Console.Write((i + 1).ToString());
                Console.Write(" ");
                for (int j = 0; j < m_gameBoard.Width; j++)
                {
                    Console.Write(" | ");
                    if (m_gameBoard.Matrix[i, j].IsFlipped == true)
                    {
                        Console.Write(m_gameBoard.Matrix[i, j].Item.ToString());
                    }
                    else
                    {
                        Console.Write(" ");

                    }
                }
                Console.Write(" |");
            }
            Console.Write(Environment.NewLine);
            Console.Write("   ");
            for (int j = 0; j < m_gameBoard.Width; j++)
            {
                Console.Write("====");
            }
            Console.WriteLine("=");
        }
    }
}

