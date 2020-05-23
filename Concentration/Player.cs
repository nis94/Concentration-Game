using System;
namespace Concentration
{
    public class Player
    {
        private readonly string m_Name = "computer";
        private int m_Score = 0;
        private string m_FirstFlip;
        private string m_SecondFlip;

        public Player() { }

        public Player(string i_Name)
        {
            m_Name = i_Name;
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

        public string FirstFlip
        {
            get { return m_FirstFlip; }
            set { m_FirstFlip = value; }
        }

        //public string SecondtFlip
        //{
        //    get { return m_SecondtFlip; }
        //    set { m_SecondtFlip = value; }
        //}

    }
}