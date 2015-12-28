using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayaMaya
{
    class Medewerker
    {
        int id, wachtwoord;
        string naam, functie;
        bool ingelogd;

        public Medewerker(int id, string naam, string functie, int wachtwoord, bool ingelogd)
        {
            this.id = id;
            this.naam = naam;
            this.functie = functie;
            this.wachtwoord = wachtwoord;
            this.ingelogd = ingelogd;
        }

        public override string ToString()
        {
            return naam;
        }

    }
}
