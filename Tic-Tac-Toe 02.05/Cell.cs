using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_02._05
{
    [Serializable]
    public class Cell
    {
        public int x; // Порядок клітинки на полі по x
        public int y; // Порядок клітинки на полі по y
        public GameSymbol gameSymbol;
        public bool isEmpty = true;
        public Point pointOnField0; // Початок області клітинки
        public Point pointOnField1; // Кінець області клітинки
        public Gamer gamer;

        public Cell(int x, int y, Point point0, Point point1)
        {
            this.x = x;
            this.y = y;
            this.pointOnField0 = point0;
            this.pointOnField1 = point1;
        }
        public override string ToString()
        {
            return $"{gamer} ({gameSymbol}): [{x}, {y}]";
        }
        public override bool Equals(object obj)
        {
            if (obj is Cell cell)
            {
                return gameSymbol == cell.gameSymbol && gamer == cell.gamer && x == cell.x && y == cell.y && !isEmpty==!cell.isEmpty;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
