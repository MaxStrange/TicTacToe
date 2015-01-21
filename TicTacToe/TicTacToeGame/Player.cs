using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    [Serializable]
    internal class Player
    {
        internal int ID = Cell.NULL_ID;

        internal Player(int player)
        {
            this.ID = player;
        }

        internal Player ToggleTurn()
        {
            int id = -1;
            //TODO:
            //if (this.ID == Cell.NULL_ID)
            //    throw new NotInitializedException;
            id = (this.ID == Cell.X) ? Cell.O : Cell.X;
            return new Player(id);
        }
    }
}
