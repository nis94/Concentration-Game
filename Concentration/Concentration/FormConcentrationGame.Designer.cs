using GameLogic;
using System.Windows.Forms;

namespace WindowsUI
{
    partial class FormConcentrationGame
    {
        private System.Windows.Forms.Label m_LablePlayerOnePairs;
        private System.Windows.Forms.Label m_LablePlayerTowPairs;
        private System.Windows.Forms.Label m_LableCurrentPlayer;

        private void InitializeComponent()
        {

            this.m_LablePlayerOnePairs = new System.Windows.Forms.Label();
            this.m_LablePlayerTowPairs = new System.Windows.Forms.Label();
            this.m_LableCurrentPlayer = new System.Windows.Forms.Label();

            // 
            // m_LableCurrentPlayer
            // 
            this.m_LableCurrentPlayer.AutoSize = true;
            this.m_LableCurrentPlayer.Name = "m_LableCurrentPlayer";
            this.m_LableCurrentPlayer.Size = new System.Drawing.Size(150, 17);
            this.m_LableCurrentPlayer.Left = this.Left + 15;
            this.m_LableCurrentPlayer.Top = this.Top +(95*m_GameManager.Board.Height)+5;
            this.m_LableCurrentPlayer.TabIndex = 4;
            m_LableCurrentPlayer.Text = string.Format("{0} turn", m_GameManager.Player1.Name);
            m_LableCurrentPlayer.BackColor = r_FirstPlayerColor;
            //
            // m_LablePlayerOnePairs
            // 
            this.m_LablePlayerOnePairs.AutoSize = true;
           this.m_LablePlayerOnePairs.BackColor = r_FirstPlayerColor;
            this.m_LablePlayerOnePairs.Left = this.Left + 15;
            this.m_LablePlayerOnePairs.Top = m_LableCurrentPlayer.Bottom + 10;
            this.m_LablePlayerOnePairs.Name = "PlayerOnePairs";
            this.m_LablePlayerOnePairs.Size = new System.Drawing.Size(100, 17);
            this.m_LablePlayerOnePairs.TabIndex = 2;
            this.m_LablePlayerOnePairs.Text = string.Format("{0}: {1} pair's", this.m_GameManager.Player1.Name, this.m_GameManager.Player1.Score.ToString());
            // 
            // m_LablePlayerTowPairs
            // 
            this.m_LablePlayerTowPairs.AutoSize = true;
            this.m_LablePlayerTowPairs.BackColor = r_SecondPlayerColor;
            this.m_LablePlayerTowPairs.Left = this.Left + 15;
            this.m_LablePlayerTowPairs.Top = m_LablePlayerOnePairs.Bottom+10;
            this.m_LablePlayerTowPairs.Name = "m_LablePlayerTowPairs";
            this.m_LablePlayerTowPairs.Size = new System.Drawing.Size(55, 17);
            this.m_LablePlayerTowPairs.TabIndex = 1;
            this.m_LablePlayerTowPairs.Text = string.Format("{0}: {1} pair's", this.m_GameManager.Player2.Name, this.m_GameManager.Player2.Score.ToString());

            // 
            // FormConcentrationGame
            // 
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximizeBox = false;
            this.Size = new System.Drawing.Size((m_GameManager.Board.Width * 100)+15, (m_GameManager.Board.Height * 100) + 100);
            this.Controls.Add(this.m_LableCurrentPlayer);
            this.Controls.Add(this.m_LablePlayerOnePairs);
            this.Controls.Add(this.m_LablePlayerTowPairs);
            this.Name = "FormConcentrationGame";
            this.Text = "Concentration";
            // this.ResumeLayout(false);
            // this.PerformLayout();

        }
    }
}