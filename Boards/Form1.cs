using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boards
{
    public partial class Form1 : Form
    {
        Point selectedPosition;
        ItemManager itemManager = new ItemManager();
        List<string> items = new List<string>();

        public Form1()
        {
            InitializeComponent();
            Text = "Boards - " + Program.Version;

            itemManager.Parent = panelDisplay;
            itemManager.ItemsChanged += (object sender, EventArgs e) => { Save(); panelDisplay.Refresh(); };

            Global.FolderChanged += ReloadFolder;
            ReloadFolder();
        }

        #region Panel
        private void panelDisplay_Click(object sender, EventArgs e) => panelDisplay.Focus();

        private void panelDisplay_MouseMove(object sender, MouseEventArgs e) => selectedPosition = e.Location;
        #endregion

        #region Context menu
        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            itemManager.Add(new NoteBlock().GetItemData(), selectedPosition);
        }

        private void addTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoteBlock nb = new NoteBlock();
            nb.SetTransparent(true);
            itemManager.Add(nb.GetItemData(), selectedPosition);
        }

        private void addBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "A fő mappa kiválasztásához nyomj a mégsére.";

            BoardIcon bi = new BoardIcon();

            DialogResult res = fbd.ShowDialog();
            if (res == DialogResult.OK) bi.Folder = fbd.SelectedPath;
            else if (res == DialogResult.Cancel) bi.Folder = "./";
            
            itemManager.Add(bi.GetItemData(), selectedPosition);
        }

        private void bubiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            itemManager.Add(new Bubi().GetItemData(), selectedPosition);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.Clipboard.Item == null) return;

            itemManager.Add(Global.Clipboard.Item, selectedPosition);
        }

        private void traditionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Ez törölni fog minden eddigi jegyzetet itt és a program egy hagyományos jegyzetelő alkalmazássá alakul. Folytatod?", "Hagyományos mód", MessageBoxButtons.YesNo);

            if (res != DialogResult.Yes) return;
            itemManager.Clear();
            itemManager.Add(new NoteBlock(new List<string>() { "maximized", "noborder", "nofocus" }).GetItemData());
        }
        #endregion

        #region Top bar
        private void btnHome_Click(object sender, EventArgs e)
        {
            Global.SetFolder("./");
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Betöltés...";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Válaszd ki a mappát ahová jegyzetelni szeretnél vagy ahol a jegyzeteid vannak.";
            if (fbd.ShowDialog() != DialogResult.OK) return;
            Global.SetFolder(fbd.SelectedPath);
        }

        private void lblFolder_Click(object sender, EventArgs e)
        {
            if (Global.Folder == "./") Process.Start(Directory.GetCurrentDirectory());
            else Process.Start(Global.Folder);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        TimeSpan lastSaveAgo;
        string lastSaveText;
        private void timerStatus_Tick(object sender, EventArgs e)
        {
            // Save status
            lastSaveAgo = DateTime.Now.TimeOfDay - lastSaveTime;
            if (lastSaveAgo.TotalSeconds < 2) lastSaveText = "most";
            else if (lastSaveAgo.TotalSeconds < 20) lastSaveText = "az imént";
            else if (lastSaveAgo.TotalSeconds < 50) lastSaveText = "fél perce";
            else if (lastSaveAgo.TotalSeconds < 80) lastSaveText = "egy perce";
            else if (lastSaveAgo.TotalSeconds < 110) lastSaveText = "másfél perce";
            else lastSaveText = Math.Round(lastSaveAgo.TotalMinutes) + " perce\n\r(kattints ide bármikor mentéshez)";
            btnSave.Text = $"Utolsó mentés " + lastSaveText;

            bubiToolStripMenuItem.Visible = Math.Round(lastSaveAgo.TotalMinutes) == 13;
        }
        #endregion

        #region IO
        TimeSpan lastSaveTime = new TimeSpan();

        void ReloadFolder()
        {
            List<string> itemList = IO.Open(Global.Folder);
            if (itemList == null) return;
            else items = itemList;

            btnSave.Text = "Betöltés...";

            if (Global.Folder == "./") lblFolder.Text = "Jelenlegi mappa: Fő mappa";
            else lblFolder.Text = "Jelenlegi mappa: " + Global.Folder;
            itemManager.Clear();

            foreach (string item in items) itemManager.Add(item);

            lastSaveTime = DateTime.Now.TimeOfDay;
        }
        
        void Save()
        {
            btnSave.Text = "Mentés...";
            items = new List<string>();
            foreach (IItem control in panelDisplay.Controls)
            {
                items.Add(control.GetItemData());
            }
            if (Global.Folder == null) return;
            IO.Save(Global.Folder, items);
            lastSaveTime = DateTime.Now.TimeOfDay;
        }
        #endregion

        #region Graphics

        private void panelDisplay_Paint(object sender, PaintEventArgs e)
        {
            if (panelDisplay.Controls.Count < 1)
            {
                Font hintFont = new Font(FontFamily.GenericMonospace, Width / 25, FontStyle.Bold);
                SizeF hintSize = e.Graphics.MeasureString("Jobb klikk a kezdéshez", hintFont);
                e.Graphics.DrawString("Jobb klikk a kezdéshez", hintFont, new SolidBrush(Color.FromArgb(40, 40, 40)), Width / 2 - hintSize.Width / 2, Height / 2 - hintSize.Height);
            }
            else
            {
                e.Graphics.Clear(panelDisplay.BackColor);
            }
        }

        private void panelDisplay_Resize(object sender, EventArgs e)
        {
            panelDisplay.Refresh();
        }

        #endregion

        private void lblFolder_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) lblFolder.DoDragDrop(Global.Folder, DragDropEffects.Copy);
        }
    }
}
