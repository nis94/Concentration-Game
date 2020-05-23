﻿using System;
namespace Concentration
{
    internal class Board
    {
        private readonly int r_height;
        private readonly int r_width;
        private readonly int r_maxNumOfPairs;
        private int m_numOfPairsFound = 0;
        private Card[,] m_matrix;

        public Board(int height, int width)
        {
            r_height = height;
            r_width = width;
            r_maxNumOfPairs = (height * width) / 2;
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
        public int MaxNumOfPairs
        {
            get { return r_maxNumOfPairs; }
        }
        public int NumOfPairsFound
        {
            get { return m_numOfPairsFound; }
            set { m_numOfPairsFound = value; }
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
                    Board.swapCards(/*ref*/ m_matrix[i, j], /*ref*/ m_matrix[rndHeightIndex, rndWidthIndex]);
                }
            }
        }

        private static void swapCards(/*ref*/ Card o_crd1, /*ref*/ Card o_crd2)
        {
            Card tmpCard = o_crd1;
            o_crd1 = o_crd2;
            o_crd2 = tmpCard;
        }

        internal class Card
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

