using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boards
{
    public partial class BoardIcon : UserControl
    {
        public bool IsSpecial { get; set; } = false;
        [Browsable(true)]
        public override string Text { get => lblText.Text; set => lblText.Text = value; }

        public BoardIcon()
        {
            InitializeComponent();
        }

        private void pbIcon_Paint(object sender, PaintEventArgs e)
        {
            float unit = pbIcon.Width / 5f;
            Brush brush = new SolidBrush(Color.FromArgb(64, 64, 64));

            if (IsSpecial)
            {
                e.Graphics.FillRectangle(brush, unit * 2, unit * 2, unit, unit);
            }
            else
            {
                e.Graphics.FillRectangle(brush, unit, unit, unit, unit);
                e.Graphics.FillRectangle(brush, unit * 3, unit, unit, unit);
                e.Graphics.FillRectangle(brush, unit, unit * 3, unit, unit);
                e.Graphics.FillRectangle(brush, unit * 3, unit * 3, unit, unit);
            }
        }

        private void pbIcon_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void pbIcon_MouseDown(object sender, MouseEventArgs e)
        {
            pbIcon.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void pbIcon_MouseUp(object sender, MouseEventArgs e)
        {
            pbIcon.BackColor = Color.FromArgb(40, 40, 40);
        }
    }
}
