using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayaMaya
{
    public partial class Afrekenscherm : Form
    {
        private int tafelId;
        private string naam;
        Methodes MayaMaya;
        public Afrekenscherm(int tafelId, string naam)
        {
            InitializeComponent();
            this.tafelId = tafelId;
            MayaMaya = new Methodes("MayaMaya");
            this.naam = naam;
            lbl_Tafelnr.Text = naam;
        }
    }
}
