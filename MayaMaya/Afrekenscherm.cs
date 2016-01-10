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

        private void Afrekenscherm_Load(object sender, EventArgs e)
        {
            Lbl_Naam.Text = MayaMaya.Naam();
        }

        private void Btn_Bestelling_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bestellingscherm scherm = new Bestellingscherm(tafelId, naam);
            scherm.Show();
        }

        private void Btn_Gereed_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gereedscherm scherm = new Gereedscherm(tafelId, naam);
            scherm.Show();
        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            MayaMaya.LogUit();
            this.Hide();
        }

        private void Btn_Reserveren_Click(object sender, EventArgs e)
        {
            MayaMaya.ReserveerTafel(tafelId);
        }

        private void Btn_Bezet_Click(object sender, EventArgs e)
        {
            string bezoeker = Txt_AddNaam.Text; 
            MayaMaya.BezetTafel(tafelId, bezoeker);
        }

        private void Btn_Tafels_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tafelscherm scherm = new Tafelscherm();
            scherm.Show();
        }

        private void Btn_Voegtoe_Click(object sender, EventArgs e)
        {        
            string Opmerking = Txt_AddOpmerking.Text;            
            MayaMaya.VoegOpmerkingToe(tafelId, Opmerking);
         
        }

      


       
       
    }
}
