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
        string folder = "./";
        Point selectedPosition;
        NoteManager noteManager = new NoteManager();
        List<NoteData> noteDatas = new List<NoteData>();
        TimeSpan lastSaveTime = new TimeSpan();

        public Form1()
        {
            InitializeComponent();
            noteManager.Parent = panelDisplay;
            noteManager.NotesChanged += NoteManager_NotesChanged;

            if (Properties.Settings.Default.lastFolder.Length > 1)
            {
                folder = Properties.Settings.Default.lastFolder;
                ReloadFolder();
            }

            lblVersion.Text = Program.Version;
        }

        private void NoteManager_NotesChanged(object sender, EventArgs e)
        {
            Save();
        }

        private void panelDisplay_Click(object sender, EventArgs e)
        {
            panelDisplay.Focus();
        }

        private void panelDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            selectedPosition = e.Location;
        }

        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            noteManager.Add(new NoteBlock(), selectedPosition);
            if (folder == "./") lblTitle.Text = "";
            else lblTitle.Text = folder.Substring(folder.LastIndexOf('\\') + 1);
        }

        private void addTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoteBlock nb = new NoteBlock();
            nb.SetTransparent(true);
            noteManager.Add(nb, selectedPosition);
            if (folder == "./") lblTitle.Text = "";
            else lblTitle.Text = folder.Substring(folder.LastIndexOf('\\') + 1);
        }

        private void traditionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Ez törölni fog minden eddigi jegyzetet itt és a program egy hagyományos jegyzetelő alkalmazássá alakul. Folytatod?", "Hagyományos mód", MessageBoxButtons.YesNo);

            if (res != DialogResult.Yes) return;
            noteManager.Clear();
            noteManager.Add(new NoteBlock() { Tags = new List<string>() { "maximized", "noborder", "nofocus" } });
            if (folder == "./") lblTitle.Text = "";
            else lblTitle.Text = folder.Substring(folder.LastIndexOf('\\') + 1);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            folder = "./";
            ReloadFolder();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Betöltés...";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Válaszd ki a mappát ahová jegyzetelni szeretnél vagy ahol a jegyzeteid vannak.";
            if (fbd.ShowDialog() != DialogResult.OK) return;
            folder = fbd.SelectedPath;
            ReloadFolder();
        }

        void ReloadFolder()
        {
            List<NoteData> nds = IO.Open(folder);
            if (nds == null) return;
            else noteDatas = nds;

            btnSave.Text = "Betöltés...";

            if (folder == "./") lblFolder.Text = "Mappa megnyitásához kattints a mappa ikonra";
            else lblFolder.Text = "Jelenlegi mappa: " + folder;
            ClearBoard();

            foreach (NoteData nd in noteDatas) noteManager.Add(new NoteBlock(nd));

            Properties.Settings.Default.lastFolder = folder;
            Properties.Settings.Default.Save();

            lastSaveTime = DateTime.Now.TimeOfDay;

            if (noteDatas.Count < 1)
            {
                lblTitle.Text = "Jobb klikk a kezdéshez!";
                return;
            }
            if (folder == "./") lblTitle.Text = "";
            else lblTitle.Text = folder.Substring(folder.LastIndexOf('\\') + 1);
        }

        void ClearBoard()
        {
            noteManager.Clear();
        }
        
        void Save()
        {
            noteDatas = new List<NoteData>();
            foreach (Control control in panelDisplay.Controls)
            {
                if (control.GetType() == typeof(NoteBlock))
                {
                    noteDatas.Add(((NoteBlock)control).GetData());
                }
            }
            if (folder == null) return;
            IO.Save(folder, noteDatas);
            lastSaveTime = DateTime.Now.TimeOfDay;
        }

        TimeSpan lastSaveAgo;
        string lastSaveText;
        private void timerStatus_Tick(object sender, EventArgs e)
        {
            // Save status
            lastSaveAgo = DateTime.Now.TimeOfDay - lastSaveTime;
            if (lastSaveAgo.TotalSeconds < 3) lastSaveText = "most";
            else if (lastSaveAgo.TotalSeconds < 20) lastSaveText = "az imént";
            else if (lastSaveAgo.TotalSeconds < 50) lastSaveText = "fél perce";
            else if (lastSaveAgo.TotalSeconds < 80) lastSaveText = "egy perce";
            else if (lastSaveAgo.TotalSeconds < 110) lastSaveText = "másfél perce";
            else lastSaveText = Math.Round(lastSaveAgo.TotalMinutes) + " perce (kattints ide bármikor mentéshez)";
            btnSave.Text = $"Utolsó mentés: " + lastSaveText;
        }

        private void saveNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Mentés...";
            Save();
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folder == "./") Process.Start(Directory.GetCurrentDirectory());
            else Process.Start(folder);
        }
    }
}
