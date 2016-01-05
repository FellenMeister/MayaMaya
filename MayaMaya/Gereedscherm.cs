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
    public partial class Gereedscherm : Form
    {
        private int tafelId;
        private string naam;
        Methodes MayaMaya;
        public Gereedscherm(int tafelId, string naam)
        {
            InitializeComponent();
            this.tafelId = tafelId;
            MayaMaya = new Methodes("MayaMaya");
            this.naam = naam;
            lbl_Tafelnr.Text = naam;
        }

        private void Btn_Tafels_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tafelscherm scherm = new Tafelscherm();
            scherm.Show();
        }

        private void Btn_Bestelling_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bestellingscherm scherm = new Bestellingscherm(tafelId, naam);
            scherm.Show();
        }

        private void Btn_Rekening_Click(object sender, EventArgs e)
        {
            this.Hide();
            Afrekenscherm scherm = new Afrekenscherm(tafelId, naam);
            scherm.Show();
        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            MayaMaya.LogUit();
            this.Hide();
        }

       
    }
}
