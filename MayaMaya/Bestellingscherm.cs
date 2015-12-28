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
    public partial class Bestellingscherm : Form
    {
        Methodes MayaMaya;
        public Bestellingscherm()
        {
            InitializeComponent();
            MayaMaya = new Methodes("MayaMaya");
        }

        private void Bestelling_Load(object sender, EventArgs e)
        {
            MayaMaya.LeesEten();
            MayaMaya.LeesDrinken();
            MayaMaya.ToonEten(List_Kaart);
        }

        private void Btn_Tafels_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Rekening_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Gereed_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gereedscherm scherm = new Gereedscherm();
            scherm.Show();
        }
        //Hallo
        private void Btn_Drinken_Click(object sender, EventArgs e)
        {
            Btn_Drinken.BackColor = Color.FromArgb(100, 82, 64);
            Btn_Eten.BackColor = Color.FromArgb(139, 74, 54);
            List_Kaart.Items.Clear();
            MayaMaya.ToonDrinken(List_Kaart);
        }

        private void Btn_Eten_Click(object sender, EventArgs e)
        {
            Btn_Eten.BackColor = Color.FromArgb(100, 82, 64);
            Btn_Drinken.BackColor = Color.FromArgb(139, 74, 54);
            List_Kaart.Items.Clear();
            MayaMaya.ToonEten(List_Kaart);
        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inlogscherm scherm = new Inlogscherm();
            scherm.Show();
        }

    }
}
