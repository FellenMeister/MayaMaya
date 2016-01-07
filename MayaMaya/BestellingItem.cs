using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayaMaya
{
    class BestellingItem
    {
        public int bestellingId, categorie_id, itemId;
        public string item;

        public BestellingItem()
        { }

        public BestellingItem(int bId, int catId, int iId, string item)
        {
            bestellingId = bId;
            categorie_id = catId;
            itemId = iId;
            this.item = item;
        }

        public override string ToString()
        {
            return item;
        }
    }
}
