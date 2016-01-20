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
    public partial class Tafelscherm : Form
    {
        BestelSysteem MayaMaya;
        public int tafelnummer;
        public Tafelscherm()
        {
            InitializeComponent();
            MayaMaya = new BestelSysteem("MayaMaya");

            string naam = MayaMaya.Naam();
            Lbl_Naam.Text = naam;
        }

        private void Tafelscherm_Load(object sender, EventArgs e)
        {
            MayaMaya.TafelKleur(Btn_Tafel1, 1);
            MayaMaya.TafelKleur(Btn_Tafel2, 2);
            MayaMaya.TafelKleur(Btn_Tafel3, 3);
            MayaMaya.TafelKleur(Btn_Tafel4, 4);
            MayaMaya.TafelKleur(Btn_Tafel5, 5);
            MayaMaya.TafelKleur(Btn_Tafel6, 6);
            MayaMaya.TafelKleur(Btn_Tafel7, 7);
            MayaMaya.TafelKleur(Btn_Tafel8, 8);
            MayaMaya.TafelKleur(Btn_Tafel9, 9);
            MayaMaya.TafelKleur(Btn_Tafel10, 10);
        }

        private void Btn_Tafel1_Click(object sender, EventArgs e)
        {
            tafelnummer = 1; this.Hide();
            MayaMaya.SelecteerTafel(1, Lbl_Naam.Text);
            Bestellingscherm Bediening = new Bestellingscherm(1, "Tafel 1");
            Bediening.Show();

        }

        private void Btn_Tafel2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MayaMaya.SelecteerTafel(2, Lbl_Naam.Text);
            Bestellingscherm Bediening = new Bestellingscherm(2, "Tafel 2");
            Bediening.Show();
            tafelnummer = 2;
        }

        private void Btn_Tafel3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MayaMaya.SelecteerTafel(3, Lbl_Naam.Text);
            Bestellingscherm Bediening = new Bestellingscherm(3, "Tafel 3");
            Bediening.Show();
            tafelnummer = 3;
        }

        private void Btn_Tafel4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MayaMaya.SelecteerTafel(4, Lbl_Naam.Text);
            Bestellingscherm Bediening = new Bestellingscherm(4, "Tafel 4");
            Bediening.Show();
            tafelnummer = 4;
        }

        private void Btn_Tafel5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MayaMaya.SelecteerTafel(5, Lbl_Naam.Text);
            Bestellingscherm Bediening = new Bestellingscherm(5, "Tafel 5");
            Bediening.Show();
            tafelnummer = 5;
        }

        private void Btn_Tafel6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MayaMaya.SelecteerTafel(6, Lbl_Naam.Text);
            Bestellingscherm Bediening = new Bestellingscherm(6, "Tafel 6");
            Bediening.Show();
            tafelnummer = 6;
        }

        private void Btn_Tafel7_Click(object sender, EventArgs e)
        {
            this.Hide();
            MayaMaya.SelecteerTafel(7, Lbl_Naam.Text);
            Bestellingscherm Bediening = new Bestellingscherm(7, "Tafel 7");
            Bediening.Show();
            tafelnummer = 7;
        }

        private void Btn_Tafel8_Click(object sender, EventArgs e)
        {
            this.Hide();
            MayaMaya.SelecteerTafel(8, Lbl_Naam.Text);
            Bestellingscherm Bediening = new Bestellingscherm(8, "Tafel 8");
            Bediening.Show();
        }

        private void Btn_Tafel9_Click(object sender, EventArgs e)
        {
            this.Hide();
            MayaMaya.SelecteerTafel(9, Lbl_Naam.Text);
            Bestellingscherm Bediening = new Bestellingscherm(9, "Tafel 9");
            Bediening.Show();
        }

        private void Btn_Tafel10_Click(object sender, EventArgs e)
        {
            this.Hide();
            MayaMaya.SelecteerTafel(10, Lbl_Naam.Text);
            Bestellingscherm Bediening = new Bestellingscherm(10, "Tafel 10");
            Bediening.Show();
        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            MayaMaya.LogUit();
            this.Hide();
        }

        private void Btn_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Klik op een tafel om deze te selecteren.\nGroen = vrij. \nRood = bezet \nBlauw = gereed \nViolet = wacht");
        }

        private void Btn_Gereed_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gereedscherm scherm = new Gereedscherm();
            scherm.Show();
        }
    }
}
