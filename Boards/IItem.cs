using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boards
{
    interface IItem
    {
        string ItemType { get; }

        event EventHandler Interact;

        string GetItemData();
        void SetItemData(string data, string extra = null);
        void Snap();
    }

    public static class ItemTypes
    {
        public static string Board => "Board";
        public static string Bubi => "Bubi";
        public static string Note => "Note";
    }
}
