using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsefulStaticMethods;

namespace TicTacToeGame
{
    public class GameLogic
    {
        private GameState currentState = null;

        private bool humanIsFirstPlayer = false;

        private bool _playingAgainstComputer = false;
        public bool playingAgainstComputer
        {
            get { return this._playingAgainstComputer; }
        }
        


        public GameLogic(bool HumanVsHuman, bool humanIsFirstPlayer)
        {
            this._playingAgainstComputer = !HumanVsHuman;
            this.humanIsFirstPlayer = humanIsFirstPlayer;
            InitializeState(humanIsFirstPlayer);
        }


        public void AssignO(int cellRow, int cellColumn)
        {
            this.currentState.AssignO(cellRow, cellColumn);
        }

        public void AssignX(int cellRow, int cellColumn)
        {
            this.currentState.AssignX(cellRow, cellColumn);
        }

        public bool CheckForGameOver()
        {
            return this.currentState.CheckForGameOver();
        }

        public bool IsXTurn()
        {
            return this.currentState.IsXTurn();
        }

        public bool playingAgainstComputer_AND_ComputerGoesFirst()
        {
            return (this.playingAgainstComputer && !this.humanIsFirstPlayer);
        }

        public void Restart()
        {
            this.currentState.Restart();
        }

        public Tuple<int, int> TakeTurn()
        {
            Move bestMove = ComputeBestMove();
            return new Tuple<int, int>(bestMove.row, bestMove.column);
        }


        
        
        private Move ComputeBestMove()
        {
            Searcher searcher = new Searcher(new MiniMax());
            Move bestPossibleMove = searcher.ComputeBestMove(this.currentState);
            return bestPossibleMove;
        }

        private Cell[,] InitializeCellArray()
        {
            Cell[,] cellArray = new Cell[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cellArray[i, j] = new Cell(i, j);
                }
            }
            return cellArray;
        }

        private void InitializeState(bool humanIsFirstPlayer)
        {
            Cell[,] cellArray = InitializeCellArray();
            Player turn = InitializeTurn(humanIsFirstPlayer);
            this.currentState = new GameState(cellArray, turn);
        }

        private Player InitializeTurn(bool humanIsFirstPlayer)
        {
            if (humanIsFirstPlayer)
                return new Player(Cell.X);
            else
                return new Player(Cell.O);
        }
    }
}
