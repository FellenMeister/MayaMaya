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
        int bestellingId, medewerkerId, tafelNummer;
        decimal totaalBedrag, betaaldBedrag;
        bool status;
        string betaalwijze;


        public Bestelling(int bid, int mid, int tid, decimal tbedrag, decimal bbedrag, bool status, string betaal)
        {
            nu = DateTime.Now;
            bestellingId = bid;
            medewerkerId = mid;
            tafelNummer = tid;
            totaalBedrag = tbedrag;
            betaaldBedrag = bbedrag;
            this.status = status;
            betaalwijze = betaal;
        }
    }
}
