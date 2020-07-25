using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsUI
{
    public partial class FormSettings : Form
    {
        private bool m_IsAgainstComputer = true;
        private int m_BoardHight = 4;
        private int m_BoardWidth = 4;

        public FormSettings()
        {
            InitializeComponent();
        }

        private void ButtonAgainstWho_Click(object sender, EventArgs e)
        {
            if (m_ButtonAgainstWho.Text == "Against a Friend")
            {
                m_ButtonAgainstWho.Text = "Against Computer";
                m_TextBoxSecondPlayer.Enabled = true;
                m_TextBoxSecondPlayer.Text = string.Empty;
                m_IsAgainstComputer = false;
            }
            else
            {
                m_ButtonAgainstWho.Text = "Against a Friend";
                m_TextBoxSecondPlayer.Enabled = false;
                m_TextBoxSecondPlayer.Text = "COMPUTER";
                m_IsAgainstComputer = true;
            }
        }

        private void ButtonBoardSize_Click(object sender, EventArgs e)
        {
             m_ButtonBoardSize.Text = nextBoardSize(m_ButtonBoardSize.Text);
        }

        private string nextBoardSize(string currentBoardSize)
        {
            string newBoardSize=string.Empty;

            switch(currentBoardSize)
            {
                case "4 X 4":
                    newBoardSize = "4 X 5";
                    m_BoardHight = 4;
                    m_BoardWidth = 5;
                    break;

                case "4 X 5":
                    newBoardSize = "4 X 6";
                    m_BoardHight = 4;
                    m_BoardWidth = 6;
                    break;

                case "4 X 6":
                    newBoardSize = "5 X 4";
                    m_BoardHight = 5;
                    m_BoardWidth = 4;
                    break;

                case "5 X 4":
                    newBoardSize = "5 X 6";
                    m_BoardHight = 5;
                    m_BoardWidth = 6;
                    break;

                case "5 X 6":
                    newBoardSize = "6 X 4";
                    m_BoardHight = 6;
                    m_BoardWidth = 4;
                    break;

                case "6 X 4":
                    newBoardSize = "6 X 5";
                    m_BoardHight = 6;
                    m_BoardWidth = 5;
                    break;

                case "6 X 5":
                    newBoardSize = "6 X 6";
                    m_BoardHight = 6;
                    m_BoardWidth = 6;
                    break;

                default:
                    newBoardSize = "4 X 4";
                    m_BoardHight = 4;
                    m_BoardWidth = 4;
                    break;
            }

            return newBoardSize;
        }

        private void m_ButtonStart_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormConcentrationGame newGame = new FormConcentrationGame(m_BoardHight, m_BoardWidth,
                m_TextBoxFirstPlayer.Text, m_TextBoxSecondPlayer.Text);
            newGame.ShowDialog();
        }
    }
}
