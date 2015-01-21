namespace TicTacToe
{
    partial class TicForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTL = new TicControls.TicPanel();
            this.panelML = new TicControls.TicPanel();
            this.panelBL = new TicControls.TicPanel();
            this.panelTM = new TicControls.TicPanel();
            this.panelM = new TicControls.TicPanel();
            this.panelBM = new TicControls.TicPanel();
            this.panelTR = new TicControls.TicPanel();
            this.panelMR = new TicControls.TicPanel();
            this.panelBR = new TicControls.TicPanel();
            this.SuspendLayout();
            // 
            // panelTL
            // 
            this.panelTL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelTL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTL.Location = new System.Drawing.Point(12, 12);
            this.panelTL.Name = "panelTL";
            this.panelTL.Size = new System.Drawing.Size(336, 244);
            this.panelTL.TabIndex = 0;
            // 
            // panelML
            // 
            this.panelML.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelML.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelML.Location = new System.Drawing.Point(12, 262);
            this.panelML.Name = "panelML";
            this.panelML.Size = new System.Drawing.Size(336, 249);
            this.panelML.TabIndex = 1;
            // 
            // panelBL
            // 
            this.panelBL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelBL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBL.Location = new System.Drawing.Point(12, 517);
            this.panelBL.Name = "panelBL";
            this.panelBL.Size = new System.Drawing.Size(336, 212);
            this.panelBL.TabIndex = 2;
            // 
            // panelTM
            // 
            this.panelTM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelTM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTM.Location = new System.Drawing.Point(354, 12);
            this.panelTM.Name = "panelTM";
            this.panelTM.Size = new System.Drawing.Size(302, 244);
            this.panelTM.TabIndex = 3;
            // 
            // panelM
            // 
            this.panelM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelM.Location = new System.Drawing.Point(354, 262);
            this.panelM.Name = "panelM";
            this.panelM.Size = new System.Drawing.Size(302, 249);
            this.panelM.TabIndex = 4;
            // 
            // panelBM
            // 
            this.panelBM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelBM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBM.Location = new System.Drawing.Point(354, 517);
            this.panelBM.Name = "panelBM";
            this.panelBM.Size = new System.Drawing.Size(302, 212);
            this.panelBM.TabIndex = 5;
            // 
            // panelTR
            // 
            this.panelTR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelTR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTR.Location = new System.Drawing.Point(662, 12);
            this.panelTR.Name = "panelTR";
            this.panelTR.Size = new System.Drawing.Size(297, 244);
            this.panelTR.TabIndex = 6;
            // 
            // panelMR
            // 
            this.panelMR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelMR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMR.Location = new System.Drawing.Point(662, 262);
            this.panelMR.Name = "panelMR";
            this.panelMR.Size = new System.Drawing.Size(297, 249);
            this.panelMR.TabIndex = 7;
            // 
            // panelBR
            // 
            this.panelBR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelBR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBR.Location = new System.Drawing.Point(662, 517);
            this.panelBR.Name = "panelBR";
            this.panelBR.Size = new System.Drawing.Size(297, 212);
            this.panelBR.TabIndex = 8;
            // 
            // TicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 741);
            this.Controls.Add(this.panelBR);
            this.Controls.Add(this.panelMR);
            this.Controls.Add(this.panelTR);
            this.Controls.Add(this.panelBM);
            this.Controls.Add(this.panelM);
            this.Controls.Add(this.panelTM);
            this.Controls.Add(this.panelBL);
            this.Controls.Add(this.panelML);
            this.Controls.Add(this.panelTL);
            this.Name = "TicForm";
            this.Text = "Tic Tac Toe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TicForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TicForm_Paint);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.TicForm_Layout);
            this.ResumeLayout(false);

        }

        #endregion

        private TicControls.TicPanel panelTL;
        private TicControls.TicPanel panelML;
        private TicControls.TicPanel panelBL;
        private TicControls.TicPanel panelTM;
        private TicControls.TicPanel panelM;
        private TicControls.TicPanel panelBM;
        private TicControls.TicPanel panelTR;
        private TicControls.TicPanel panelMR;
        private TicControls.TicPanel panelBR;



    }
}

