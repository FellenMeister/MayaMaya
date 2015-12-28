using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayaMaya
{
    class Tafel
    {
        int nummer;
        string status;
        
        public Tafel(int nummer, string status)
        {
            this.nummer = nummer;
            this.status = status;
        }

        public override string ToString()
        {
            return nummer.ToString();
        }
    }
}
