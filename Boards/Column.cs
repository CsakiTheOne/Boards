using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libc.Forms;

namespace Boards
{
    public partial class BoardColumn : UserControl, IItem
    {
        #region Interface
        public string ItemType => ItemTypes.Column;

        public event EventHandler Interact;

        public string GetItemData()
        {
            return $"{ItemType}►{HeaderColor.R};{HeaderColor.G};{HeaderColor.B}█{Location.X}█{Location.Y}█{Size.Width}█{Size.Height}█{Text}█▌";
        }

        public void SetItemData(string data, string extra = null)
        {
            string[] d = data.Split('►')[1].Split('█');
            HeaderColor = Color.FromArgb(int.Parse(d[0].Split(';')[0]), int.Parse(d[0].Split(';')[1]), int.Parse(d[0].Split(';')[2]));
            if (extra == null || !extra.Contains("keepLocation")) Location = new Point(int.Parse(d[1]), int.Parse(d[2]));
            Size = new Size(int.Parse(d[3]), int.Parse(d[4]));
            Text = d[5];
        }

        public void Snap()
        {
            SendToBack();
            if (Left < 0) Left = 0;
            if (Top < 0) Top = 0;
            if ((Left + 16) % 50 != 0) Left = (int)(Math.Round((Left + 16) / Global.GridSize) * Global.GridSize);
            Top = (int)(Math.Round(Top / Global.GridSize) * Global.GridSize);
            if ((Width - 32) % 50 != 0) Width = (int)(Math.Round((Width - 32) / Global.GridSize) * Global.GridSize);

            if (Left % 50 == 0) Left -= 16;
            if (Width % 50 == 0) Width += 32;

            if (Parent != null)
            {
                List<Control> controls = new List<Control>();
                foreach (Control c in Parent.Controls) controls.Add(c);
                Control lastControl = null;
                try
                {
                    controls = controls.Where(r => ((IItem)r).ItemType != ItemTypes.Column && r != this && r.Left >= Left && r.Left + r.Width <= Left + Width).ToList();
                    lastControl = controls.First(r => r.Top + r.Height == controls.Max(s => s.Top + s.Height));
                }
                catch { }

                if (lastControl == null)
                {
                    Height = 100;
                }
                else
                {
                    Height = lastControl.Top + lastControl.Height + 16 - Top;
                }
            }
            movableComponent.Padding = new Padding(movableComponent.Padding.Left, movableComponent.Padding.Top, movableComponent.Padding.Right, Height - 75);
        }
        #endregion

        public Color HeaderColor { get; set; } = Color.FromArgb(40, 40, 40);

        [Browsable(true)]
        public new string Text { get => tb.Text; set => tb.Text = value; }

        MovableComponent movableComponent;
        ResizableComponent resizableComponent;

        public BoardColumn()
        {
            InitializeComponent();
            movableComponent = new MovableComponent(this, new Padding(32, 0, 32, 0));
            resizableComponent = new ResizableComponent(this, new Padding(32, 0, 32, 0)) { Top = false, Bottom = false };
        }

        public BoardColumn(string data)
        {
            InitializeComponent();
            movableComponent = new MovableComponent(this, new Padding(32, 0, 32, 0));
            resizableComponent = new ResizableComponent(this, new Padding(32, 0, 32, 0)) { Top = false, Bottom = false };
            SetItemData(data);
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() != DialogResult.OK) return;
            HeaderColor = cd.Color;
            Refresh();
            Interact?.Invoke(this, e);
        }

        private void resetColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HeaderColor = BackColor;
            Refresh();
            Interact?.Invoke(this, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
            Interact?.Invoke(this, e);
        }

        private void Column_MouseUp(object sender, MouseEventArgs e)
        {
            Snap();
            Interact?.Invoke(this, e);
        }

        private void Column_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(HeaderColor, 8), 0, 0, Width, 0);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), 0, 84, Width, Height);
        }
    }
}
