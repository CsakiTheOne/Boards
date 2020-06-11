using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boards
{
    public static class Global
    {
        public static double GridSize { get; set; } = 50;

        public static Dictionary<string, string> Variables { get; set; }

        #region Folder
        public static event Action FolderChanged;
        public static string Folder { get; private set; } = "./";
        public static void SetFolder(string folder)
        {
            Folder = folder;
            FolderChanged?.Invoke();
        }
        #endregion

        #region Clipboard
        public static class Clipboard
        {
            public static string Item { get; private set; } = null;

            public static void Set(string item)
            {
                Item = item;
            }
            public static void Clear()
            {
                Item = null;
            }
        }
        #endregion
    }
}
