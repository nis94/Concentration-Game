using System.Windows.Forms;

namespace WindowsUI
{
    partial class FormSettings 
    {
        private Label m_LabelFirstPlayer;
        private TextBox m_TextBoxFirstPlayer;
        private TextBox m_TextBoxSecondPlayer;
        private Button m_ButtonAgainstWho;
        private Button m_ButtonStart;
        private Button m_ButtonBoardSize;
        private Label m_LabelBoardSize;
        private Label m_LableSecondPlayer;

        private void InitializeComponent()
        {
            this.m_LabelFirstPlayer = new System.Windows.Forms.Label();
            this.m_TextBoxFirstPlayer = new System.Windows.Forms.TextBox();
            this.m_TextBoxSecondPlayer = new System.Windows.Forms.TextBox();
            this.m_ButtonAgainstWho = new System.Windows.Forms.Button();
            this.m_ButtonStart = new System.Windows.Forms.Button();
            this.m_ButtonBoardSize = new System.Windows.Forms.Button();
            this.m_LabelBoardSize = new System.Windows.Forms.Label();
            this.m_LableSecondPlayer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_LabelFirstPlayer
            // 
            this.m_LabelFirstPlayer.AutoSize = true;
            this.m_LabelFirstPlayer.Location = new System.Drawing.Point(12, 28);
            this.m_LabelFirstPlayer.Name = "m_LabelFirstPlayer";
            this.m_LabelFirstPlayer.Size = new System.Drawing.Size(124, 17);
            this.m_LabelFirstPlayer.TabIndex = 0;
            this.m_LabelFirstPlayer.Text = "First Player Name:";
            // 
            // m_TextBoxFirstPlayer
            // 
            this.m_TextBoxFirstPlayer.Location = new System.Drawing.Point(174, 28);
            this.m_TextBoxFirstPlayer.Name = "m_TextBoxFirstPlayer";
            this.m_TextBoxFirstPlayer.Size = new System.Drawing.Size(132, 22);
            this.m_TextBoxFirstPlayer.TabIndex = 1;
            // 
            // m_TextBoxSecondPlayer
            // 
            this.m_TextBoxSecondPlayer.Enabled = false;
            this.m_TextBoxSecondPlayer.Location = new System.Drawing.Point(174, 74);
            this.m_TextBoxSecondPlayer.Name = "m_TextBoxSecondPlayer";
            this.m_TextBoxSecondPlayer.Size = new System.Drawing.Size(132, 22);
            this.m_TextBoxSecondPlayer.TabIndex = 4;
            this.m_TextBoxSecondPlayer.Text = "COMPUTER";
            // 
            // m_ButtonAgainstWho
            // 
            this.m_ButtonAgainstWho.Location = new System.Drawing.Point(322, 69);
            this.m_ButtonAgainstWho.Name = "m_ButtonAgainstWho";
            this.m_ButtonAgainstWho.Size = new System.Drawing.Size(147, 27);
            this.m_ButtonAgainstWho.TabIndex = 5;
            this.m_ButtonAgainstWho.Text = "Against a Friend";
            this.m_ButtonAgainstWho.UseVisualStyleBackColor = true;
            this.m_ButtonAgainstWho.Click += new System.EventHandler(this.ButtonAgainstWho_Click);
            // 
            // m_ButtonStart
            // 
            this.m_ButtonStart.BackColor = System.Drawing.Color.ForestGreen;
            this.m_ButtonStart.Location = new System.Drawing.Point(377, 203);
            this.m_ButtonStart.Name = "m_ButtonStart";
            this.m_ButtonStart.Size = new System.Drawing.Size(98, 33);
            this.m_ButtonStart.TabIndex = 8;
            this.m_ButtonStart.Text = "START!";
            this.m_ButtonStart.UseVisualStyleBackColor = false;
            this.m_ButtonStart.Click += new System.EventHandler(this.m_ButtonStart_Click);
            // 
            // m_ButtonBoardSize
            // 
            this.m_ButtonBoardSize.BackColor = System.Drawing.Color.MediumOrchid;
            this.m_ButtonBoardSize.Location = new System.Drawing.Point(26, 149);
            this.m_ButtonBoardSize.Name = "m_ButtonBoardSize";
            this.m_ButtonBoardSize.Size = new System.Drawing.Size(146, 87);
            this.m_ButtonBoardSize.TabIndex = 7;
            this.m_ButtonBoardSize.Text = "4 X 4";
            this.m_ButtonBoardSize.UseVisualStyleBackColor = false;
            this.m_ButtonBoardSize.Click += new System.EventHandler(this.ButtonBoardSize_Click);
            // 
            // m_LabelBoardSize
            // 
            this.m_LabelBoardSize.AutoSize = true;
            this.m_LabelBoardSize.Location = new System.Drawing.Point(12, 116);
            this.m_LabelBoardSize.Name = "m_LabelBoardSize";
            this.m_LabelBoardSize.Size = new System.Drawing.Size(81, 17);
            this.m_LabelBoardSize.TabIndex = 6;
            this.m_LabelBoardSize.Text = "Board Size:";
            // 
            // m_LableSecondPlayer
            // 
            this.m_LableSecondPlayer.AutoSize = true;
            this.m_LableSecondPlayer.Location = new System.Drawing.Point(12, 74);
            this.m_LableSecondPlayer.Name = "m_LableSecondPlayer";
            this.m_LableSecondPlayer.Size = new System.Drawing.Size(145, 17);
            this.m_LableSecondPlayer.TabIndex = 9;
            this.m_LableSecondPlayer.Text = "Second Player Name:";
            // 
            // FormSettings
            // 
            this.AcceptButton = this.m_ButtonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(487, 248);
            this.Controls.Add(this.m_LableSecondPlayer);
            this.Controls.Add(this.m_ButtonBoardSize);
            this.Controls.Add(this.m_ButtonStart);
            this.Controls.Add(this.m_ButtonAgainstWho);
            this.Controls.Add(this.m_TextBoxSecondPlayer);
            this.Controls.Add(this.m_LabelBoardSize);
            this.Controls.Add(this.m_TextBoxFirstPlayer);
            this.Controls.Add(this.m_LabelFirstPlayer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}

