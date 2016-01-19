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
    public partial class Afrekenenscherm : Form
    {
        private int tafelId;
        private string naam;
        BestelSysteem MayaMaya;
        public Afrekenenscherm(int tafelId, string naam)
        {
            InitializeComponent();
            this.tafelId = tafelId;
            MayaMaya = new BestelSysteem("MayaMaya");
            this.naam = naam;
            lbl_Tafelnr.Text = naam;
        }

        private void Afrekenscherm_Load(object sender, EventArgs e)
        {
            Lbl_Naam.Text = MayaMaya.Naam();
            MayaMaya.LaadRekening(tafelId, List_Rekening);
            MayaMaya.LaadNaamOpmerking(Txt_AddNaam, Txt_AddOpmerking, tafelId);
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

        private void Btn_Afrekenen_Click(object sender, EventArgs e)
        {
            string betaalWijze = Txt_Betaalwijze.Text;
            int fooi = int.Parse(Txt_fooi.Text);
            MayaMaya.Afrekenen(betaalWijze, fooi, tafelId);
            this.Hide();
            Tafelscherm scherm = new Tafelscherm();
            scherm.Show();
        }

        private void Btn_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voeg optioneel een naam toe en druk op reserveer of bezet om de tafel deze status te geven. \n Voer een opmerking in en druk op toevoegen om deze toe te voegen. \n Geef aan op welke wijze betaalt wordt en een eventuele fooi. Druk hierna op afrekenen om de bestelling af te ronden.");
        }
    }
}
