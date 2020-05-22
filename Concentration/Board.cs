namespace Concentration
{
    internal class Concentration
    {
        private class Board
        {
            private readonly int m_height; //@ prefix r_ ?
            private readonly int m_width; //@ prefix r_ ?
            private Card[,] m_board;
            private int m_openPairsCounter;

            public int Height
            {
                get { return m_height; }
            }



            private class Card
            {
                private readonly object m_item; //@ use object? 
                private bool m_isFound;
                
                
                public object Item
                {
                    get { return m_item; }
                }
                public bool Found
                {
                    get { return m_isFound; }
                    set { m_isFound = value; }
                   
                }
                
            }




            private void printBoard()
            {
                foreach (char ch in m_board)
                {

                }
            }
        }
    }
}
