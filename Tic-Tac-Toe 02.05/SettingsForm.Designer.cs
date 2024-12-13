namespace Tic_Tac_Toe_02._05
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.learnModeCheckBox = new System.Windows.Forms.CheckBox();
            this.limitedTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.playerSymbolComboBox = new System.Windows.Forms.ComboBox();
            this.playerVsComboBox = new System.Windows.Forms.ComboBox();
            this.sizeGameField = new System.Windows.Forms.DomainUpDown();
            this.clearGameHistoriesButton = new System.Windows.Forms.Button();
            this.OkSettingsButton = new System.Windows.Forms.Button();
            this.amountOfTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.amountOfTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(93, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player vs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(93, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Player play";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(93, 192);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Size";
            // 
            // learnModeCheckBox
            // 
            this.learnModeCheckBox.AutoSize = true;
            this.learnModeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.learnModeCheckBox.Location = new System.Drawing.Point(99, 250);
            this.learnModeCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.learnModeCheckBox.Name = "learnModeCheckBox";
            this.learnModeCheckBox.Size = new System.Drawing.Size(209, 29);
            this.learnModeCheckBox.TabIndex = 4;
            this.learnModeCheckBox.Text = "Enable Learn mode ";
            this.learnModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // limitedTimeCheckBox
            // 
            this.limitedTimeCheckBox.AutoSize = true;
            this.limitedTimeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.limitedTimeCheckBox.Location = new System.Drawing.Point(99, 300);
            this.limitedTimeCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.limitedTimeCheckBox.Name = "limitedTimeCheckBox";
            this.limitedTimeCheckBox.Size = new System.Drawing.Size(196, 29);
            this.limitedTimeCheckBox.TabIndex = 5;
            this.limitedTimeCheckBox.Text = "Enable limited time";
            this.limitedTimeCheckBox.UseVisualStyleBackColor = true;
            this.limitedTimeCheckBox.CheckedChanged += new System.EventHandler(this.limitedTimeCheckBox_CheckedChanged);
            // 
            // playerSymbolComboBox
            // 
            this.playerSymbolComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playerSymbolComboBox.FormattingEnabled = true;
            this.playerSymbolComboBox.Location = new System.Drawing.Point(240, 128);
            this.playerSymbolComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.playerSymbolComboBox.Name = "playerSymbolComboBox";
            this.playerSymbolComboBox.Size = new System.Drawing.Size(237, 33);
            this.playerSymbolComboBox.TabIndex = 12;
            this.playerSymbolComboBox.Text = "X";
            // 
            // playerVsComboBox
            // 
            this.playerVsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playerVsComboBox.FormattingEnabled = true;
            this.playerVsComboBox.Location = new System.Drawing.Point(240, 65);
            this.playerVsComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.playerVsComboBox.Name = "playerVsComboBox";
            this.playerVsComboBox.Size = new System.Drawing.Size(237, 33);
            this.playerVsComboBox.TabIndex = 13;
            this.playerVsComboBox.Text = "Bot";
            // 
            // sizeGameField
            // 
            this.sizeGameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sizeGameField.Location = new System.Drawing.Point(240, 192);
            this.sizeGameField.Margin = new System.Windows.Forms.Padding(4);
            this.sizeGameField.Name = "sizeGameField";
            this.sizeGameField.Size = new System.Drawing.Size(239, 28);
            this.sizeGameField.TabIndex = 14;
            this.sizeGameField.Text = "3 x 3";
            // 
            // clearGameHistoriesButton
            // 
            this.clearGameHistoriesButton.BackColor = System.Drawing.Color.IndianRed;
            this.clearGameHistoriesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearGameHistoriesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearGameHistoriesButton.Location = new System.Drawing.Point(99, 379);
            this.clearGameHistoriesButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearGameHistoriesButton.Name = "clearGameHistoriesButton";
            this.clearGameHistoriesButton.Size = new System.Drawing.Size(271, 43);
            this.clearGameHistoriesButton.TabIndex = 16;
            this.clearGameHistoriesButton.Text = "Clear game histories";
            this.clearGameHistoriesButton.UseVisualStyleBackColor = false;
            this.clearGameHistoriesButton.Click += new System.EventHandler(this.cleanPlaybackHistoryButton_Click);
            // 
            // OkSettingsButton
            // 
            this.OkSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OkSettingsButton.Location = new System.Drawing.Point(548, 432);
            this.OkSettingsButton.Margin = new System.Windows.Forms.Padding(4);
            this.OkSettingsButton.Name = "OkSettingsButton";
            this.OkSettingsButton.Size = new System.Drawing.Size(163, 43);
            this.OkSettingsButton.TabIndex = 17;
            this.OkSettingsButton.Text = "OK";
            this.OkSettingsButton.UseVisualStyleBackColor = true;
            this.OkSettingsButton.Click += new System.EventHandler(this.OkSettingsButton_Click);
            // 
            // amountOfTime
            // 
            this.amountOfTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.amountOfTime.Location = new System.Drawing.Point(344, 300);
            this.amountOfTime.Margin = new System.Windows.Forms.Padding(4);
            this.amountOfTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.amountOfTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amountOfTime.Name = "amountOfTime";
            this.amountOfTime.Size = new System.Drawing.Size(135, 28);
            this.amountOfTime.TabIndex = 18;
            this.amountOfTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amountOfTime.Visible = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 516);
            this.Controls.Add(this.amountOfTime);
            this.Controls.Add(this.OkSettingsButton);
            this.Controls.Add(this.clearGameHistoriesButton);
            this.Controls.Add(this.sizeGameField);
            this.Controls.Add(this.playerVsComboBox);
            this.Controls.Add(this.playerSymbolComboBox);
            this.Controls.Add(this.limitedTimeCheckBox);
            this.Controls.Add(this.learnModeCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.amountOfTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox learnModeCheckBox;
        private System.Windows.Forms.CheckBox limitedTimeCheckBox;
        private System.Windows.Forms.ComboBox playerSymbolComboBox;
        private System.Windows.Forms.ComboBox playerVsComboBox;
        private System.Windows.Forms.DomainUpDown sizeGameField;
        private System.Windows.Forms.Button clearGameHistoriesButton;
        private System.Windows.Forms.Button OkSettingsButton;
        private System.Windows.Forms.NumericUpDown amountOfTime;
    }
}