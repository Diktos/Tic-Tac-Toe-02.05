using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_02._05
{
    public class PlayZone
    {
        public  List<Cell>Cells { get; set; }=new List<Cell>();

        private  GameForm gameForm;
        private  PictureBox pictureBox=new PictureBox();
        private  Button undoButton=new Button();
        public GameHistoryClass gameHistoryClass { get; set; }
        public Pen pen;

        // Змінні для процесу гри 
        Random random = new Random();
        Opponent opponent = new Opponent();
        //public bool isPlaying = false;

        public void SetGameFormInstance(GameForm gameFormInstance,PictureBox pictureBoxInstance,Button undoButton)
        {
            gameForm = gameFormInstance;
            pictureBox = pictureBoxInstance;
            gameHistoryClass = new GameHistoryClass(gameFormInstance.GetGameHistory());
            this.undoButton = undoButton;
            pen = new Pen(Color.Blue, 2f);
        }

        public void Distribution() // Розподіл місця
        {
            Cells.Clear(); // Щоб попередні дані видалити,якщо поле зазнавало змін

            Point point0;
            Point point1;
            for (int i = 1; i <= gameForm.currentQuantityLinesV; i++)
            {
                for (int j = 1; j <= gameForm.currentQuantityLinesH; j++)
                {
                    // Знаходження max області клітинки по діагоналі 
                    point1 = new Point((pictureBox.Width/gameForm.currentQuantityLinesH)*j,(pictureBox.Height/gameForm.currentQuantityLinesV)*i);
                    // Знаходження min області клітинки по діагоналі 
                    point0 = new Point(point1.X - gameForm.sizeCell,point1.Y - gameForm.sizeCell); // Знаходження min області клітинки по діагоналі
                    Cells.Add(new Cell(j-1,i-1,point0,point1)); // Додаємо клітинку з її індексами в полі і location  
                }
            }
        }

        public void StartGame()
        {
            ReleaseLocationsField(); // Звільнення комірок у пам'яті
            gameForm.Reload(); // Очищення і розподіл елементів
            AllHistoryMoves.ReadGamesHistory();

            opponent.opponent = DataTransfer.opponentType; 
            opponent.isOpponentMove= (DataTransfer.gameSymbol == GameSymbol.X) ? false : true;
            opponent.firstMoveInGameOpponent = opponent.isOpponentMove;
            opponent.opponentSymbol = (DataTransfer.gameSymbol == GameSymbol.X) ? GameSymbol.O : GameSymbol.X;

            pictureBox.MouseClick += PictureBox_MouseClick;
            undoButton.MouseClick += undoButton_MouseClick; 

            ProcessGame();
        }

        private bool isAllCellOccupied() // Перевірка чи всі ділянки зайняті
        {
            return Cells.All(c => !c.isEmpty);
        }

        private void AnnounceOfTheWinner() // Оголосити переможця
        {
            if (!CheckWinner() && isAllCellOccupied()) // Перевіряємо чи граємo далі
            {
                gameForm.isGameOn = false;
                gameForm.timer.Tick -= gameForm.Timer_Tick; // Вимикаэ таймер, якщо кінець гри
                MessageBox.Show("Friendship won in this game!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (CheckWinner())
            {
                gameForm.isGameOn = false;
                gameForm.timer.Tick -= gameForm.Timer_Tick; // Вимикаэ таймер, якщо кінець гри

                string winner = "";
                if (opponent.IsWineer)
                {
                    if (opponent.opponent == Gamer.Bot)
                    {
                       AllHistoryMoves.AddGameWinHistory(gameHistoryClass);
                       AllHistoryMoves.SaveGamesHistory();
                    }
                   
                    winner = DataTransfer.opponentType.ToString() + $"({opponent.opponentSymbol})";
                }
                else if (!opponent.IsWineer)
                {
                    winner = Gamer.Player.ToString() + $"({DataTransfer.gameSymbol})";
                }
                MessageBox.Show($"The {winner} won!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ProcessGame()
        {
            AnnounceOfTheWinner();

            if (gameForm.isGameOn)
            {
                if (DataTransfer.opponentType == Gamer.Bot)
                {
                    if (!opponent.isOpponentMove ) // хід гравця 
                    {
                        opponent.isOpponentMove = true;
                        
                        if(!opponent.firstMoveInGameOpponent) // Якщо уникнути цього блоку коду,то перший походить бот(умова у події на хід гравця не спрацює)
                        {
                            opponent.isOpponentMove = false;
                            opponent.firstMoveInGameOpponent = true; // Щоб цей блок коду в подальшій роботі не викликався 
                        }
                    }
                    else // хід бота
                    {
                        Cell moveBot = GetMoveBot();
                      
                        DrawingCrossOrZero(moveBot,gameForm.pen);
                        gameHistoryClass.AddMove(moveBot); // Додавання ходу до історії гри і listBox

                        if (isAllCellOccupied())
                        {
                            ProcessGame();
                            return;
                        }
                        if (CheckWinner())
                        {
                            ProcessGame();
                            return;
                        }

                        opponent.isOpponentMove = false;
                    }
                }
                else if (DataTransfer.opponentType == Gamer.Player)
                {
                    if (!opponent.isOpponentMove) // хід гравця 
                    {
                        opponent.isOpponentMove = true;

                        if (!opponent.firstMoveInGameOpponent) // Якщо уникнути цього блоку коду,то умова у події на хід гравця не спрацює
                        {
                            opponent.isOpponentMove = false;
                            opponent.firstMoveInGameOpponent = true; // Щоб цей блок коду в подальшій роботі не викликався 
                        }
                    }
                    else
                    {
                        opponent.isOpponentMove = false;
                    }
                }
            }
            else
            {
                pictureBox.MouseClick -= PictureBox_MouseClick;
                undoButton.MouseClick -= undoButton_MouseClick;
                gameForm.EnableButtonSettings(); // Увімкнути доступ до налаштувань
                gameForm.timer.Tick -= gameForm.Timer_Tick;
            }
        }

        public bool CheckWinner() // Визначення переможця 
        {
            int numberCellsHorOnLine = gameForm.currentQuantityLinesH; // Кількість cells по горизонталі в одній лінії
            int numberCellsVerOnLine = gameForm.currentQuantityLinesV; // Кількість cells по вертикалі в одній лінії
            int numberCellsOnDiagonally = (gameForm.currentQuantityLinesH + gameForm.currentQuantityLinesV) / 2; // Кількість cells по діагоналі в одній лінії

            int amountSymbolsOpponent = 0; // Кількість символів на лінії у противника
            int amountMySymbols = 0;  // Кількість символів на лінії у гравця

            // Знаходження переможця по горизонталі2
            for (int indexCell = 0; indexCell < Cells.Count; indexCell++)
            {
                if (indexCell % numberCellsHorOnLine == 0) // Щоб з нового рядка лічильник співпадінь оновився
                {
                    amountMySymbols = 0;
                    amountSymbolsOpponent = 0;
                }

                if (Cells[indexCell].gameSymbol == DataTransfer.gameSymbol)
                {
                    amountMySymbols++;
                    if (amountMySymbols == numberCellsHorOnLine) // Гравець переміг
                    {
                        opponent.IsWineer = false;
                        return true;
                    }
                }

                else if (Cells[indexCell].gameSymbol == opponent.opponentSymbol)
                {
                    amountSymbolsOpponent++;
                    if (amountSymbolsOpponent == numberCellsHorOnLine)  // Противник переміг
                    {
                        opponent.IsWineer = true;
                        return true;
                    }
                }
            }


            // Знаходження переможця по вертикалі
            int indexToCheck;
            for (int numberLine = 0; numberLine < numberCellsVerOnLine; numberLine++) // Кількість ліній по вертикалі для перевірки
            {
                amountMySymbols = 0;
                amountSymbolsOpponent = 0;
                for (int indexCell = 0; indexCell < Cells.Count; indexCell++)
                {
                    if (indexCell % numberCellsVerOnLine == 0)
                    {
                        indexToCheck = indexCell + numberLine;

                        if (Cells[indexToCheck].gameSymbol == DataTransfer.gameSymbol)
                        {
                            amountMySymbols++;

                            if (amountMySymbols == numberCellsVerOnLine) // Гравець переміг
                            {
                                opponent.IsWineer = false;
                                return true;
                            }
                            if (amountSymbolsOpponent != 0)
                            {
                                break;// На цій лінії вже немає переможця точно (для оптимізації)
                            }
                        }
                        else if (Cells[indexToCheck].gameSymbol == opponent.opponentSymbol)
                        {
                            amountSymbolsOpponent++;

                            if (amountSymbolsOpponent == numberCellsVerOnLine) // Противник переміг
                            {
                                opponent.IsWineer = true;
                                return true;
                            }
                            if(amountMySymbols != 0)
                            {
                                break;// На цій лінії вже немає переможця точно (для оптимізації)
                            }
                        }
                    }
                }
            }

            // Знаходження переможця на одній діагоналі 
            amountMySymbols = 0;
            amountSymbolsOpponent = 0;
            for (int indexCell = 0; indexCell < Cells.Count; indexCell++)
            {
                indexToCheck = 0;
                if (indexCell % (numberCellsOnDiagonally + 1) == 0)
                {
                    indexToCheck = indexCell;
                    if (Cells[indexToCheck].gameSymbol == DataTransfer.gameSymbol)
                    {
                        amountMySymbols++;

                        if (amountMySymbols == numberCellsOnDiagonally) // Гравець переміг
                        {
                            opponent.IsWineer = false;
                            return true;
                        }
                    }
                    else if (Cells[indexToCheck].gameSymbol == opponent.opponentSymbol)
                    {
                        amountSymbolsOpponent++;

                        if (amountSymbolsOpponent == numberCellsOnDiagonally) // Противник переміг
                        {
                            opponent.IsWineer = true;
                            return true;
                        }
                    }
                }
            }

            // Знаходження переможця на другій діагоналі
            amountMySymbols = 0;
            amountSymbolsOpponent = 0;
            for (int indexCell = 0; indexCell < Cells.Count; indexCell++)
            {
                indexToCheck = 0;
                if (indexCell % (numberCellsOnDiagonally - 1) == 0 && indexCell != 0 && indexCell != Cells.Count - 1)
                {
                    indexToCheck = indexCell;
                    if (Cells[indexToCheck].gameSymbol == DataTransfer.gameSymbol)
                    {
                        amountMySymbols++;

                        if (amountMySymbols == numberCellsOnDiagonally) // Гравець переміг
                        {
                            opponent.IsWineer = false;
                            return true;
                        }
                    }
                    else if (Cells[indexToCheck].gameSymbol == opponent.opponentSymbol)
                    {
                        amountSymbolsOpponent++;

                        if (amountSymbolsOpponent == numberCellsOnDiagonally) // Противник переміг
                        {
                            opponent.IsWineer = true;
                            return true;
                        }
                    }
                }
            }
            return false; // Немаэ переможця 
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            Point clickLocation = new Point(e.X, e.Y);
            gameForm.residueSecondsOnMoveLabel.Text = DataTransfer.amountOfTime;
            Cell cell = GetCellFromLocation(clickLocation); // Клітинка і її дані, бо клікнуто в її хатинці
            if (!cell.isEmpty)
            {
                MessageBox.Show("This cell is already occupied!", "Error move",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (!opponent.isOpponentMove)
            {
            cell.isEmpty = false;
            cell.gamer = Gamer.Player;
            cell.gameSymbol = DataTransfer.gameSymbol;
                if (cell != null)
                {
                    DrawingCrossOrZero(cell, gameForm.pen);
                    gameHistoryClass.AddMove(cell); // Додавання ходу до історії гри і listBox
                    if (opponent.opponent == Gamer.Bot) // Якщо бот треба йому сказати, щоб ходив
                    {
                        opponent.isOpponentMove = true; 
                    }
                }
            }
            if (opponent.opponent == Gamer.Player)
            {
                if (opponent.isOpponentMove)
                {
                    cell.isEmpty = false;
                    cell.gamer = Gamer.Player;
                    cell.gameSymbol = opponent.opponentSymbol;
                    if (cell != null)
                    {
                        DrawingCrossOrZero(cell, gameForm.pen);
                        gameHistoryClass.AddMove(cell); // Додавання ходу до історії гри і listBox
                    }
                }
            } 
            ProcessGame();
        }

        private void UnOccupateCell(Cell cellForDeoccupate)
        {
            foreach (Cell cell in Cells)
            {
                if (cell == cellForDeoccupate)
                {
                    cell.isEmpty = true;
                    cell.gameSymbol = GameSymbol.None;
                    break;
                }
            }
        }

        private void undoButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (gameHistoryClass.gameHistoryList.Count >= 2)
            {
                Pen temporaryPen=new Pen(pictureBox.BackColor,2f); // Тимчасовий олівець
                Cell cellForUnOccupate; // TODO 

                for (int i = 0; i < 2; i++)
                {
                    cellForUnOccupate = gameHistoryClass.gameHistoryList[gameHistoryClass.gameHistoryList.Count - 1];
                    DrawingCrossOrZero(cellForUnOccupate, temporaryPen);
                    gameHistoryClass.RemoveMove(cellForUnOccupate);
                    UnOccupateCell(cellForUnOccupate);
                }
                pictureBox.Refresh();
            }
            else
            {
                MessageBox.Show("Removal is not currently available, too few moves", "Deletion error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public Cell GetCellFromLocation(Point location) // Отримання cell за допомогою місця кліку
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                if (location.X >= Cells[i].pointOnField0.X && location.X <= Cells[i].pointOnField1.X &&
                    location.Y >= Cells[i].pointOnField0.Y && location.Y <= Cells[i].pointOnField1.Y)
                {
                    return Cells[i];
                }
            }
            return null;
        }

        private Cell GetMoveBot()
        {
            if (DataTransfer.isEnabledLearnMode)
            {
                foreach (GameHistoryClass history in AllHistoryMoves.gameHistories)
                {
                    int numMatches = 0;
                    for (int j = 0; j < history.gameHistoryList.Count && j<gameHistoryClass.gameHistoryList.Count; j++)
                    {
                        if (history.gameHistoryList[j].Equals(gameHistoryClass.gameHistoryList[j]))
                        {
                            numMatches++;
                        }
                        if (numMatches == gameHistoryClass.gameHistoryList.Count && j+1<history.gameHistoryList.Count)
                        {
                           for(int i=0;i<Cells.Count;i++)  // З існуючим масивом встановлення у правильне місце cell
                           {
                                if (Cells[i].x == history.gameHistoryList[numMatches].x && Cells[i].y == history.gameHistoryList[numMatches].y)
                                {
                                    Cells[i].isEmpty = false;
                                    Cells[i].gamer = DataTransfer.opponentType;
                                    Cells[i].gameSymbol = opponent.opponentSymbol;
                                }
                            }
                            return history.gameHistoryList[numMatches];
                        }
                    }
                }
            }

            Random random = new Random();
            int randomIndex;

            while (true)
            {
                randomIndex = random.Next(0, Cells.Count-1); // Генеруємо випадковий індекс клітинки
                if (Cells[randomIndex].isEmpty)
                {
                    Cells[randomIndex].isEmpty = false;
                    Cells[randomIndex].gamer = DataTransfer.opponentType;
                    Cells[randomIndex].gameSymbol=opponent.opponentSymbol;

                    return Cells[randomIndex]; // Повертаємо випадкову точку
                }
               
            }
        }

        private void DrawingCrossOrZero(Cell cell, Pen pen) // Вивід хрестика чи нулика
        {
            if (GameSymbol.X == cell.gameSymbol)
            {
                gameForm.g.DrawLine(pen, cell.pointOnField0.X+2, cell.pointOnField0.Y+2, cell.pointOnField1.X-2, cell.pointOnField1.Y-2); // TODO
                gameForm.g.DrawLine(pen, cell.pointOnField0.X+2, cell.pointOnField1.Y-2, cell.pointOnField1.X-2, cell.pointOnField0.Y+2);
            }
            else if (cell.gameSymbol == GameSymbol.O)
            {
                gameForm.g.DrawEllipse(pen, cell.pointOnField0.X+2, cell.pointOnField0.Y+2, gameForm.sizeCell-4, gameForm.sizeCell-4);
            }
            pictureBox.Refresh();
        }

        private void ReleaseLocationsField() // Звільнення місць для символів на полі 
        {
            Cells.Where(cell => !cell.isEmpty).ToList().ForEach(cell => cell.isEmpty = true);
        }
    }
}
