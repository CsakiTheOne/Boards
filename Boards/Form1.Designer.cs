namespace Boards
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNew = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traditionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblFolder = new System.Windows.Forms.Label();
            this.panelDisplay = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cms.SuspendLayout();
            this.cmsNew.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelDisplay.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cms
            // 
            this.cms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.traditionalToolStripMenuItem});
            this.cms.Name = "cms";
            this.cms.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cms.Size = new System.Drawing.Size(192, 92);
            this.cms.Text = "Asd";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDown = this.cmsNew;
            this.newToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.newToolStripMenuItem.Text = "Új";
            // 
            // cmsNew
            // 
            this.cmsNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cmsNew.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNoteToolStripMenuItem,
            this.addTextToolStripMenuItem});
            this.cmsNew.Name = "cmsNew";
            this.cmsNew.OwnerItem = this.newToolStripMenuItem;
            this.cmsNew.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsNew.Size = new System.Drawing.Size(203, 48);
            // 
            // addNoteToolStripMenuItem
            // 
            this.addNoteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.addNoteToolStripMenuItem.Name = "addNoteToolStripMenuItem";
            this.addNoteToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.addNoteToolStripMenuItem.Text = "Jegyzet blokk";
            this.addNoteToolStripMenuItem.Click += new System.EventHandler(this.addNoteToolStripMenuItem_Click);
            // 
            // addTextToolStripMenuItem
            // 
            this.addTextToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.addTextToolStripMenuItem.Name = "addTextToolStripMenuItem";
            this.addTextToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.addTextToolStripMenuItem.Text = "Szöveg (átlátszó jegyzet)";
            this.addTextToolStripMenuItem.Click += new System.EventHandler(this.addTextToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.pasteToolStripMenuItem.Text = "Jegyzet beillesztése";
            this.pasteToolStripMenuItem.Visible = false;
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // traditionalToolStripMenuItem
            // 
            this.traditionalToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.traditionalToolStripMenuItem.Name = "traditionalToolStripMenuItem";
            this.traditionalToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.traditionalToolStripMenuItem.Text = "Hagyományos jegyzet";
            this.traditionalToolStripMenuItem.Click += new System.EventHandler(this.traditionalToolStripMenuItem_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.ContextMenuStrip = this.cms;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 56F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(857, 85);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Jobb klikk a kezdéshez!";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panelHeader.Controls.Add(this.btnSave);
            this.panelHeader.Controls.Add(this.lblFolder);
            this.panelHeader.Controls.Add(this.btnHome);
            this.panelHeader.Controls.Add(this.btnOpen);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(984, 40);
            this.panelHeader.TabIndex = 2;
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFolder.Location = new System.Drawing.Point(77, 10);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(338, 20);
            this.lblFolder.TabIndex = 2;
            this.lblFolder.Text = "Mappa megnyitásához kattints a mappa ikonra";
            this.lblFolder.Click += new System.EventHandler(this.lblFolder_Click);
            // 
            // panelDisplay
            // 
            this.panelDisplay.ContextMenuStrip = this.cms;
            this.panelDisplay.Controls.Add(this.lblTitle);
            this.panelDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDisplay.Location = new System.Drawing.Point(0, 40);
            this.panelDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.panelDisplay.Name = "panelDisplay";
            this.panelDisplay.Size = new System.Drawing.Size(984, 495);
            this.panelDisplay.TabIndex = 4;
            this.panelDisplay.TabStop = true;
            this.panelDisplay.Click += new System.EventHandler(this.panelDisplay_Click);
            this.panelDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelDisplay_MouseMove);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblVersion,
            this.lblPosition});
            this.statusStrip.Location = new System.Drawing.Point(0, 535);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(984, 26);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblVersion
            // 
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(19, 21);
            this.lblVersion.Text = "...";
            this.lblVersion.Click += new System.EventHandler(this.lblVersion_Click);
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Interval = 200;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(781, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 34);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.Image = global::Boards.Properties.Resources.round_border_inner_white_48dp;
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(61, 21);
            this.lblPosition.Text = "(0, 0)";
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = global::Boards.Properties.Resources.round_home_white_48dp;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Location = new System.Drawing.Point(6, 6);
            this.btnHome.Margin = new System.Windows.Forms.Padding(6);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(28, 28);
            this.btnHome.TabIndex = 1;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackgroundImage = global::Boards.Properties.Resources.round_folder_white_48dp;
            this.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.Location = new System.Drawing.Point(40, 6);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(28, 28);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panelDisplay);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Name = "Form1";
            this.Text = "Boards";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.cms.ResumeLayout(false);
            this.cmsNew.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelDisplay.ResumeLayout(false);
            this.panelDisplay.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Panel panelDisplay;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.ToolStripMenuItem traditionalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsNew;
        private System.Windows.Forms.ToolStripMenuItem addNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblPosition;
        private System.Windows.Forms.Button btnSave;
    }
}

