using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public GameManager(Player player1, Player player2, Board gameBoard)
        {
            m_player1 = player1;
            m_player2 = player2;
            m_Board = gameBoard;
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