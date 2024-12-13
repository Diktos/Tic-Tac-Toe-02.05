using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Tic_Tac_Toe_02._05.GameHistory;

namespace Tic_Tac_Toe_02._05
{
    public partial class GameHistory : UserControl
    {
        public GameHistory()
        {
            InitializeComponent();
        }

        #region Methods control
        public void AddItem(Cell cell)
        {
            listBox1.Items.Add(cell.ToString());
        }

        public void ClearHistoryItems()
        {
            if (listBox1.Items.Count != 0) 
            {
                listBox1.Items.Clear();
            }
        }
        #endregion
    }
    public class GameHistoryClass
    {
        public List<Cell> gameHistoryList { get; set; } = new List<Cell>();

        private GameHistory gameHistoryControl;

        public GameHistoryClass(GameHistory gameHistoryControl)
        {
            this.gameHistoryControl = gameHistoryControl;
        }

        #region Methods list
        public void AddMove(Cell cell)
        {
            gameHistoryControl.AddItem(cell);
            gameHistoryList.Add(cell);
        }

        public void RemoveMove(Cell cell)
        {
            gameHistoryList.Remove(cell);

            gameHistoryControl.ClearHistoryItems();
            for (int i = 0; i < gameHistoryList.Count; i++)
            {
                gameHistoryControl.AddItem(gameHistoryList[i]);
            }
        }

        public void ClearHistoryMoves()
        {
            gameHistoryControl.ClearHistoryItems();
            gameHistoryList.Clear();
        }
        #endregion
    }

    public static class AllHistoryMoves
    {
        public static List<GameHistoryClass> gameHistories = new List<GameHistoryClass>(); // Вся історія ходів в програмі
        private static string pathToHistoryOfMoves = Directory.GetCurrentDirectory() + "\\Winning histories of bot moves.txt";

        public static void AddGameWinHistory(GameHistoryClass gameHistoryClass)
        {
            gameHistories.Add(gameHistoryClass);
        }

        public static void ClearHistories(GameForm gameForm)
        {
            gameHistories.Clear();
            File.WriteAllText(pathToHistoryOfMoves,"");
            gameForm.GetGameHistory().ClearHistoryItems();
        }

        public static void SaveGamesHistory() // Якщо виграв бот, додаємо цю історію ходів
        {
            string json = JsonConvert.SerializeObject(gameHistories);
            File.WriteAllText(pathToHistoryOfMoves, json);
        }

        public static void ReadGamesHistory()
        {
            string json = File.ReadAllText(pathToHistoryOfMoves);
            gameHistories = JsonConvert.DeserializeObject<List<GameHistoryClass>>(json);
            if (gameHistories == null)
            {
                gameHistories = new List<GameHistoryClass>();
            }
        }
    }
}
