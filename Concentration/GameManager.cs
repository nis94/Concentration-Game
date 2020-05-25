using System;
using System.Text;
using System.Threading;
using Ex02.ConsoleUtils;

namespace Concentration
{
    class GameManager
    {
        private Board m_board;
        private Player m_player1;
        private Player m_player2;
        private ePlayersTurn m_playersTurn;
        private readonly int r_maxNumOfPairs;
        private int m_numOfPairsFounded = 0;

        public GameManager(string playerName1, string playerName2, string height, string width)
        {
            m_player1 = new Player(playerName1);
            m_player2 = new Player(playerName2);
            m_board = new Board(int.Parse(height), int.Parse(width));
            m_playersTurn = ePlayersTurn.Player1;
            r_maxNumOfPairs = (m_board.Height * m_board.Width) / 2;
        }
        public void flipCard(string i_cardCoordinates)
        {
            int col = i_cardCoordinates[0] - 'A';
            int row = i_cardCoordinates[1] - '1';
            m_board.Matrix[row, col].IsFlipped = !m_board.Matrix[row, col].IsFlipped;
        }
        public bool isPair(string i_card1Coordinates, string i_card2Coordinates)
        {
            int col1 = i_card1Coordinates[0] - 'A';
            int row1 = i_card1Coordinates[1] - '1';
            int col2 = i_card2Coordinates[0] - 'A';
            int row2 = i_card2Coordinates[1] - '1';

            return (m_board.Matrix[row1, col1].Item == m_board.Matrix[row2, col2].Item);
        }
        public void switchPlayersTurn()
        {
            if (m_playersTurn == ePlayersTurn.Player1)
            {
                PlayerTurn = ePlayersTurn.Player2;
            }
            else
            {
                PlayerTurn = ePlayersTurn.Player1;
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

        public StringBuilder PointsStatusAndWinner()
        {
            StringBuilder msg = new StringBuilder();
            msg.Append(m_player1.Score.ToString());
            msg.Append(" ");
            msg.Append(m_player2.Score.ToString());
            msg.Append(Environment.NewLine);
            msg.Append("The Winner Is: ");
            if (m_player1.Score == m_player2.Score)
            {
                msg.Append("We Have A Tie!");
            }

            else
            {
                msg.Append("The Winner Is: ");
                if (m_player1.Score > m_player2.Score)
                {
                    msg.Append(m_player1.Name);
                }

                else
                {
                    msg.Append(m_player2.Name);
                }
            }

            return msg;
        }

        public int MaxNumOfPairs
        {
            get { return r_maxNumOfPairs; }
        }
        public int NumOfPairsFounded
        {
            get { return m_numOfPairsFounded; }
        }
        public ePlayersTurn PlayerTurn
        {
            get { return m_playersTurn; }
            set { m_playersTurn = value; }
        }
        public Player Player1
        {
            get { return m_player1; }
            set { m_player1 = value; }
        }
        public Player Player2
        {
            get { return m_player2; }
            set { m_player2 = value; }
        }

    }
}