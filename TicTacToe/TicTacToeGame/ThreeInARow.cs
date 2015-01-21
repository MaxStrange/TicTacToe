using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    internal class ThreeInARow
    {
        private Cell[] row_Column_Or_Diagonal = new Cell[3];

        internal Cell[] cells
        {
            get { return this.row_Column_Or_Diagonal; }
        }

        internal ThreeInARow(Cell c1, Cell c2, Cell c3)
        {
            this.row_Column_Or_Diagonal[0] = c1;
            this.row_Column_Or_Diagonal[1] = c2;
            this.row_Column_Or_Diagonal[2] = c3;
        }



        internal bool CheckForVictory()
        {
            int victory = this.row_Column_Or_Diagonal[0].ID + this.row_Column_Or_Diagonal[1].ID + this.row_Column_Or_Diagonal[2].ID;
            if (victory == 0)
                return true; //O wins
            else if (victory == 3)
                return true; //X wins
            else
                return false;
        }

        internal bool HasNoOs()
        {
            foreach (Cell c in this.row_Column_Or_Diagonal)
            {
                if (c.ID == Cell.O)
                    return false;
            }
            return true;
        }

        internal bool HasNoXs()
        {
            foreach (Cell c in this.row_Column_Or_Diagonal)
            {
                if (c.ID == Cell.X)
                    return false;
            }
            return true;
        }
    }
}
