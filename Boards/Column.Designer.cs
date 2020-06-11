namespace Boards
{
    partial class BoardColumn
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tb = new System.Windows.Forms.TextBox();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb
            // 
            this.tb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb.ContextMenuStrip = this.cms;
            this.tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tb.ForeColor = System.Drawing.Color.White;
            this.tb.Location = new System.Drawing.Point(32, 37);
            this.tb.Margin = new System.Windows.Forms.Padding(32);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(186, 25);
            this.tb.TabIndex = 0;
            this.tb.Text = "Oszlop";
            this.tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cms
            // 
            this.cms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.resetColorToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cms.Name = "cms";
            this.cms.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cms.Size = new System.Drawing.Size(165, 70);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.colorToolStripMenuItem.Text = "Szín beállítása";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // resetColorToolStripMenuItem
            // 
            this.resetColorToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.resetColorToolStripMenuItem.Name = "resetColorToolStripMenuItem";
            this.resetColorToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.resetColorToolStripMenuItem.Text = "Szín visszaállítása";
            this.resetColorToolStripMenuItem.Click += new System.EventHandler(this.resetColorToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.IndianRed;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteToolStripMenuItem.Text = "Törlés";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // BoardColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.cms;
            this.Controls.Add(this.tb);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BoardColumn";
            this.Size = new System.Drawing.Size(250, 100);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Column_Paint);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Column_MouseUp);
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetColorToolStripMenuItem;
    }
}
