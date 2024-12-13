namespace Tic_Tac_Toe_02._05
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.newGameButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.playersButton = new System.Windows.Forms.Label();
            this.undoButton = new System.Windows.Forms.Button();
            this.TimePassedProgressBar = new System.Windows.Forms.ProgressBar();
            this.TimeOnMoveLabel = new System.Windows.Forms.Label();
            this.residueSecondsOnMoveLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.learnModeLabel = new System.Windows.Forms.Label();
            this.isGameOnLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gameHistoryControl1 = new Tic_Tac_Toe_02._05.GameHistory();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.newGameButton.FlatAppearance.BorderSize = 0;
            this.newGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newGameButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.newGameButton.Location = new System.Drawing.Point(161, 30);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(100, 39);
            this.newGameButton.TabIndex = 0;
            this.newGameButton.Text = "New";
            this.newGameButton.UseVisualStyleBackColor = false;
            this.newGameButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.newGameButton_MouseClick);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.settingsButton.Location = new System.Drawing.Point(267, 30);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(94, 39);
            this.settingsButton.TabIndex = 1;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.aboutButton.FlatAppearance.BorderSize = 0;
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.aboutButton.Location = new System.Drawing.Point(367, 30);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(100, 39);
            this.aboutButton.TabIndex = 2;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = false;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // playersButton
            // 
            this.playersButton.AutoSize = true;
            this.playersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playersButton.Location = new System.Drawing.Point(29, 93);
            this.playersButton.Name = "playersButton";
            this.playersButton.Size = new System.Drawing.Size(182, 20);
            this.playersButton.TabIndex = 3;
            this.playersButton.Text = "<Players information>";
            // 
            // undoButton
            // 
            this.undoButton.BackColor = System.Drawing.Color.DarkOrange;
            this.undoButton.FlatAppearance.BorderSize = 0;
            this.undoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.undoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.undoButton.Location = new System.Drawing.Point(54, 334);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(110, 31);
            this.undoButton.TabIndex = 5;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = false;
            this.undoButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.undoButton_MouseClick);
            // 
            // TimePassedProgressBar
            // 
            this.TimePassedProgressBar.ForeColor = System.Drawing.SystemColors.InfoText;
            this.TimePassedProgressBar.Location = new System.Drawing.Point(192, 404);
            this.TimePassedProgressBar.Maximum = 10;
            this.TimePassedProgressBar.Name = "TimePassedProgressBar";
            this.TimePassedProgressBar.Size = new System.Drawing.Size(189, 23);
            this.TimePassedProgressBar.TabIndex = 6;
            // 
            // TimeOnMoveLabel
            // 
            this.TimeOnMoveLabel.AutoSize = true;
            this.TimeOnMoveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeOnMoveLabel.Location = new System.Drawing.Point(30, 404);
            this.TimeOnMoveLabel.Name = "TimeOnMoveLabel";
            this.TimeOnMoveLabel.Size = new System.Drawing.Size(125, 17);
            this.TimeOnMoveLabel.TabIndex = 7;
            this.TimeOnMoveLabel.Text = "Time for a move";
            // 
            // residueSecondsOnMoveLabel
            // 
            this.residueSecondsOnMoveLabel.AutoSize = true;
            this.residueSecondsOnMoveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.residueSecondsOnMoveLabel.ForeColor = System.Drawing.Color.Red;
            this.residueSecondsOnMoveLabel.Location = new System.Drawing.Point(419, 405);
            this.residueSecondsOnMoveLabel.Name = "residueSecondsOnMoveLabel";
            this.residueSecondsOnMoveLabel.Size = new System.Drawing.Size(170, 18);
            this.residueSecondsOnMoveLabel.TabIndex = 8;
            this.residueSecondsOnMoveLabel.Text = "<seconds remaining>";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(33, 143);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(155, 155);
            this.pictureBox.TabIndex = 9;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // learnModeLabel
            // 
            this.learnModeLabel.AutoSize = true;
            this.learnModeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.learnModeLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.learnModeLabel.Location = new System.Drawing.Point(393, 334);
            this.learnModeLabel.Name = "learnModeLabel";
            this.learnModeLabel.Size = new System.Drawing.Size(169, 18);
            this.learnModeLabel.TabIndex = 10;
            this.learnModeLabel.Text = "Learn mode activated";
            this.learnModeLabel.Visible = false;
            // 
            // isGameOnLabel
            // 
            this.isGameOnLabel.AutoSize = true;
            this.isGameOnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isGameOnLabel.ForeColor = System.Drawing.Color.Magenta;
            this.isGameOnLabel.Location = new System.Drawing.Point(263, 360);
            this.isGameOnLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.isGameOnLabel.Name = "isGameOnLabel";
            this.isGameOnLabel.Size = new System.Drawing.Size(50, 24);
            this.isGameOnLabel.TabIndex = 11;
            this.isGameOnLabel.Text = "Play!";
            this.isGameOnLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(556, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "<Time>";
            // 
            // gameHistoryControl1
            // 
            this.gameHistoryControl1.AutoScroll = true;
            this.gameHistoryControl1.BackColor = System.Drawing.Color.Lime;
            this.gameHistoryControl1.ForeColor = System.Drawing.Color.Transparent;
            this.gameHistoryControl1.Location = new System.Drawing.Point(396, 93);
            this.gameHistoryControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gameHistoryControl1.Name = "gameHistoryControl1";
            this.gameHistoryControl1.Size = new System.Drawing.Size(225, 222);
            this.gameHistoryControl1.TabIndex = 4;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 447);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.isGameOnLabel);
            this.Controls.Add(this.learnModeLabel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.residueSecondsOnMoveLabel);
            this.Controls.Add(this.TimeOnMoveLabel);
            this.Controls.Add(this.TimePassedProgressBar);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.gameHistoryControl1);
            this.Controls.Add(this.playersButton);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.newGameButton);
            this.Name = "GameForm";
            this.Text = "Tic-Tac-Toe";
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Label playersButton;
        private GameHistory gameHistoryControl1;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.ProgressBar TimePassedProgressBar;
        private System.Windows.Forms.Label TimeOnMoveLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label learnModeLabel;
        public System.Windows.Forms.Label residueSecondsOnMoveLabel;
        private System.Windows.Forms.Label isGameOnLabel;
        private System.Windows.Forms.Label label1;
    }
}

