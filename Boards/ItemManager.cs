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

        public event Action ItemsChanged;

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
            else if (item.StartsWith(ItemTypes.Bubi)) c = new Bubi(item);
            else if (item.StartsWith(ItemTypes.Column)) c = new BoardColumn(item);

            ((IItem)c).Interact += Item_Interact;
            Parent.Controls.Add(c);

            return c;
        }

        public Control Add(string item, Point location)
        {
            Control c = Add(item);
            c.Location = location;
            ((IItem)c).Snap();
            return c;
        }

        public void Clear()
        {
            Parent.Controls.Clear();
        }

        void Item_Interact(object sender, EventArgs e)
        {
            foreach (IItem item in Parent.Controls)
            {
                item.Snap();
            }
            ItemsChanged?.Invoke();
        }
    }
}
