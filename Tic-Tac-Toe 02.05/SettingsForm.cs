using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_02._05
{
    public partial class SettingsForm : Form
    {
        private GameForm gameForm;
        public SettingsForm(GameForm gameForm)
        {
            InitializeComponent();

            playerVsComboBox.Items.Add(Gamer.Bot);
            playerVsComboBox.Items.Add(Gamer.Player);

            playerSymbolComboBox.Items.Add(GameSymbol.X);
            playerSymbolComboBox.Items.Add(GameSymbol.O);

            sizeGameField.Items.Add("3x3");
            sizeGameField.Items.Add("4x4");
            sizeGameField.Items.Add("5x5");
            sizeGameField.Items.Add("10x10");

            this.gameForm = gameForm;
        }

        private void limitedTimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(sender is CheckBox checkBox)
            {
                if(checkBox.Checked)
                {
                    DataTransfer.isEnabledLimitedTime = true;

                    amountOfTime.Visible= true;
                }
                else
                {
                    DataTransfer.isEnabledLimitedTime = false;

                    amountOfTime.Visible= false;
                    amountOfTime.Value = 1;
                }
            }
        }

        private void OkSettingsButton_Click(object sender, EventArgs e)
        {
            DataTransfer.typeAction = TypeAction.Ok;

            string selectedOpponent = playerVsComboBox?.SelectedItem?.ToString();
            if (Enum.TryParse<Gamer>(selectedOpponent, out Gamer opponent)&&selectedOpponent!=null)
            {
                DataTransfer.opponentType = opponent;
            }

            string selectedGameSymbol = playerSymbolComboBox?.SelectedItem?.ToString();
            if (Enum.TryParse<GameSymbol>(selectedGameSymbol, out GameSymbol gameSymbol)&& selectedGameSymbol!=null)
            {
                DataTransfer.gameSymbol = gameSymbol;
            }

            
            if (sizeGameField.SelectedItem != null)
            {
                string[] countCells = sizeGameField.SelectedItem.ToString().Split(new string[] { "x"," " }, StringSplitOptions.RemoveEmptyEntries);
                DataTransfer.gameFieldSize =countCells;
            }

            DataTransfer.isEnabledLearnMode = learnModeCheckBox.Checked ? true : false;

            DataTransfer.isEnabledLimitedTime = limitedTimeCheckBox.Checked ? true : false;

            DataTransfer.amountOfTime = limitedTimeCheckBox.Checked ? amountOfTime.Value.ToString() : "Unlimited time"; // Визначення кількості часу на хід

            Close();
        }

        private void cleanPlaybackHistoryButton_Click(object sender, EventArgs e)
        {
            AllHistoryMoves.ClearHistories(gameForm);
            MessageBox.Show("All histories cleared!","Process succesfull",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
