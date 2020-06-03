using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boards
{
    public static class Global
    {
        public static event EventHandler ClipboardChanged;

        public static NoteData ClipboardNode { get; private set; } = new NoteData() { Text = "null" };

        public static void SetClipboard(NoteData noteData)
        {
            ClipboardNode = noteData;
            ClipboardChanged(noteData, new EventArgs());
        }
    }
}
