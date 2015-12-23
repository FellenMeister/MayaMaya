using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayaMaya
{
    class Item
    {
        int id, categorieId;
        decimal btw;
        float prijs;
        string naam;

        public Item(int id, int categorieId, string naam, float prijs, decimal btw)
        {
            this.id = id;
            this.categorieId = categorieId;
            this.btw = btw;
            this.prijs = prijs;
            this.naam = naam;
        }

        public override string ToString()
        {
            return naam;
        }

    }
}
