using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libc;

namespace Boards
{
    public partial class BoardIcon : UserControl, IItem
    {
        #region Interface
        public event EventHandler Interact;
        public string ItemType => ItemTypes.Board;

        public string GetItemData()
        {
            return $"{ItemType}►{Location.X}█{Location.Y}█{Folder}█▌";
        }

        public void SetItemData(string data, string extra = null)
        {
            string[] d = data.Split('►')[1].Split('█');
            if (extra == null || !extra.Contains("keepLocation")) Location = new Point(int.Parse(d[0]), int.Parse(d[1]));
            Folder = d[2];
        }

        public void Snap()
        {
            if (Left < 0) Left = 0;
            if (Top < 0) Top = 0;
            Left = (int)(Math.Round(Left / Global.GridSize) * Global.GridSize);
            Top = (int)(Math.Round(Top / Global.GridSize) * Global.GridSize);
            BringToFront();
        }
        #endregion

        public string Folder
        {
            get => folder;
            set
            {
                folder = value;
                lblText.Text = folder.Substring(folder.LastIndexOf('\\') + 1);
                if (value == "./") lblText.Text = "Fő mappa";
                Interact?.Invoke(this, new EventArgs());
            }
        }

        string folder;

        Formsc.MovableComponent movableComponent;

        public BoardIcon()
        {
            InitializeComponent();
            movableComponent = new Formsc.MovableComponent(this, new Padding(0));
        }

        public BoardIcon(string data)
        {
            InitializeComponent();
            movableComponent = new Formsc.MovableComponent(this, new Padding(0));
            SetItemData(data);
        }

        Brush bgBrush = new SolidBrush(Color.FromArgb(40, 40, 40));
        private void boardIcon_Paint(object sender, PaintEventArgs e)
        {
            float unit = 12f;
            Brush brush = new SolidBrush(Color.FromArgb(64, 64, 64));

            e.Graphics.FillRectangle(bgBrush, 15, 10, 50, 50);
            e.Graphics.FillRectangle(brush, 10 + unit, 5 + unit, unit, unit);
            e.Graphics.FillRectangle(brush, 10 + unit * 3, 5 + unit, unit, unit);
            e.Graphics.FillRectangle(brush, 10 + unit, 5 + unit * 3, unit, unit);
            e.Graphics.FillRectangle(brush, 10 + unit * 3, 5 + unit * 3, unit, unit);
        }

        private void boardIcon_MouseDown(object sender, MouseEventArgs e)
        {
            bgBrush = new SolidBrush(Color.FromArgb(64, 64, 64));
            Refresh();
        }

        private void boardIcon_MouseUp(object sender, MouseEventArgs e)
        {
            bgBrush = new SolidBrush(Color.FromArgb(40, 40, 40));
            Refresh();
            Snap();
            Interact?.Invoke(this, new EventArgs());
        }

        #region Context menu
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "A fő mappa kiválasztásához nyomj a mégsére.";
            DialogResult res = fbd.ShowDialog();
            if (res == DialogResult.OK) Folder = fbd.SelectedPath;
            else if (res == DialogResult.Cancel) Folder = "./";
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.Clipboard.Set(GetItemData());
            Parent.Controls.Remove(this);
            Interact?.Invoke(this, new EventArgs());
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.Clipboard.Set(GetItemData());
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.Clipboard.Item == null || !Global.Clipboard.Item.StartsWith(ItemTypes.Board)) return;

            SetItemData(Global.Clipboard.Item, "keepLocation");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
            Interact?.Invoke(this, new EventArgs());
        }
        #endregion

        private void BoardIcon_DoubleClick(object sender, EventArgs e)
        {
            Global.SetFolder(Folder);
        }
    }
}
