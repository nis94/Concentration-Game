using System;
using System.Threading;
using Ex02.ConsoleUtils;

namespace Concentration
{
    class GameManager
    {
        private Board m_Board;
        private Player m_player1;
        private Player m_player2;
        private ePlayersTurn m_playersTurn;
        private readonly int r_maxNumOfPairs;
        private int m_numOfPairsFounded = 0;

        public GameManager(string playerName1, string playerName2, string height, string width)
        {
            m_player1 = new Player(playerName1);
            m_player2 = new Player(playerName2);
            m_Board = new Board(height, width);
            m_playersTurn = ePlayersTurn.Player1;
            r_maxNumOfPairs = (gameBoard.Height * gameBoard.Width) / 2;
        }
        public void flipCard(string i_cardCoordinates)
        {
            int col = i_cardCoordinates[0] - 'A';
            int row = i_cardCoordinates[1] - '1';
            m_Board.Matrix[row, col].IsFlipped = !m_Board.Matrix[row, col].IsFlipped;
        }
        public bool isPair(string i_card1Coordinates, string i_card2Coordinates)
        {
            int col1 = i_card1Coordinates[0] - 'A';
            int row1 = i_card1Coordinates[1] - '1';
            int col2 = i_card2Coordinates[0] - 'A';
            int row2 = i_card2Coordinates[1] - '1';

            return (m_Board.Matrix[row1, col1].Item == m_Board.Matrix[row2, col2].Item);
        }
        public void switchPlayersTurn()
        {
            if (m_playersTurn == ePlayersTurn.Player1)
            {
                m_playersTurn = ePlayersTurn.Player2;
            }
            else
            {
                m_playersTurn = ePlayersTurn.Player1;
            }
        }
        public void cardsNotMatch(string firstCardLocation, string secondCardLocation)
        {
                    Thread.Sleep(2000);
                    Screen.Clear();
                    flipCard(firstCardLocation);
                    flipCard(secondCardLocation);
                    switchPlayersTurn();
        }
        public void pairWasFounded()
        {
            m_numOfPairsFounded++;
            if (m_playersTurn == ePlayersTurn.Player1)
            {
                m_player1.Score++;
            }
            else
            {
                m_player2.Score++;
            }
        }



        public int MaxNumOfPairs
        {
            get { return r_maxNumOfPairs; }
        }
        public int NumOfPairsFounded
        {
            get { return m_numOfPairsFounded; }
        }

    }
}