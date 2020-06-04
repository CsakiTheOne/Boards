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
            return $"{ItemType}►{Color.R};{Color.G};{Color.B}█{Location.X}█{Location.Y}█{Folder}█▌";
        }

        public void SetItemData(string data, string extra = null)
        {
            string[] d = data.Split('►')[1].Split('█');
            string[] c = d[0].Split(';');
            Color = Color.FromArgb(int.Parse(c[0]), int.Parse(c[1]), int.Parse(c[2]));
            if (extra == null || !extra.Contains("keepLocation")) Location = new Point(int.Parse(d[1]), int.Parse(d[2]));
            Folder = d[3];
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

        public Color Color { get; set; } = Color.FromArgb(40, 40, 40);
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
            Snap();
        }

        public BoardIcon(string data)
        {
            InitializeComponent();
            movableComponent = new Formsc.MovableComponent(this, new Padding(0));
            SetItemData(data);
            Snap();
        }

        Brush bgBrush;
        Brush brush;
        private void boardIcon_Paint(object sender, PaintEventArgs e)
        {
            if (mouseDown)
            {
                bgBrush = new SolidBrush(Color.FromArgb(Color.R + 20 > 255 ? 255 : Color.R + 20, Color.G + 20 > 255 ? 255 : Color.G + 20, Color.B + 20 > 255 ? 255 : Color.B + 20));
                brush = new SolidBrush(Color.FromArgb(Color.R + 40 > 255 ? 255 : Color.R + 40, Color.G + 40 > 255 ? 255 : Color.G + 40, Color.B + 40 > 255 ? 255 : Color.B + 40));
            }
            else
            {
                bgBrush = new SolidBrush(Color);
                brush = new SolidBrush(Color.FromArgb(Color.R + 20 > 255 ? 255 : Color.R + 20, Color.G + 20 > 255 ? 255 : Color.G + 20, Color.B + 20 > 255 ? 255 : Color.B + 20));
            }

            float unit = 12f;

            e.Graphics.FillRectangle(bgBrush, 20, 10, 60, 60);
            e.Graphics.FillRectangle(brush, 20 + unit, 10 + unit, unit, unit);
            e.Graphics.FillRectangle(brush, 20 + unit * 3, 10 + unit, unit, unit);
            e.Graphics.FillRectangle(brush, 20 + unit, 10 + unit * 3, unit, unit);
            e.Graphics.FillRectangle(brush, 20 + unit * 3, 10 + unit * 3, unit, unit);
        }

        bool mouseDown = false;
        private void boardIcon_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            Refresh();
        }

        private void boardIcon_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
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

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() != DialogResult.OK) return;
            Color = cd.Color;
            bgBrush = new SolidBrush(Color);
            brush = new SolidBrush(Color.FromArgb(Color.R + 20 > 255 ? 255 : Color.R + 20, Color.G + 20 > 255 ? 255 : Color.G + 20, Color.B + 20 > 255 ? 255 : Color.B + 20));
            Refresh();
        }

        private void colorResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color = Color.FromArgb(40, 40, 40);
            bgBrush = new SolidBrush(Color);
            brush = new SolidBrush(Color.FromArgb(Color.R + 20 > 255 ? 255 : Color.R + 20, Color.G + 20 > 255 ? 255 : Color.G + 20, Color.B + 20 > 255 ? 255 : Color.B + 20));
            Refresh();
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
