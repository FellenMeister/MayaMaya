using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayaMaya
{
    class BestellingItem
    {
        public int bestellingId, itemId;
        public string item;

        public BestellingItem()
        { }

        public BestellingItem(int bId, int iId, string item)
        {
            this.bestellingId = bId;
            this.itemId = iId;
            this.item = item;
        }

        public override string ToString()
        {
            return item;
        }
    }
}
