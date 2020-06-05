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

        public Control Add(string item)
        {
            Control c = null;

            if (item.StartsWith(ItemTypes.Note)) c = new NoteBlock(item); 
            else if (item.StartsWith(ItemTypes.Board)) c = new BoardIcon(item);

            ((IItem)c).Interact += Item_Interact;
            Parent.Controls.Add(c);
            ItemsChanged?.Invoke(item, new EventArgs());

            return c;
        }

        public Control Add(string item, Point location)
        {
            Control c = Add(item);
            c.Location = location;
            return c;
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
