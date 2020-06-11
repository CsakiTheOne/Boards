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
    public partial class NoteBlock : UserControl, IItem
    {
        #region Interface
        public event EventHandler Interact;
        public string ItemType => ItemTypes.Note;

        public string GetItemData()
        {
            string tagsString = string.Empty;
            if (Tags != null)
            {
                foreach (string tag in Tags) tagsString += tag + ";";
                if (tagsString.Length > 1) tagsString = tagsString.Remove(tagsString.Length - 1);
            }
            return $"{ItemType}►{HeaderColor.R};{HeaderColor.G};{HeaderColor.B}█{Location.X}█{Location.Y}█{Size.Width}█{Size.Height}█{Text}█{tagsString}█▌";
        }

        public void SetItemData(string data, string extra = null)
        {
            string[] d = data.Split('►')[1].Split('█');
            HeaderColor = Color.FromArgb(int.Parse(d[0].Split(';')[0]), int.Parse(d[0].Split(';')[1]), int.Parse(d[0].Split(';')[2]));
            if (extra == null || !extra.Contains("keepLocation")) Location = new Point(int.Parse(d[1]), int.Parse(d[2]));
            Size = new Size(int.Parse(d[3]), int.Parse(d[4]));
            Text = d[5];
            prevText = Text;
            Tags = d[6].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            SetTransparent(HeaderColor == Color.FromArgb(1, 1, 1));
            RefreshData();
        }

        public void Snap()
        {
            if (SnapToGrid)
            {
                if (Left < 0) Left = 0;
                if (Top < 0) Top = 0;
                Left = (int)(Math.Round(Left / Global.GridSize) * Global.GridSize);
                Top = (int)(Math.Round(Top / Global.GridSize) * Global.GridSize);
                Width = (int)(Math.Round(Width / Global.GridSize) * Global.GridSize);
                Height = (int)(Math.Round(Height / Global.GridSize) * Global.GridSize);
            }
            BringToFront();
            RefreshData();
        }
        #endregion

        public Color HeaderColor { get; set; } = Color.FromArgb(40, 40, 40);
        public bool SnapToGrid { get; set; } = true;
        public bool Maximized
        {
            get => Tags.Contains("maximized");
            set
            {
                if (value) Tags.Add("maximized");
                else Tags.Remove("maximized");
                RefreshData();
            }
        }
        public bool Locked
        {
            get => Tags.Contains("locked");
            set
            {
                if (value) Tags.Add("locked");
                else Tags.Remove("locked");
                RefreshData();
            }
        }
        [Browsable(true)]
        public new string Text { get => tb.Text; set => tb.Text = value; }
        public List<string> Tags { get; set; } = new List<string>();

        MovableComponent movableComponent;
        ResizableComponent resizableComponent;

        public NoteBlock(List<string> tags = null)
        {
            InitializeComponent();
            if (tags != null) Tags = tags;
            InitializeComponent2();
        }

        public NoteBlock(string text, List<string> tags = null)
        {
            InitializeComponent();
            if (tags != null) Tags = tags;
            InitializeComponent2();
            tb.Text = text;
        }

        public NoteBlock(string data)
        {
            InitializeComponent();
            InitializeComponent2();
            SetItemData(data);
        }

        void InitializeComponent2()
        {
            Interact += NoteBlock_Interact;
            movableComponent = new MovableComponent(this, new Padding(16, 0, 16, 16));
            resizableComponent = new ResizableComponent(this, new Padding(16, 0, 16, 16)) { Top = false };
            RefreshData();
        }

        private void Global_ClipboardChanged(object sender, EventArgs e)
        {
            pasteToolStripMenuItem.Visible = Global.Clipboard.Item != null;
        }

        private void tb_DoubleClick(object sender, EventArgs e)
        {
            Maximized = !Maximized;
        }

        private void NoteBlock_Interact(object sender, EventArgs e)
        {
            BringToFront();
            RefreshData();
        }

        void RefreshData()
        {
            while (tagsToolStripMenuItem.DropDownItems.Count > 1)
                tagsToolStripMenuItem.DropDownItems.RemoveAt(1);
            ToolStripMenuItem tagItem;
            foreach (string tag in Tags)
            {
                tagItem = new ToolStripMenuItem();
                tagItem.Text = tag;
                tagItem.Click += TagItem_Click;
                tagsToolStripMenuItem.DropDownItems.Add(tagItem);
            }

            if (Tags.Contains("noborder")) BorderStyle = BorderStyle.None;

            if (Tags.Contains("forceborder")) BorderStyle = BorderStyle.FixedSingle;

            SetMaximize(Tags.Contains("maximized"));

            tb.ReadOnly = Tags.Contains("locked");
            lockToolStripMenuItem.Checked = Tags.Contains("locked");

            BackColor = Tags.Contains("colorblock") ? HeaderColor : Color.FromArgb(40, 40, 40);
            tb.ForeColor = Tags.Contains("colorblock") ? Color.White : Color.Silver;

            UpdateFocus();
        }

        private void NoteBlock_MouseUp(object sender, MouseEventArgs e)
        {
            Snap();
            Interact?.Invoke(this, new EventArgs());
        }

        #region Resize
        bool normalized = true;
        void SetMaximize(bool value)
        {
            if (value == normalized)
            {
                Dock = value ? DockStyle.Fill : DockStyle.None;
                if (!value)
                {
                    Width = 300;
                    Height = 100;
                    Left = Parent.Width / 2 - Width;
                    Top = Parent.Height / 2 - Height;
                }
            }
            SnapToGrid = !value;
            normalized = !value;
            movableComponent.Active = !value;
            resizableComponent.Active = !value;
        }
        #endregion

        #region Recolor
        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = Color.FromArgb(40, 40, 40);

            if (cd.ShowDialog() != DialogResult.OK) return;

            SetTransparent(false);
            HeaderColor = cd.Color;
            Interact?.Invoke(this, e);
        }

        private void resetColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTransparent(false);
            Interact?.Invoke(this, e);
        }

        private void transparentNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTransparent(!transparentNoteToolStripMenuItem.Checked);
            Interact?.Invoke(this, e);
        }

        public void SetTransparent(bool value)
        {
            if (value)
            {
                HeaderColor = Color.FromArgb(1, 1, 1);
                BackColor = Color.FromArgb(18, 18, 18);
                BorderStyle = BorderStyle.None;
            }
            else
            {
                if (HeaderColor == Color.FromArgb(1, 1, 1)) HeaderColor = Color.FromArgb(40, 40, 40);
                BackColor = Color.FromArgb(40, 40, 40);
                BorderStyle = BorderStyle.FixedSingle;
            }
            transparentNoteToolStripMenuItem.Checked = value;
            tb.BackColor = BackColor;
        }
        #endregion

        #region Tags
        private void tbTagAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter) return;

            Tags.Add(tbTagAdd.Text);
            tbTagAdd.Text = "";
            Interact?.Invoke(this, e);
        }

        private void TagItem_Click(object sender, EventArgs e)
        {
            Tags.Remove(((ToolStripMenuItem)sender).Text);
            Interact?.Invoke(this, e);
        }
        #endregion

        #region Context menu
        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locked = !Locked;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.Clipboard.Set(GetItemData());
            Parent.Controls.Remove(this);
            Interact?.Invoke(this, e);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.Clipboard.Set(GetItemData());
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.Clipboard.Item == null || !Global.Clipboard.Item.StartsWith(ItemTypes.Note)) return;

            SetItemData(Global.Clipboard.Item, "keepLocation");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
            Interact?.Invoke(this, e);
        }

        private void tagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A címkék plusz infót tárolnak egy jegyzetről. Módosításuk csak haladó felhasználóknak ajánlott!", "Címkék");
        }
        #endregion

        #region Focus
        bool focusControl;
        bool focusSubControl;

        private void NoteBlock_MouseEnter(object sender, EventArgs e)
        {
            focusControl = true;
            UpdateFocus();
        }

        private void NoteBlock_MouseLeave(object sender, EventArgs e)
        {
            focusControl = false;
            UpdateFocus();
        }

        private void tb_MouseEnter(object sender, EventArgs e)
        {
            focusSubControl = true;
            UpdateFocus();
        }

        private void tb_MouseLeave(object sender, EventArgs e)
        {
            focusSubControl = false;
            UpdateFocus();
        }

        void UpdateFocus()
        {
            if ((focusControl || focusSubControl) && !Locked && !Tags.Contains("nofocus"))
            {
                tb.BackColor = Color.FromArgb(BackColor.R / 10 * 9, BackColor.G / 10 * 9, BackColor.B / 10 * 9);
            }
            else tb.BackColor = BackColor;
        }
        #endregion

        #region Drag drop
        private void lblDragDrop_MouseDown(object sender, MouseEventArgs e)
        {
            lblDragDrop.DoDragDrop(tb.Text, DragDropEffects.Copy);
        }

        private void lblDragDrop_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void NoteBlock_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text)) e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }

        private void NoteBlock_DragDrop(object sender, DragEventArgs e)
        {
            tb.Text = e.Data.GetData(DataFormats.Text).ToString();
        }
        #endregion

        string prevText;
        private void timerTextObserver_Tick(object sender, EventArgs e)
        {
            if (prevText == tb.Text) return;

            prevText = tb.Text;
            Interact?.Invoke(this, new EventArgs());
        }

        private void NoteBlock_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(HeaderColor, 8), 0, 0, Width, 0);
        }
    }
}
