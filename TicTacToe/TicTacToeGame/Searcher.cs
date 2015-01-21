using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    internal class Searcher
    {
        private ISearchBehavior behavior = null;

        internal Searcher(ISearchBehavior behavior)
        {
            this.behavior = behavior;
        }


        internal Move ComputeBestMove(GameState currentState)
        {
            return this.behavior.ComputeBestMove(currentState);
        }
    }
}
