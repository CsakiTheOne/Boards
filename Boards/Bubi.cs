using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Libc;

namespace Boards
{
    public partial class Bubi : UserControl, IItem
    {
        #region Interface
        public string ItemType => "Bubi";

        public event EventHandler Interact;

        public string GetItemData()
        {
            return $"{ItemType}►{Location.X}█{Location.Y}█▌";
        }

        public void SetItemData(string data, string extra = null)
        {
            string[] d = data.Split('►')[1].Split('█');
            if (extra == null || !extra.Contains("keepLocation")) Location = new Point(int.Parse(d[0]), int.Parse(d[1]));
        }

        public void Snap()
        {
            threadSnapAnimation = new Thread(SnapAnimation);
            threadSnapAnimation.Start();
        }
        #endregion

        public int Clicks = 0;

        Thread threadSnapAnimation;
        Formsc.MovableComponent movableComponent;

        public Bubi()
        {
            InitializeComponent();
            movableComponent = new Formsc.MovableComponent(this, Padding.Empty);
        }

        public Bubi(string data)
        {
            InitializeComponent();
            movableComponent = new Formsc.MovableComponent(this, Padding.Empty);
            SetItemData(data);
        }

        void SnapAnimation()
        {
            while (Left > 0)
            {
                Invoke(new Action(() => { Left = (Left - 10) / 2; Refresh(); }));
                Thread.Sleep(10);
            }
        }

        private void Bubi_Paint(object sender, PaintEventArgs e)
        {
            Random rdm = new Random(Location.X * Location.Y + Clicks);
            Color rc = Color.FromArgb(rdm.Next(256), rdm.Next(256), rdm.Next(256));
            e.Graphics.FillEllipse(new SolidBrush(rc), 0, 0, Width, Height);
        }

        private void Bubi_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(Clicks.ToString());
                Parent.Controls.Remove(this);
            }
            else
            {
                Clicks++;
                Refresh();
                Snap();
            }
            Interact?.Invoke(this, e);
        }

        private void Bubi_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.None) Refresh();
        }
    }
}
