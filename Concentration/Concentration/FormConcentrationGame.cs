using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GameLogic;


namespace WindowsUI
{
    public partial class FormConcentrationGame : Form
    {
        private readonly Color r_FirstPlayerColor = Color.Yellow;
        private readonly Color r_SecondPlayerColor = Color.Blue;
        private ButtonCard[,] m_ButtonMatrix;
        private ButtonCard m_FirstCard, m_SecondCard;
        private GameManager m_GameManager;

        public FormConcentrationGame(int i_BoardHight, int i_BoardWidth,
            string i_FirstPlayerName, string i_SecondPlayerName)
        {
            m_ButtonMatrix = new ButtonCard[i_BoardHight, i_BoardWidth];
            m_GameManager = new GameManager(i_FirstPlayerName, i_SecondPlayerName, i_BoardHight.ToString(), i_BoardWidth.ToString());
            InitializeComponent();
            UpdateBoardButtons();
        }

        private void UpdateBoardButtons()
        {
            for (int i = 0; i < m_GameManager.Board.Height; i++)
            {
                for (int j = 0; j < m_GameManager.Board.Width; j++)
                {
                    string coordinates = ((char)((j) + 'A')).ToString() + (i + 1).ToString();
                    m_ButtonMatrix[i, j] = new ButtonCard(m_GameManager.Board[i, j].Item, coordinates);
                    m_ButtonMatrix[i, j].Size = new Size(80, 80);
                    m_ButtonMatrix[i, j].BackColor = Color.White;
                    m_ButtonMatrix[i, j].ForeColor = m_ButtonMatrix[i, j].BackColor;
                    m_ButtonMatrix[i, j].Text = m_ButtonMatrix[i, j].Letter.ToString();
                    m_ButtonMatrix[i, j].Font = new Font("Webdings", 48, FontStyle.Bold);
                    m_ButtonMatrix[i, j].FlatStyle = FlatStyle.Popup;

                    if (i == 0)
                    {
                        m_ButtonMatrix[0, j].Top = this.Top + 15;
                    }
                    else
                    {
                        m_ButtonMatrix[i, j].Top = m_ButtonMatrix[i - 1, j].Bottom + 15;
                    }
                    if (j == 0)
                    {
                        m_ButtonMatrix[i, 0].Left = this.Left + 15;
                    }
                    else
                    {
                        m_ButtonMatrix[i, j].Left = m_ButtonMatrix[i, j - 1].Right + 15;
                    }

                    this.Controls.Add(m_ButtonMatrix[i, j]);
                    m_ButtonMatrix[i, j].Click += ButtonCard_Click;
                }
            }
        }

        private void ButtonCard_Click(object sender, EventArgs e)
        {
            ButtonCard pressedCard = sender as ButtonCard;
            if (m_FirstCard != null && m_SecondCard != null)
            {
                return;
            }
            openCard(pressedCard);

            if (m_GameManager.IsFirstCard == true)
            {
                m_FirstCard = pressedCard;
            }
            else
            {
                m_SecondCard = pressedCard;
                checkTowCards();
            }
            m_GameManager.IsFirstCard = !m_GameManager.IsFirstCard;
        }

        private void openCard(ButtonCard i_pressedCard)
        {
            i_pressedCard.BackColor = m_GameManager.PlayerTurn == ePlayersTurn.Player1 ? r_FirstPlayerColor : r_SecondPlayerColor;
            i_pressedCard.Enabled = false;
            m_GameManager.FlipCard(i_pressedCard.Coordinates);
        }

        private void closeCards()
        {
            m_GameManager.CardsNotMatchFlipBack(m_FirstCard.Coordinates, m_SecondCard.Coordinates);
            m_FirstCard.BackColor = m_FirstCard.ForeColor;
            m_SecondCard.BackColor = m_SecondCard.ForeColor;
            m_FirstCard.Enabled = true;
            m_SecondCard.Enabled = true;
            m_FirstCard= null;
            m_SecondCard = null;
        }

        private void checkTowCards()
            {
            if (m_GameManager.IsPair(m_FirstCard.Coordinates, m_SecondCard.Coordinates) == true)
            {
                m_GameManager.AddPointTocurrentPlayerAndIncreaseNumOfPairsFounded();
                m_FirstCard = null;
                m_SecondCard = null;
                if(m_GameManager.IsAgainstComputer == true && m_GameManager.PlayerTurn == ePlayersTurn.Player2)
                {
                    Thread.Sleep(750);
                }
            }
            else
            { 
                Thread.Sleep(1000);
                closeCards();
                m_GameManager.SwitchPlayersTurn();
            }
            updateLables();
            while (m_GameManager.IsAgainstComputer == true && m_GameManager.PlayerTurn == ePlayersTurn.Player2&& m_GameManager.IsEndOfGame()==false)
            {
                computerTurn();
            }

            checkEndOfGame();
        }

        private void computerTurn()
        {
            string firstCardLocation = m_GameManager.ChooseCardRandomAndReturnCardLocation();
            m_FirstCard = m_ButtonMatrix[firstCardLocation[1] - '1', firstCardLocation[0] - 'A'];
            openCard(m_FirstCard);
            Thread.Sleep(500);
            string secondCardLocation = m_GameManager.ChooseCardRandomAndReturnCardLocation();
            m_SecondCard = m_ButtonMatrix[secondCardLocation[1] - '1', secondCardLocation[0] - 'A'];
            openCard(m_SecondCard);
            checkTowCards();

            checkEndOfGame();
        }

        private void updateLables()
        {
            if (m_GameManager.PlayerTurn == ePlayersTurn.Player1)
            {
                m_LableCurrentPlayer.Text = string.Format("{0} turn", m_GameManager.Player1.Name);
                m_LableCurrentPlayer.BackColor = r_FirstPlayerColor;
            }
            else
            {
                m_LableCurrentPlayer.Text = string.Format("{0} turn", m_GameManager.Player2.Name);
                m_LableCurrentPlayer.BackColor = r_SecondPlayerColor;
            }
            m_LablePlayerOnePairs.Text = string.Format("{0}: {1} pair's", m_GameManager.Player1.Name, m_GameManager.Player1.Score.ToString());
            m_LablePlayerTowPairs.Text = string.Format("{0}: {1} pair's", m_GameManager.Player2.Name, m_GameManager.Player2.Score.ToString());
        }

        private void checkEndOfGame()
        {
            if (m_GameManager.IsEndOfGame() == true)
            {
                if (MessageBox.Show(m_GameManager.EndOfGameMessage(), "Good Game!",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FormConcentrationGame newGame = new FormConcentrationGame(m_GameManager.Board.Height, m_GameManager.Board.Width,
                m_GameManager.Player1.Name, m_GameManager.Player2.Name);
                    newGame.ShowDialog();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
