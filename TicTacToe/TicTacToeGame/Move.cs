using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    /// <summary>
    /// Represents a move - that is, a location in the 3x3 tic tac toe grid where the move is placed.
    /// </summary>
    internal class Move
    {
        private int _column = -1;
        internal int column
        {
            get { return this._column; }
        }
        private int _row = -1;
        internal int row
        {
            get { return this._row; }
        }


        internal Move(int row, int column)
        {
            this._column = column;
            this._row = row;
        }
    }
}
