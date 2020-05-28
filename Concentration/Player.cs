using System;

namespace Concentration
{
    internal class Player
    {
        private readonly string m_Name;
        private int m_Score = 0;
        private ePlayerType e_PlayerType = ePlayerType.Computer;

        public Player(string i_Name)
        {
            m_Name = i_Name;
            if (i_Name != "COMPUTER")
            {
                e_PlayerType = ePlayerType.Person;
            }
        }

        public string Name
        {
            get { return m_Name; }
        }

        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }

        public ePlayerType Type
        {
            get { return e_PlayerType; }
            set { e_PlayerType = value; }
        }
    }
}