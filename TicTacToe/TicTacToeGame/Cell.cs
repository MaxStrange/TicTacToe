using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    [Serializable]
    /// <summary>
    /// One of the game grid's cells. Essentially, it is the game logic's representation of the TicPanels.
    /// </summary>
    internal class Cell
    {
        internal const int O = 0;
        internal const int X = 1;
        internal const int NULL_ID = -10;

        internal int ID = NULL_ID;

        private int _row = -1;
        internal int row
        {
            get { return this._row; }
        }

        private int _column = -1;
        internal int column
        {
            get { return this._column; }
        }


        internal Cell(int row, int column)
        {
            this._column = column;
            this._row = row;
        }



        internal bool IsEmpty()
        {
            return this.ID == NULL_ID ? true : false;
        }

        internal void Restart()
        {
            this.ID = -10;
        }
    }
}
