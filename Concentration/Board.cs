﻿using System;
namespace Concentration
{
    public class Board
    {
        private readonly int r_Height;
        private readonly int r_Width;
        private Card[,] m_Matrix;
        
        public Board(int i_height, int i_width)
        {
            r_Height = i_height;
            r_Width = i_width;
            m_Matrix = new Card[i_height, i_width];
            this.MakeNewGameBoard();
        }

        private void MakeNewGameBoard()
        {
            this.InsertPairsOfItems();
            this.ShuffleCards();
        }

        private void InsertPairsOfItems()
        {
            char ch = 'G';
            bool isFirstRound = true;
            for (int i = 0; i < r_Height; i++)
            {
                for (int j = 0; j < r_Width; j++)
                {
                    m_Matrix[i, j] = new Card(ch);
                    ch++;
                    if (r_Height % 2 == 0)
                    {
                        if (i == r_Height / 2 - 1 && j == r_Width - 1 && isFirstRound)
                        {
                            ch = 'G';
                            isFirstRound = false;
                        }
                    }
                    else
                    {
                        if (i == r_Height / 2 && j == r_Width / 2 - 1 && isFirstRound) 
                        {
                            ch = 'G';
                            isFirstRound = false;
                        }
                    }
                }
            }
        }
        private void ShuffleCards()
        {
            Random rnd = new Random();
            int rndHeightIndex, rndWidthIndex;

            for (int i = 0; i < r_Height; i++)
            {
                for (int j = 0; j < r_Width; j++)
                {
                    rndHeightIndex = rnd.Next(0, r_Height - 1);
                    rndWidthIndex = rnd.Next(0, r_Width - 1);
                    Board.SwapCards(ref m_Matrix[i, j], ref m_Matrix[rndHeightIndex, rndWidthIndex]);
                }
            }
        }

        private static void SwapCards(ref Card o_crd1, ref Card o_crd2)
        {
            Card tmpCard = o_crd1;
            o_crd1 = o_crd2;
            o_crd2 = tmpCard;
        }

        public int Height
        {
            get { return r_Height; }
        }
        public int Width
        {
            get { return r_Width; }
        }
        public Card[,] Matrix
        {
            get { return m_Matrix; }
        }
        public Card this[int i,int j]
        {
            get { return m_Matrix[i,j]; }
            set { m_Matrix[i, j] = value; }
        }
        public class Card
        {
            private readonly char m_Item;
            private bool m_IsFlipped = false;

            public Card(char item)
            {
                m_Item = item;
            }

            public char Item
            {
                get { return m_Item; }
            }

            public bool IsFlipped
            {
                get { return m_IsFlipped; }
                set { m_IsFlipped = value; }
            }

            public void Show()
            {
                Console.Write(m_Item.ToString()); 
            }
        }
    }
}

