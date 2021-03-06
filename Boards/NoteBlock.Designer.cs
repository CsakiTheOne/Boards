﻿namespace Boards
{
    partial class NoteBlock
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
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparentNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbTagAdd = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDragDrop = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timerTextObserver = new System.Windows.Forms.Timer(this.components);
            this.cms.SuspendLayout();
            this.cmsSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb
            // 
            this.tb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb.ContextMenuStrip = this.cms;
            this.tb.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tb.ForeColor = System.Drawing.Color.Silver;
            this.tb.Location = new System.Drawing.Point(16, 16);
            this.tb.Margin = new System.Windows.Forms.Padding(16);
            this.tb.Multiline = true;
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(218, 68);
            this.tb.TabIndex = 0;
            this.tb.Text = "Írj ide valamit!\r\nJobb klikk a beállításokhoz.";
            this.tb.DragDrop += new System.Windows.Forms.DragEventHandler(this.NoteBlock_DragDrop);
            this.tb.DoubleClick += new System.EventHandler(this.tb_DoubleClick);
            this.tb.MouseEnter += new System.EventHandler(this.tb_MouseEnter);
            this.tb.MouseLeave += new System.EventHandler(this.tb_MouseLeave);
            // 
            // cms
            // 
            this.cms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cms.Name = "cms";
            this.cms.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cms.Size = new System.Drawing.Size(137, 120);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDown = this.cmsSettings;
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.settingsToolStripMenuItem.Text = "Beállítások";
            // 
            // cmsSettings
            // 
            this.cmsSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cmsSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeColorToolStripMenuItem,
            this.resetColorToolStripMenuItem,
            this.transparentNoteToolStripMenuItem,
            this.lockToolStripMenuItem,
            this.tagsToolStripMenuItem});
            this.cmsSettings.Name = "cms";
            this.cmsSettings.OwnerItem = this.settingsToolStripMenuItem;
            this.cmsSettings.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsSettings.Size = new System.Drawing.Size(201, 114);
            // 
            // changeColorToolStripMenuItem
            // 
            this.changeColorToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.changeColorToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.changeColorToolStripMenuItem.Name = "changeColorToolStripMenuItem";
            this.changeColorToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.changeColorToolStripMenuItem.Text = "Szín beállítása";
            this.changeColorToolStripMenuItem.Click += new System.EventHandler(this.changeColorToolStripMenuItem_Click);
            // 
            // resetColorToolStripMenuItem
            // 
            this.resetColorToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.resetColorToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.resetColorToolStripMenuItem.Name = "resetColorToolStripMenuItem";
            this.resetColorToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.resetColorToolStripMenuItem.Text = "Szín visszaállítása";
            this.resetColorToolStripMenuItem.Click += new System.EventHandler(this.resetColorToolStripMenuItem_Click);
            // 
            // transparentNoteToolStripMenuItem
            // 
            this.transparentNoteToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.transparentNoteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.transparentNoteToolStripMenuItem.Name = "transparentNoteToolStripMenuItem";
            this.transparentNoteToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.transparentNoteToolStripMenuItem.Text = "Átlátszó jegyzet";
            this.transparentNoteToolStripMenuItem.Click += new System.EventHandler(this.transparentNoteToolStripMenuItem_Click);
            // 
            // lockToolStripMenuItem
            // 
            this.lockToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lockToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
            this.lockToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.lockToolStripMenuItem.Text = "Lezárás (csak olvasható)";
            this.lockToolStripMenuItem.Click += new System.EventHandler(this.lockToolStripMenuItem_Click);
            // 
            // tagsToolStripMenuItem
            // 
            this.tagsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tagsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbTagAdd});
            this.tagsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.tagsToolStripMenuItem.Name = "tagsToolStripMenuItem";
            this.tagsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.tagsToolStripMenuItem.Text = "Címkék";
            this.tagsToolStripMenuItem.Click += new System.EventHandler(this.tagsToolStripMenuItem_Click);
            // 
            // tbTagAdd
            // 
            this.tbTagAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTagAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbTagAdd.Name = "tbTagAdd";
            this.tbTagAdd.Size = new System.Drawing.Size(100, 23);
            this.tbTagAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTagAdd_KeyDown);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.cutToolStripMenuItem.Text = "Kivágás";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.copyToolStripMenuItem.Text = "Másolás";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.pasteToolStripMenuItem.Text = "Beleillesztés";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.IndianRed;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.deleteToolStripMenuItem.Text = "Törlés";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // lblDragDrop
            // 
            this.lblDragDrop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblDragDrop.AutoSize = true;
            this.lblDragDrop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDragDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDragDrop.Location = new System.Drawing.Point(117, 86);
            this.lblDragDrop.Name = "lblDragDrop";
            this.lblDragDrop.Size = new System.Drawing.Size(16, 13);
            this.lblDragDrop.TabIndex = 3;
            this.lblDragDrop.Text = "...";
            this.toolTip.SetToolTip(this.lblDragDrop, "Fogd meg ezt a 3 pontot és húzd át egy másik jegyzetre\r\nvagy a programon kívül bá" +
        "rhová a szöveg másolásához.");
            this.lblDragDrop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDragDrop_MouseDown);
            // 
            // timerTextObserver
            // 
            this.timerTextObserver.Enabled = true;
            this.timerTextObserver.Interval = 10000;
            this.timerTextObserver.Tick += new System.EventHandler(this.timerTextObserver_Tick);
            // 
            // NoteBlock
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.cms;
            this.Controls.Add(this.lblDragDrop);
            this.Controls.Add(this.tb);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(100, 50);
            this.Name = "NoteBlock";
            this.Size = new System.Drawing.Size(250, 100);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.NoteBlock_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.NoteBlock_DragEnter);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NoteBlock_Paint);
            this.DoubleClick += new System.EventHandler(this.tb_DoubleClick);
            this.MouseEnter += new System.EventHandler(this.NoteBlock_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.NoteBlock_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NoteBlock_MouseUp);
            this.cms.ResumeLayout(false);
            this.cmsSettings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.Label lblDragDrop;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer timerTextObserver;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsSettings;
        private System.Windows.Forms.ToolStripMenuItem changeColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparentNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tbTagAdd;
    }
}
