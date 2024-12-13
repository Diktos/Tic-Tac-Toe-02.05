using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tic_Tac_Toe_02._05
{
    public partial class GameForm : Form
    {
        public Graphics g;// Яким чином малюєм лінії, фігури
        public Bitmap bitmap; // На чому малюєм
        public Pen pen; // Засіб для малювання

        public int sizeCell = 51;
        public int currentQuantityLinesH = 3; // Для того,щоб правильно виставляти локейшен для контролів по горизонталі
        public int currentQuantityLinesV = 3; // Для того,щоб правильно виставляти локейшен для контролів по вертикалі
        public int prevQuantityLinesH; // Для того,щоб правильно виставляти локейшен для контролів по горизонталі
        public int prevQuantityLinesV; // Для того,щоб правильно виставляти локейшен для контролів по вертикалі

        public PlayZone playZone=new PlayZone(); // Створення об'єкта класу для процесу гри
        public bool isGameOn = false;
        public Timer timer = new Timer();

        public Timer timerTime = new Timer(); // Для поточного часу 
        public GameForm()
        {
            InitializeComponent();

            timerTime.Interval = 1000; // Оновлюємо час кожну секунду
            timerTime.Tick += TimerTime_Tick;
            timerTime.Start();

            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            pen = new Pen(Color.Blue, 2f);

            g = Graphics.FromImage(bitmap);  // Створення об'єкту Graphics для малювання на зображенні
            pictureBox.Image = bitmap; // Передаєм зображення в пікчер бокс
            prevQuantityLinesH = currentQuantityLinesH;
            prevQuantityLinesV = currentQuantityLinesV;
            TimePassedProgressBar.ForeColor = Color.Red;
        }

        private void TimerTime_Tick(object sender, EventArgs e)
        {
            // Встановлюємо поточний час
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(this);
            settingsForm.ShowDialog();
            GameForm_Load(sender, e);
        }

        private void ChangeLocationControl(Control control)
        {
            int x = 0;
            int y = 0;
            if (currentQuantityLinesH >= prevQuantityLinesH && currentQuantityLinesV>=prevQuantityLinesV) // Коли збільшуєм поле
            {
                x = control.Location.X + ((currentQuantityLinesH - prevQuantityLinesH) * sizeCell)/2;
                y = control.Location.Y + (currentQuantityLinesV - prevQuantityLinesV) * sizeCell;
            }

            else if(currentQuantityLinesH < prevQuantityLinesH && currentQuantityLinesV < prevQuantityLinesV) // Коли зменшуєм поле
            {
                x = control.Location.X - ((prevQuantityLinesH - currentQuantityLinesH) * sizeCell)/2;
                y = control.Location.Y - (prevQuantityLinesV - currentQuantityLinesV) * sizeCell;
            }

            control.Location = new Point(x, y);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            string opponentSymbol = (DataTransfer.gameSymbol == GameSymbol.X) ? GameSymbol.O.ToString() : GameSymbol.X.ToString();
            playersButton.Text = $"Player ({DataTransfer.gameSymbol}) vs {DataTransfer.opponentType} ({((opponentSymbol == GameSymbol.X.ToString()) ? GameSymbol.X.ToString() : GameSymbol.O.ToString())})";

            if(!DataTransfer.isEnabledLimitedTime) // Встановлення часу вибраного для ходу
            {
                TimePassedProgressBar.Value = TimePassedProgressBar.Maximum;
                residueSecondsOnMoveLabel.Text = DataTransfer.amountOfTime;
            }
            else
            {
                residueSecondsOnMoveLabel.Text = DataTransfer.amountOfTime;
            }

            learnModeLabel.Visible = DataTransfer.isEnabledLearnMode ? true : false; // Для виводу тексту чи активований навчальний режим

            currentQuantityLinesH = int.Parse(DataTransfer.gameFieldSize.GetValue(0).ToString());
            currentQuantityLinesV = int.Parse(DataTransfer.gameFieldSize.GetValue(1).ToString());

            int sizeFutureFieldH = 0;
            int sizeFutureFieldV = 0;

            // Визначаємо розмір пікчербокса для майбутнього поля і перевизнаємо можливу зону для малювання(bitmap)
            if (currentQuantityLinesH >= prevQuantityLinesH && currentQuantityLinesV >= prevQuantityLinesV)
            {
                sizeFutureFieldH = pictureBox.Size.Width + (currentQuantityLinesH - prevQuantityLinesH)*sizeCell;
                sizeFutureFieldV = pictureBox.Size.Height + (currentQuantityLinesV - prevQuantityLinesV)*sizeCell;
            }
            else if(currentQuantityLinesH < prevQuantityLinesH && currentQuantityLinesV < prevQuantityLinesV)
            {
                sizeFutureFieldH = pictureBox.Size.Width - (prevQuantityLinesH - currentQuantityLinesH) * sizeCell;
                sizeFutureFieldV = pictureBox.Size.Height - (prevQuantityLinesV - currentQuantityLinesV) * sizeCell;
            }

            Size newSize = new Size(sizeFutureFieldH, sizeFutureFieldV);
            pictureBox.Size = newSize;

            // Змінюємо локацію інших елементів, щоб уникнути накладання із-за збільшення поля ходів
            ChangeLocationControl(undoButton);
            ChangeLocationControl(TimeOnMoveLabel);
            ChangeLocationControl(TimePassedProgressBar);
            ChangeLocationControl(residueSecondsOnMoveLabel);
            ChangeLocationControl(gameHistoryControl1);
            ChangeLocationControl(learnModeLabel);
            ChangeLocationControl(isGameOnLabel);

            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            g = Graphics.FromImage(bitmap); 
            pictureBox.Image = bitmap;

            playZone.SetGameFormInstance(this, pictureBox,undoButton); // Для того, щоб інший клас отримав доступ до даних форми
            playZone.Distribution();

            for (int i = 0; i <= currentQuantityLinesH; i++) // Малюємо горизонтальні лінії поля
            {
                g.DrawLine(pen, 0, 1 + (sizeCell * i), (currentQuantityLinesH * sizeCell+2), 1 + (sizeCell * i));

                if (i == currentQuantityLinesH)  // Малюємо вертикальні лінії поля
                {
                    for (int j = 0; j <= currentQuantityLinesV; j++) 
                    {
                        g.DrawLine(pen, 1 + (sizeCell * j), 1, 1 + (sizeCell * j), (currentQuantityLinesV * sizeCell));
                    }
                }
            }

            prevQuantityLinesH = currentQuantityLinesH;
            prevQuantityLinesV = currentQuantityLinesV;
        }

        public void Reload()
        {
            GameForm_Load(this, EventArgs.Empty);
            gameHistoryControl1.ClearHistoryItems();
        }
        
        public void EnableButtonSettings() // Увімкнути кнопку налаштувань і зробити її доступною
        {
            settingsButton.Click += settingsButton_Click;
            isGameOnLabel.Visible = false;
        }

        private void newGameButton_MouseClick(object sender, MouseEventArgs e) // Запуск гри
        {
            if (!isGameOn)
            {
                isGameOn = true;
                isGameOnLabel.Visible=true;
                settingsButton.Click -= settingsButton_Click;

                if (DataTransfer.isEnabledLimitedTime)
                {
                    timer.Interval = 1000;
                    timer.Tick += Timer_Tick;
                    timer.Start();
                    TimePassedProgressBar.Maximum = int.Parse(DataTransfer.amountOfTime);
                }
                playZone.StartGame();
            }
            else
            {
                MessageBox.Show("Сomplete the previous game!", "Game on!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            int secondsRemaining;
            if (int.TryParse(residueSecondsOnMoveLabel.Text, out secondsRemaining))
            {
                if (secondsRemaining <= 1) // Бо 0 секунда також рахуэться
                {
                    GameSymbol opponentSymbol = (DataTransfer.gameSymbol == GameSymbol.X) ? GameSymbol.O : GameSymbol.X;
                    isGameOn = false;
                    residueSecondsOnMoveLabel.Text = DataTransfer.amountOfTime;
                    TimePassedProgressBar.Value = int.Parse(DataTransfer.amountOfTime);
                    timer.Stop();

                    if (DataTransfer.opponentType == Gamer.Bot)
                    {
                        MessageBox.Show($"Time is up, you have lost ;( {DataTransfer.opponentType}({opponentSymbol}) is winner",
                        "The time is up",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    }

                    else if (DataTransfer.opponentType == Gamer.Player)
                    {
                        GameSymbol prevGameSymbolWhoMove = playZone.gameHistoryClass.gameHistoryList
                            [playZone.gameHistoryClass.gameHistoryList.Count - 1].gameSymbol;

                        if (prevGameSymbolWhoMove == DataTransfer.gameSymbol)
                        {
                            MessageBox.Show($"Time is up, you have lost ;( {Gamer.Player}({DataTransfer.gameSymbol}) is winner",
                         "The time is up", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }

                        else if (prevGameSymbolWhoMove == opponentSymbol)
                        {
                            MessageBox.Show($"Time is up, you have lost ;( {DataTransfer.opponentType}({opponentSymbol}) is winner",
                       "The time is up", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    
                    playZone.ProcessGame();
                }
                else
                {
                    secondsRemaining--;
                    TimePassedProgressBar.Value = secondsRemaining;
                    residueSecondsOnMoveLabel.Text = secondsRemaining.ToString();
                }
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (isGameOn)
            {
               
                // Коли після початку гри клікнуто в якусь клітинку викличеться інша подія, за допомогою якої
                // відбудеться подальший процес гри 
            }
        }

        private void undoButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (isGameOn)
            {
                if (DataTransfer.isEnabledLimitedTime)
                {
                    TimePassedProgressBar.Value = int.Parse(DataTransfer.amountOfTime);
                    residueSecondsOnMoveLabel.Text = DataTransfer.amountOfTime;
                }
            }
        }
        public GameHistory GetGameHistory()
        {
            return gameHistoryControl1;
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This game was created by Daniel Chakov. Thank you for being with us!","Creator",
                MessageBoxButtons.OK, MessageBoxIcon.Information); // Дякую, що ви з нами!
        }
    }
}
