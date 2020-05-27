using System;
using System.Text;
using System.Threading;
using Ex02.ConsoleUtils;

namespace Concentration
{
    class GameManager
    {
        private Board m_Board;
        private Player m_Player1;
        private Player m_Player2;
        private ePlayersTurn m_PlayersTurn;
        private readonly int r_MaxNumOfPairs;
        private int m_NumOfPairsFounded = 0;

        public GameManager(string i_playerName1, string i_playerName2, string i_height, string i_width)
        {
            m_Player1 = new Player(i_playerName1);
            m_Player2 = new Player(i_playerName2);
            m_Board = new Board(int.Parse(i_height), int.Parse(i_width));
            m_PlayersTurn = ePlayersTurn.Player1;
            r_MaxNumOfPairs = (m_Board.Height * m_Board.Width) / 2;
        }
        
        public void FlipCard(string i_cardCoordinates)
        {
            int col = i_cardCoordinates[0] - 'A';
            int row = i_cardCoordinates[1] - '1';
            m_Board[row, col].IsFlipped = !m_Board[row, col].IsFlipped;
        }
        public string FlipCardRandomAndReturnCardLocation()
        {
            int rndRow, rndCol;
            Random rnd = new Random();

            rndRow = rnd.Next(0,m_Board.Height);
            rndCol = rnd.Next(0, m_Board.Width);

            while (m_Board[rndRow, rndCol].IsFlipped == true)
            {
                if (rndCol < m_Board.Width - 1)
                {
                    rndCol++;
                }
                else if (rndRow < m_Board.Height - 1)
                {
                    rndCol = 0;
                    rndRow++;
                }
                else
                {
                    rndRow=0;
                    rndCol = 0;
                }
            }
            string cardLocation = ((char)('A' + rndCol)).ToString() + (1 + rndRow).ToString();
            FlipCard(cardLocation);
            return cardLocation;
        }

        public bool IsPair(string i_card1Coordinates, string i_card2Coordinates)
        {
            int col1 = i_card1Coordinates[0] - 'A';
            int row1 = i_card1Coordinates[1] - '1';
            int col2 = i_card2Coordinates[0] - 'A';
            int row2 = i_card2Coordinates[1] - '1';

            return (m_Board[row1, col1].Item == m_Board[row2, col2].Item);
        }
        public void SwitchPlayersTurn()
        {
            if (m_PlayersTurn == ePlayersTurn.Player1)
            {
                PlayerTurn = ePlayersTurn.Player2;
            }
            else
            {
                PlayerTurn = ePlayersTurn.Player1;
            }
        }
        public void CardsNotMatchFlipBack(string i_firstCardLocation, string i_secondCardLocation)
        {
                    Thread.Sleep(2000);
                    Screen.Clear();
                    FlipCard(i_firstCardLocation);
                    FlipCard(i_secondCardLocation);
                    SwitchPlayersTurn();
        }
        public void PairWasFounded()
        {
            m_NumOfPairsFounded++;
            if (m_PlayersTurn == ePlayersTurn.Player1)
            {
                m_Player1.Score++;
            }
            else
            {
                m_Player2.Score++;
            }
        }

        public StringBuilder PointsStatusAndWinner()
        {
            StringBuilder msg = new StringBuilder();
            msg.Append(m_Player1.Score.ToString());
            msg.Append(" : ");
            msg.Append(m_Player2.Score.ToString());
            msg.Append(Environment.NewLine);
            if (m_Player1.Score == m_Player2.Score)
            {
                msg.Append("We Have A Tie!");
            }
            else
            {
                msg.Append("The Winner Is: ");
                if (m_Player1.Score > m_Player2.Score)
                {
                    msg.Append(m_Player1.Name);
                }

                else
                {
                    msg.Append(m_Player2.Name);
                }
            }

            return msg;
        }

        public int MaxNumOfPairs
        {
            get { return r_MaxNumOfPairs; }
        }
        public int NumOfPairsFounded
        {
            get { return m_NumOfPairsFounded; }
        }
        public ePlayersTurn PlayerTurn
        {
            get { return m_PlayersTurn; }
            set { m_PlayersTurn = value; }
        }
        public Player Player1
        {
            get { return m_Player1; }
            set { m_Player1 = value; }
        }
        public Player Player2
        {
            get { return m_Player2; }
            set { m_Player2 = value; }
        }
        public Board Board
        {
            get { return m_Board; }
            set { m_Board = value; }
        }


    }
}