using System;
namespace Concentration
{
    internal class Board
    {
        private readonly int r_height;
        private readonly int r_width;
        private Card[,] m_matrix;
        

        public Board(int height, int width)
        {
            r_height = height;
            r_width = width;
            m_matrix = new Card[height, width];
            this.makeNewGameBoard();
        }
        public int Height
        {
            get { return r_height; }
        }
        public int Width
        {
            get { return r_width; }
        }
        public Card[,] Matrix
        {
            get { return m_matrix; }
        }

        private void makeNewGameBoard()
        {
            this.insertPairsOfItems();
            this.shuffleCards();
        }

        private void insertPairsOfItems()
        {
            char ch = 'G';
            bool isFirstRound = true;
            for (int i = 0; i < r_height; i++)
            {
                for (int j = 0; j < r_width; j++)
                {
                    m_matrix[i, j] = new Card(ch);
                    ch++;
                    if (i == r_height / 2 - 1 && j == r_width - 1 && isFirstRound)
                    {
                        ch = 'G';
                        isFirstRound = !true;
                    }
                }
            }
        }
        private void shuffleCards()
        {
            Random rnd = new Random();
            int rndHeightIndex, rndWidthIndex;

            for (int i = 0; i < r_height; i++)
            {
                for (int j = 0; j < r_width; j++)
                {
                    rndHeightIndex = rnd.Next(0, r_height - 1);
                    rndWidthIndex = rnd.Next(0, r_width - 1);
                    Board.swapCards(ref m_matrix[i, j], ref m_matrix[rndHeightIndex, rndWidthIndex]);
                }
            }
        }

        private static void swapCards(ref Card o_crd1, ref Card o_crd2)
        {
            Card tmpCard = o_crd1;
            o_crd1 = o_crd2;
            o_crd2 = tmpCard;
        }

        private void showBoard()
        {
            /////////////////////////////////////////////$$$ Make it StringBuilder
        char ch = 'A';

        Console.Write("     ");
            for (int i = 0; i<m_gameBoard.Height; i++)
            {
                Console.Write(ch.ToString());
                Console.Write("   ");
                ch++;
            }

            for (int i = 0; i<m_gameBoard.Height; i++)
            {
                Console.Write(Environment.NewLine);
                Console.Write("   ");
                for (int k = 0; k<m_gameBoard.Width; k++)
                {
                    Console.Write("====");
                }
Console.Write("=");
                Console.Write(Environment.NewLine);
                Console.Write((i + 1).ToString());
                Console.Write(" ");
                for (int j = 0; j<m_gameBoard.Width; j++)
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
            for (int j = 0; j<m_gameBoard.Width; j++)
            {
                Console.Write("====");
            }
            Console.WriteLine("=");
        }
        internal class Card
        {
            private readonly char m_item;
            private bool m_isFlipped = false;

            public Card(char item)
            {
                m_item = item;
            }

            public char Item
            {
                get { return m_item; }
            }

            public bool IsFlipped
            {
                get { return m_isFlipped; }
                set { m_isFlipped = value; }
            }

        }
    }
}

