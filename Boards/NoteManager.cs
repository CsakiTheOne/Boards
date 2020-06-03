using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boards
{
    class NoteManager
    {
        public Control Parent { get; set; }

        public event EventHandler NotesChanged;

        public NoteManager() { }
        public NoteManager(Control noteParent)
        {
            Parent = noteParent;
        }

        internal void Add(NoteBlock note)
        {
            note.Interact += Note_Interact;
            Parent.Controls.Add(note);
            note.Snap();
            NotesChanged?.Invoke(note, new EventArgs());
        }

        public void Add(NoteBlock note, Point location)
        {
            Add(note);
            note.Location = location;
        }

        public void Clear()
        {
            while (Parent.Controls.Count > 1)
            {
                foreach (Control control in Parent.Controls)
                {
                    if (control.GetType() != typeof(Label))
                    {
                        Parent.Controls.Remove(control);
                    }
                }
            }
        }

        void Note_Interact(object sender, EventArgs e)
        {
            ((Control)sender).BringToFront();
            NotesChanged?.Invoke(sender, e);
        }
    }
}
