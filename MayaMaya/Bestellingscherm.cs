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
        bool eten = true;
        public Bestellingscherm()
        {
            InitializeComponent();
            MayaMaya = new Methodes("MayaMaya");
            string naam = MayaMaya.Naam();
            Lbl_Naam.Text = naam;
            lbl_Tafelnr.Text = MayaMaya.Tafelnaam();

        }

        private void Bestelling_Load(object sender, EventArgs e)
        {
            MayaMaya.LeesEten();
            MayaMaya.LeesDrinken();
            MayaMaya.ToonEten(List_Kaart);
        }

        private void List_Kaart_SelectedIndexChanged(object sender, EventArgs e)
        {
            int item = List_Kaart.SelectedIndex;
            MayaMaya.NeemOp(item, eten);
        }

        private void Btn_Tafels_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tafelscherm scherm = new Tafelscherm();
            scherm.Show();
        }

        private void Btn_Rekening_Click(object sender, EventArgs e)
        {
            this.Hide();
            Afrekenscherm scherm = new Afrekenscherm();
            scherm.Show();
        }

        private void Btn_Gereed_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gereedscherm scherm = new Gereedscherm();
            scherm.Show();
        }
        
        private void Btn_Drinken_Click(object sender, EventArgs e)
        {
            Btn_Drinken.BackColor = Color.FromArgb(100, 82, 64);
            Btn_Eten.BackColor = Color.FromArgb(139, 74, 54);
            List_Kaart.Items.Clear();
            MayaMaya.ToonDrinken(List_Kaart);
            eten = false;
        }

        private void Btn_Eten_Click(object sender, EventArgs e)
        {
            Btn_Eten.BackColor = Color.FromArgb(100, 82, 64);
            Btn_Drinken.BackColor = Color.FromArgb(139, 74, 54);
            List_Kaart.Items.Clear();
            MayaMaya.ToonEten(List_Kaart);
            eten = true;
        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            MayaMaya.LogUit();
            this.Hide();
        }
    }
}
