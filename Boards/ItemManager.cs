using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boards
{
    class ItemManager
    {
        public Control Parent { get; set; }

        public event EventHandler ItemsChanged;

        public ItemManager() { }
        public ItemManager(Control itemsParent)
        {
            Parent = itemsParent;
        }

        public void Add(string item)
        {
            if (item.StartsWith(ItemTypes.Note))
            {
                NoteBlock nb = new NoteBlock(item);
                nb.Interact += Item_Interact;
                Parent.Controls.Add(nb);
            }
            else if (item.StartsWith(ItemTypes.Board))
            {
                BoardIcon bi = new BoardIcon(item);
                bi.Interact += Item_Interact;
                Parent.Controls.Add(bi);
            }
            ItemsChanged?.Invoke(item, new EventArgs());
        }

        public void Add(string item, Point location)
        {
            if (item.StartsWith(ItemTypes.Note))
            {
                NoteBlock nb = new NoteBlock(item);
                nb.Location = location;
                nb.Interact += Item_Interact;
                Parent.Controls.Add(nb);
            }
            else if (item.StartsWith(ItemTypes.Board))
            {
                BoardIcon bi = new BoardIcon(item);
                bi.Location = location;
                bi.Interact += Item_Interact;
                Parent.Controls.Add(bi);
            }
            ItemsChanged?.Invoke(item, new EventArgs());
        }

        public void Clear()
        {
            Parent.Controls.Clear();
        }

        void Item_Interact(object sender, EventArgs e)
        {
            ((Control)sender).BringToFront();
            ItemsChanged?.Invoke(sender, e);
        }
    }
}
