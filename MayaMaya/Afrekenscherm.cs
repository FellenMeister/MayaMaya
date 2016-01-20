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
        }

        private void Btn_Bestelling_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bestellingscherm scherm = new Bestellingscherm(tafelId, naam);
            scherm.Show();
        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            MayaMaya.LogUit();
            this.Hide();
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
            decimal fooi = decimal.Parse(Txt_fooi.Text);
            string betaalwijze = "";
            // De betaalwijze meegeven aan de hand van de radiobuttons
            if (RBtn_Pin.Checked)
            {
                betaalwijze = "Pinnen";
            }
            else if (RBtn_Creditcard.Checked)
            {
                betaalwijze = "Creditcard";
            }
            else if (RBtn_Contant.Checked)
            {
                betaalwijze = "Contant";
            }

            MayaMaya.VoegToe(tafelId, Opmerking, betaalwijze, fooi);
            List_Rekening.Items.Clear();
            MayaMaya.LaadRekening(tafelId, List_Rekening);
        }

        private void Btn_Afrekenen_Click(object sender, EventArgs e)
        {
            MayaMaya.Afrekenen(tafelId);
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
