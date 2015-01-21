using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsefulStaticMethods;

namespace TicTacToeGame
{
    /// <summary>
    /// Encapsulates a state that the game could be in. That is, who has gone where.
    /// </summary>
    internal class GameState
    {
        /// <summary>
        /// Whose turn it is: X or O
        /// </summary>
        private Player _turn = null;
        internal Player turn
        {
            get { return this._turn; }
            private set { this._turn = value; }
        }
        private Cell[,] stateOfTheGame = new Cell[3, 3];
        private Move _moveThatDerivedState = null;
        internal Move moveThatDerivedState
        {
            get { return this._moveThatDerivedState; }
        }
        private ThreeInARow[] threeInARows = new ThreeInARow[8];


        private int[,] Heuristic_Array = new int[,] {
              {     0,   10,  100, 1000 },
              {    -10,     0,     0,     0 },
              {   -100,     0,     0,     0 },
              {  -1000,     0,     0,     0 }
          };


        internal GameState(Cell[,] state, Player turn)
        {
            Initialize(state, turn);
        }

        /// <summary>
        /// Used for deriving a daughter state. The move is applied to the given state to form the GameState being constructed.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="turn">
        /// The player whose move is being used to derive this state.
        /// </param>
        /// <param name="move"></param>
        private GameState(Cell[,] state, Player turn, Move move)
        {
            Initialize(state, turn);
            this._moveThatDerivedState = move;
            this.stateOfTheGame[move.row, move.column].ID = this.turn.ID;
            this.turn = this.turn.ToggleTurn();

        }




        internal void AssignO(int row, int column)
        {
            this.stateOfTheGame[row, column].ID = Cell.O;
            this.turn = new Player(Cell.X);
        }

        internal void AssignX(int row, int column)
        {
            this.stateOfTheGame[row, column].ID = Cell.X;
            this.turn = new Player(Cell.O);
        }

        internal bool CheckForGameOver()
        {
            foreach (ThreeInARow line in this.threeInARows)
            {
                if (line.CheckForVictory())
                    return true;
            }

            foreach (Cell cell in this.stateOfTheGame)
            {
                if (cell.ID == Cell.NULL_ID)
                    return false;
            }

            //Nobody won, but the baord is full
            return true;
        }

        /// <summary>
        /// Derives a new GameState by playing move on the current state.
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        internal GameState DeriveState(Move move)
        {
            GameState newState = new GameState(this.stateOfTheGame.DeepClone(), this.turn, move);

            return newState;
        }

        internal int Evaluate()
        {
            int xSpots = 0;
            int oSpots = 0;
            int score = 0;
            foreach (ThreeInARow line in this.threeInARows)
            {
                foreach (Cell c in line.cells)
                {
                    if (c.ID == Cell.X)
                        xSpots++;
                    if (c.ID == Cell.O)
                        oSpots++;
                }
                score += Heuristic_Array[xSpots, oSpots];
                xSpots = 0;
                oSpots = 0;
            }
            return score;
        }

        internal bool IsXTurn()
        {
            return (this.turn.ID == Cell.X);
        }

        internal int NumberOfOPathsToVictory()
        {
            int numberOfOPaths = 0;
            foreach (ThreeInARow line in this.threeInARows)
            {
                if (line.HasNoXs())
                    numberOfOPaths++;
            }
            return numberOfOPaths;
        }

        internal int NumberOfXPathsToVictory()
        {
            int numberOfPaths = 0;
            foreach (ThreeInARow line in this.threeInARows)
            {
                if (line.HasNoOs())
                    numberOfPaths++;
            }
            return numberOfPaths;
        }

        internal void Restart()
        {
            foreach (Cell cell in this.stateOfTheGame)
            {
                cell.Restart();
            }
        }

        internal List<Cell> RetrieveEmptyCells()
        {
            List<Cell> emptyCells = new List<Cell>();
            foreach (Cell cell in this.stateOfTheGame)
            {
                if (cell.IsEmpty())
                    emptyCells.Add(cell);
            }
            return emptyCells;
        }

        internal void ToggleTurn()
        {
            this.turn = this.turn.ToggleTurn();
        }




        private void Initialize(Cell[,] state, Player turn)
        {
            this.turn = turn;

            InitializeCells();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.stateOfTheGame[i, j] = state[i, j].DeepClone();
                }
            }

            InitializeThreeInARows();
        }

        private void InitializeCells()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.stateOfTheGame[i, j] = new Cell(i, j);
                }
            }
        }

        private void InitializeThreeInARows()
        {
            this.threeInARows[0] = new ThreeInARow(this.stateOfTheGame[0, 0], this.stateOfTheGame[0, 1], this.stateOfTheGame[0, 2]);
            this.threeInARows[1] = new ThreeInARow(this.stateOfTheGame[1, 0], this.stateOfTheGame[1, 1], this.stateOfTheGame[1, 2]);
            this.threeInARows[2] = new ThreeInARow(this.stateOfTheGame[2, 0], this.stateOfTheGame[2, 1], this.stateOfTheGame[2, 2]);
            this.threeInARows[3] = new ThreeInARow(this.stateOfTheGame[0, 0], this.stateOfTheGame[1, 1], this.stateOfTheGame[2, 2]);
            this.threeInARows[4] = new ThreeInARow(this.stateOfTheGame[0, 2], this.stateOfTheGame[1, 1], this.stateOfTheGame[2, 0]);
            this.threeInARows[5] = new ThreeInARow(this.stateOfTheGame[0, 0], this.stateOfTheGame[1, 0], this.stateOfTheGame[2, 0]);
            this.threeInARows[6] = new ThreeInARow(this.stateOfTheGame[0, 1], this.stateOfTheGame[1, 1], this.stateOfTheGame[2, 1]);
            this.threeInARows[7] = new ThreeInARow(this.stateOfTheGame[0, 2], this.stateOfTheGame[1, 2], this.stateOfTheGame[2, 2]);
        }
    }
}
