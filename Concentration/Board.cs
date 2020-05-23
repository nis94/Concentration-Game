using System;
namespace Concentration
{
    internal class Board
    {
        private readonly int r_height;
        private readonly int r_width;
        private readonly int r_maxNumOfPairs;
        private int m_numOfPairsFound = 0;
        private Card[,] m_board;

        public Board(int height, int width)
        {
            r_height = height;
            r_width = width;
            r_maxNumOfPairs = (height * width) / 2;
            m_board = new Card[height, width];
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
        public int MaxNumOfPairs
        {
            get { return r_maxNumOfPairs; }
        }
        public int NumOfPairsFound
        {
            get { return m_numOfPairsFound; }
            set { m_numOfPairsFound = value; }
        }

        private void makeNewGameBoard()
        {
            this.insertPairsOfItems();
            this.shuffleCards();
        }

        private void insertPairsOfItems()
        {
            char ch = 'A';
            bool isFirstRound = true;
            for (int i = 0; i < r_height; i++)
            {
                for (int j = 0; j < r_width; j++)
                {
                    m_board[i, j] = new Card(ch);
                    ch++;
                    if (i == r_height / 2 - 1 && j == r_width - 1 && isFirstRound)
                    {
                        ch = 'A';
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
                    Board.swapCards(m_board[i, j], m_board[rndHeightIndex, rndWidthIndex]);
                }
            }
        }

        private static void swapCards(Card crd1, Card crd2)
        {
            Card tmpCard = crd1;
            crd1 = crd2;
            crd2 = tmpCard;
        }

        public void printBoard()
        {
            char ch = 'A';

            Console.Write("  ");
            for (int i = 0; i < r_width; i++)
            {

                Console.Write(ch.ToString());
                Console.Write("  ");
                ch++;
            }

            for (int i = 0; i < r_height; i++)
            {
                Console.Write(Environment.NewLine);
                if (i % 2 == 0)
                {
                    Console.Write((i + 1).ToString());
                    Console.Write(" ");
                    for (int j = 0; j < r_width; j++)
                    {
                        Console.Write("|");
                        //if (m_board[i, j].IsFound == true)
                        //{
                            Console.Write(m_board[i, j].Item.ToString());
                        //}
                        //else
                        //{
                        //    Console.Write(" ");

                        //}
                        Console.Write("|");
                    }
                }
                else
                {
                    for (int j = 0; j < r_width * 4; j++)
                    {
                        Console.Write("=");
                    }
                }

            }
            Console.Write(Environment.NewLine);
        }

        private class Card
        {
            private readonly char m_item;
            private bool m_isFound = false;

            public Card(char item)
            {
                m_item = item;
            }

            public char Item
            {
                get { return m_item; }
            }

            public bool IsFound
            {
                get { return m_isFound; }
                set { m_isFound = value; }
            }

        }
    }
}

