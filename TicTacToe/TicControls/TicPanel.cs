using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using TicTacToeGame;

namespace TicControls
{
    public partial class TicPanel : UserControl
    {
        private bool _clickPending = false;
        public bool clickPending
        {
            get { return this._clickPending; }
            private set 
            { 
                this._clickPending = value;
                this.hasBeenClicked = true;
            }
        }


        private int _columnIndex = 0;
        public int columnIndex
        {
            get { return this._columnIndex; }
        }

        private int _rowIndex = 0;
        public int rowIndex
        {
            get { return this._rowIndex; }
        }


        
        private bool hasBeenClicked = false;
        private bool panelIsX = false;
        private bool panelIsO = false;

        public TicPanel()
        {
            InitializeComponent();
        }

        public void DrawO()
        {
            this.panelIsO = true;
            this.clickPending = false;
            this.Invalidate();//redraw
        }

        public void DrawX()
        {
            this.panelIsX = true;
            this.clickPending = false;
            this.Invalidate();//redraw
        }

        public void InitializeIndices(int row, int column)
        {
            this._columnIndex = column;
            this._rowIndex = row;
        }

        public void Restart()
        {
            this._clickPending = false;
            this.hasBeenClicked = false;
            this.panelIsO = false;
            this.panelIsX = false;
        }



        private void PaintO()
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Blue, 15);

            g.Clear(Color.LightGray);
            g.DrawEllipse(p, new Rectangle(0, 0, this.Width, this.Height));
        }

        private void PaintX()
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Red, 15);

            g.Clear(Color.LightGray);
            g.DrawLine(p, new Point(0, 0), new Point(this.Width, this.Height));
            g.DrawLine(p, new Point(0, this.Height), new Point(this.Width, 0));
        }

        private void TicPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.hasBeenClicked)
                return;
            else
                this.clickPending = true;
        }

        private void TicPanel_Paint(object sender, PaintEventArgs e)
        {
            if (this.panelIsX)
                PaintX();
            else if (this.panelIsO)
                PaintO();
            else
                e.Graphics.Clear(Color.LightGray);
        }
    }
}
