using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    internal class SearchNode
    {

        internal Move move
        {
            get { return this.state.moveThatDerivedState; }
        }
        private GameState state = null;
        internal Player turn
        {
            get { return this.state.turn; }
        }
        private int _value = -99;
        internal int value
        {
            get { return this._value; }
            set { this._value = value; }
        }



        internal SearchNode(GameState state)
        {
            this.state = state;
        }



        internal int Evaluate()
        {
            return this.state.Evaluate();
        }

        internal List<SearchNode> Expand()
        {
            List<Cell> emptyCells = this.state.RetrieveEmptyCells();
            List<SearchNode> children = new List<SearchNode>();
            foreach (Cell cell in emptyCells)
            {
                GameState daughterState = this.state.DeriveState(new Move(cell.row, cell.column));
                SearchNode daughter = new SearchNode(daughterState);
                children.Add(daughter);
            }
            return children;
        }

        internal bool IsTerminal()
        {
            return this.state.CheckForGameOver();
        }
    }
}
