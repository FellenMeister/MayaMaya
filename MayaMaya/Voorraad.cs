using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayaMaya
{
    class Voorraad
    {
        string naam;
        int voorraad;
        public Voorraad(string naam, int voorraad)
        {
            this.naam = naam;
            this.voorraad = voorraad;
        }

        public override string ToString()
        {
            return naam + " \t" + voorraad;
        }
    }
}
