using System;
namespace Concentration
{
    public class Player
    {
        private readonly string m_Name;
        private int m_Score = 0;
        private bool m_IsActive = false;
        private ePlayerType e_PlayerType = ePlayerType.Computer;
        //private string m_FirstFlip;
        //private string m_SecondFlip;

        public Player()
        { }

        public Player(string i_Name)
        {
            m_Name = i_Name;
            e_PlayerType = ePlayerType.Person;
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