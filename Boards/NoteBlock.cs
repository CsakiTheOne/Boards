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
    public partial class NoteBlock : UserControl
    {
        public event EventHandler Interact;
        public double GridSize { get; set; } = 50;
        public bool SnapToGrid { get; set; } = true;
        public bool Maximized
        {
            get => Tags.Contains("maximized");
            set
            {
                if (value) Tags.Add("maximized");
                else Tags.Remove("maximized");
                Interact?.Invoke(this, new EventArgs());
            }
        }
        public bool Locked
        {
            get => Tags.Contains("locked");
            set
            {
                if (value) Tags.Add("locked");
                else Tags.Remove("locked");
                Interact?.Invoke(this, new EventArgs());
            }
        }
        [Browsable(true)]
        public new string Text { get => tb.Text; set => tb.Text = value; }
        public List<string> Tags { get; set; } = new List<string>();

        public int OldLeft { get; private set; }
        public int OldTop { get; private set; }
        public int OldWidth { get; private set; }
        public int OldHeight { get; private set; }

        Formsc.MovableComponent movableComponent;
        Formsc.ResizableComponent resizableComponent;

        public NoteBlock()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        public NoteBlock(NoteData noteData)
        {
            InitializeComponent();
            InitializeComponent2();
            SetData(noteData);
        }

        void InitializeComponent2()
        {
            Interact += NoteBlock_Interact;
            Global.ClipboardChanged += Global_ClipboardChanged;
            movableComponent = new Formsc.MovableComponent(this, new Padding(16, 0, 16, 16));
            resizableComponent = new Formsc.ResizableComponent(this, new Padding(16, 0, 16, 16)) { Top = false };
            Snap();
        }

        private void Global_ClipboardChanged(object sender, EventArgs e)
        {
            pasteToolStripMenuItem.Visible = ((NoteData)sender).Text != "null";
        }

        private void tb_DoubleClick(object sender, EventArgs e)
        {
            Maximized = !Maximized;
        }

        private void NoteBlock_Interact(object sender, EventArgs e)
        {
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
        }

        public void Snap()
        {
            if (SnapToGrid)
            {
                if (Left < 0) Left = 0;
                if (Top < 0) Top = 0;
                Left = (int)(Math.Round(Left / GridSize) * GridSize);
                Top = (int)(Math.Round(Top / GridSize) * GridSize);
                Width = (int)(Math.Round(Width / GridSize) * GridSize);
                Height = (int)(Math.Round(Height / GridSize) * GridSize);
            }
            BringToFront();
            RefreshData();
        }

        #region Resize
        bool normalized = true;
        void SetMaximize(bool value)
        {
            SnapToGrid = !value;
            if (value && normalized)
            {
                normalized = false;
                OldLeft = Left;
                OldTop = Top;
                OldWidth = Width;
                OldHeight = Height;
                Dock = DockStyle.Fill;
                Cursor = Cursors.Default;
            }
            else if (!value && !normalized)
            {
                normalized = true;
                Dock = DockStyle.None;
                Cursor = Cursors.SizeAll;
            }
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
            header.BackColor = cd.Color;
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
                header.BackColor = Color.FromArgb(1, 1, 1);
                BackColor = Color.FromArgb(18, 18, 18);
                BorderStyle = BorderStyle.None;
                header.Visible = false;
            }
            else
            {
                if (header.BackColor == Color.FromArgb(1, 1, 1)) header.BackColor = Color.FromArgb(40, 40, 40);
                BackColor = Color.FromArgb(40, 40, 40);
                BorderStyle = BorderStyle.FixedSingle;
                header.Visible = true;
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

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locked = !Locked;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.SetClipboard(GetData());
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.SetClipboard(GetData());
            Parent.Controls.Remove(this);
            Interact?.Invoke(this, e);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetData(Global.ClipboardNode, true);
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

        private void tb_TextChanged(object sender, EventArgs e)
        {
            Interact?.Invoke(this, e);
        }

        private void NoteBlock_MouseUp(object sender, MouseEventArgs e)
        {
            Snap();
            Interact?.Invoke(this, new EventArgs());
        }

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

        #region Data
        public void SetData(NoteData noteData, bool keepLocation = false)
        {
            header.BackColor = noteData.HeaderColor;
            if (!keepLocation) Location = noteData.Location;
            Size = noteData.Size;
            Text = noteData.Text;
            if (noteData.Tags != null) Tags = noteData.Tags;
            SetTransparent(header.BackColor == Color.FromArgb(1, 1, 1));
        }

        public NoteData GetData()
        {
            NoteData nd = new NoteData();
            nd.HeaderColor = header.BackColor;
            if (Maximized)
            {
                nd.Location = new Point(OldLeft, OldHeight);
                nd.Size = new Size(OldWidth, OldHeight);
            }
            else
            {
                nd.Location = Location;
                nd.Size = Size;
            }
            nd.Text = Text;
            nd.Tags = Tags;
            return nd;
        }
        #endregion
    }
}
