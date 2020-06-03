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
        public static void Save(string folder, List<NoteData> notes)
        {
            string path = folder + "\\notes.b";

            if (notes.Count < 1)
            {
                File.Delete(path);
                return;
            }

            List<string> lines = new List<string>();
            foreach (NoteData nd in notes)
            {
                lines.Add(nd.ToString());
            }
            File.WriteAllLines(path, lines);
        }

        public static List<NoteData> Open(string folder)
        {
            if (!Directory.Exists(folder)) return null;

            string path = folder + "\\notes.b";
            if (!File.Exists(path)) return new List<NoteData>();

            List<NoteData> noteDatas = new List<NoteData>();
            string[] lines = File.ReadAllText(path).Split('▌', (char)StringSplitOptions.RemoveEmptyEntries);
            string[] data;
            NoteData nd;
            foreach (string line in lines)
            {
                data = line.Split('█');
                string[] colorValues = data[0].Split(';');
                if (data.Length > 5)
                {
                    List<string> tags = data[6].Split(';', (char)StringSplitOptions.RemoveEmptyEntries).ToList();
                    tags.RemoveAll(r => r.Trim().Length < 2);
                    nd = new NoteData()
                    {
                        HeaderColor = Color.FromArgb(int.Parse(colorValues[0]), int.Parse(colorValues[1]), int.Parse(colorValues[2])),
                        Location = new Point(int.Parse(data[1]), int.Parse(data[2])),
                        Size = new Size(int.Parse(data[3]), int.Parse(data[4])),
                        Text = data[5],
                        Tags = tags
                    };
                    noteDatas.Add(nd);
                }
            }
            return noteDatas;
        }

        public static List<string> GetSubBoards(string folder)
        {
            List<string> subBoards = Directory.GetDirectories(folder).ToList();

            for (int i = 0; i < subBoards.Count; i++)
            {
                subBoards[i] = subBoards[i].Substring(subBoards[i].LastIndexOf('\\') + 1);
            }

            return subBoards;
        }
    }

    public struct NoteData
    {
        public Color HeaderColor;
        public Point Location;
        public Size Size;
        public string Text;
        public List<string> Tags;

        public override string ToString()
        {
            string tagsString = string.Empty;
            if (Tags != null)
            {
                foreach (string tag in Tags) tagsString += tag + ";";
                if (tagsString.Length > 1) tagsString = tagsString.Remove(tagsString.Length - 1);
            }
            return $"{HeaderColor.R};{HeaderColor.G};{HeaderColor.B}█{Location.X}█{Location.Y}█{Size.Width}█{Size.Height}█{Text}█{tagsString}▌";
        }
    }
}
