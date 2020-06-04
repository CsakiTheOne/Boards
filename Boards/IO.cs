using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boards
{
    static class IO
    {
        public static void Save(string folder, List<string> items)
        {
            string path = folder + "\\notes.b";

            if (items.Count < 1)
            {
                File.Delete(path);
                return;
            }

            File.WriteAllLines(path, items);
        }

        public static List<string> Open(string folder)
        {
            if (!Directory.Exists(folder)) return null;

            string path = folder + "\\notes.b";
            if (!File.Exists(path)) return new List<string>();

            string[] file = File.ReadAllText(path).Split('▌', (char)StringSplitOptions.RemoveEmptyEntries);
            List<string> items = new List<string>();

            foreach (string item in file) if (item.Length > 2) items.Add(item.Trim());

            return items;
        }
    }
}
