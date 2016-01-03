using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayaMaya
{
    class BestellingItem
    {
        int bestellingId, itemId;

        public BestellingItem(int bId, int iId)
        {
            this.bestellingId = bId;
            this.itemId = iId;
        }
    }
}
