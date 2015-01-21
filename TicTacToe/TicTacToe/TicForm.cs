using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicControls;
using TicTacToeGame;
using UsefulStaticMethods;

namespace TicTacToe
{
    public partial class TicForm : Form
    {
        private delegate void checkToChangeXODelegate();

        private TicPanel[] panelGrid;
        private TicPanel[,] panelGridByRowAndColumn;

        private GameLogic game = null;

        private bool keepPolling = true;



        public TicForm()
        {
            InitializeComponent();
            InitializeGame();
            InitializePanels();

            if (this.game.playingAgainstComputer_AND_ComputerGoesFirst())
                TakeComputerTurn();

            Thread t = ThreadMethods.createNewBackgroundThread(PollToChangeXO, "XOPollingThread");
            t.Start();
        }





        public void PollToChangeXO()
        {
            while (this.keepPolling)
            {
                Thread.Sleep(20);
                CheckToChangeXO();
            }
        }




        private bool AskIfHumanIsFirstPlayer()
        {
            DialogResult firstSecond = MessageBox.Show("Go first?", "Choose Starting Player", MessageBoxButtons.YesNo);
            bool humanIsFirstPlayer = false;
            switch (firstSecond)
            {
                case DialogResult.Yes:
                    humanIsFirstPlayer = true;
                    break;
                case DialogResult.No:
                    humanIsFirstPlayer = false;
                    break;
            }
            return humanIsFirstPlayer;
        }

        private bool AskIfHumanVsHuman()
        {
            DialogResult computerHuman = MessageBox.Show("Play against computer?", "Human or Computer", MessageBoxButtons.YesNo);
            bool humanVsHuman = false;
            switch (computerHuman)
            {
                case DialogResult.Yes:
                    humanVsHuman = false;
                    break;
                case DialogResult.No:
                    humanVsHuman = true;
                    break;
            }
            return humanVsHuman;
        }

        private void AssignXorO(TicPanel panel)
        {
            if (this.game.IsXTurn())
            {
                panel.DrawX();
                this.game.AssignX(panel.rowIndex, panel.columnIndex);
            }
            else
            {
                panel.DrawO();
                this.game.AssignO(panel.rowIndex, panel.columnIndex);
            }
        }

        private void CheckForClickPending(TicPanel panel)
        {
            if (panel.clickPending)
            {
                AssignXorO(panel);
                ToggleTurnOrEndGame();
            }
        }

        private void CheckToChangeXO()
        {
            checkToChangeXODelegate pollChange = new checkToChangeXODelegate(CheckToChangeXO);

            if (!this.InvokeRequired)
            {
                DrawXorOIfRequired();
            }
            else
            {
                TryInvoke(pollChange);
            }
        }

        private void DrawXorOIfRequired()
        {
            foreach (TicPanel panel in this.panelGrid)
            {
                CheckForClickPending(panel);
            }
        }

        private void GameOver()
        {
            DialogResult result = MessageBox.Show("Game over! Do you want to play again?", "Game Over", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    Restart();
                    break;
                case DialogResult.No:
                    this.Dispose();
                    break;
            }
        }

        private void InitializeGame()
        {
            bool humanVsHuman = AskIfHumanVsHuman();

            bool humanIsFirstPlayer = true;
            if (!humanVsHuman)
                humanIsFirstPlayer = AskIfHumanIsFirstPlayer();

            this.game = new GameLogic(humanVsHuman, humanIsFirstPlayer);
        }

        private void InitializePanels()
        {
            this.panelGridByRowAndColumn = new TicPanel[,] { { this.panelTL, this.panelTM, this.panelTR }, { this.panelML, this.panelM, this.panelMR },
                { this.panelBL, this.panelBM, this.panelBR } };


            this.panelGrid = new TicControls.TicPanel[] { this.panelTL, this.panelTM, this.panelTR, this.panelML,
                                            this.panelM, this.panelMR, this.panelBL, this.panelBM, this.panelBR};
            int columnIndex = 0;
            int rowIndex = 0;
            for (int i = 0; i < this.panelGrid.Length; i++)
            {
                this.panelGrid[i].InitializeIndices(rowIndex, columnIndex);
                rowIndex = (columnIndex > 1) ? rowIndex + 1 : rowIndex;
                columnIndex = (columnIndex > 1) ? 0 : columnIndex + 1;
            }
        }

        private void Restart()
        {
            this.game.Restart();
            foreach (TicPanel panel in this.panelGrid)
            {
                panel.Restart();
                panel.Invalidate();
            }
            InitializeGame();

            if (this.game.playingAgainstComputer_AND_ComputerGoesFirst())
                TakeComputerTurn();
        }

        private void TakeComputerTurn()
        {
            Tuple<int, int> bestMove = this.game.TakeTurn();
            this.panelGridByRowAndColumn[bestMove.Item1, bestMove.Item2].DrawO();
            this.game.AssignO(bestMove.Item1, bestMove.Item2);
            
            if (this.game.CheckForGameOver())
                GameOver();
        }

        private void TicForm_Layout(object sender, LayoutEventArgs e)
        {
            int cx = ClientRectangle.Width / 3;
            int cy = ClientRectangle.Height / 3;
            for (int row = 0; row != 3; ++row)
            {
                for (int col = 0; col != 3; ++col)
                {
                    TicControls.TicPanel panel = this.panelGrid[col * 3 + row];
                    panel.SetBounds(cx * row, cy * col, cx, cy);
                }
            }
        }
        
        private void TicForm_Paint(object sender, PaintEventArgs e)
        {
        }

        private void TryInvoke(Delegate method)
        {
            try
            {
                this.Invoke(method, new object[] { });
            }
            catch (ObjectDisposedException)
            {
            }
        }

        private void TicForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.keepPolling = false;//clean up the polling thread
        }

        private void ToggleTurn()
        {
            //If playing against a computer, ask gamestate for the best move, then display that move on the GUI.
            if (this.game.playingAgainstComputer)
            {
                TakeComputerTurn();
            }
        }

        private void ToggleTurnOrEndGame()
        {
            if (this.game.CheckForGameOver())
                GameOver();
            else
                ToggleTurn();
        }
    }
}
