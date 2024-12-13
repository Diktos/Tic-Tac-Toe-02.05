using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_02._05
{
    public class Opponent
    {
        public Gamer opponent { get; set; } = Gamer.Bot;
        public bool isOpponentMove { get; set; } = false;
        public bool firstMoveInGameOpponent { get; set; }
        public GameSymbol opponentSymbol { get; set; }
        public bool IsWineer { get; set; } = false;
    }
    public enum TypeAction
    {
        Ok,
        Cancel
    };
    public enum Gamer
    {
        Player,
        Bot
    };
    public enum GameSymbol
    {
        None,
        X,
        O
    };
    public static class DataTransfer
    {
        public static TypeAction typeAction { get; set; } = TypeAction.Cancel;
        public static Gamer opponentType { get; set; } = Gamer.Bot;
        public static GameSymbol gameSymbol { get; set; } = GameSymbol.X;
        public static string[] gameFieldSize { get; set; } = new string[2] {"3","3"};
        public static bool isEnabledLearnMode { get; set; }=false;
        public static bool isEnabledLimitedTime { get; set; } = false;
        public static string amountOfTime { get; set; } = "Unlimited time";
    }   
}
