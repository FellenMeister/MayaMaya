using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayaMaya
{
    class Bestelling
    {
        DateTime nu;
        public int bestellingId, medewerkerId, tafelNummer;
        decimal totaalBedrag;
        string status;

        public Bestelling(int bId, int tId)
        {
            bestellingId = bId;
            tafelNummer = tId;
        }

        public Bestelling(DateTime datum, int bid, int mid, int tid, decimal tbedrag, string status)
        {
            nu = datum;
            bestellingId = bid;
            medewerkerId = mid;
            tafelNummer = tid;
            totaalBedrag = tbedrag;
            this.status = status;
        }

        public override string ToString()
        {
            return "T" + tafelNummer +"   Bnr" + bestellingId + "   " + nu;
        }
    }
}
