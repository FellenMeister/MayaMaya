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
        BestelSysteem MayaMaya;
        public Gereedscherm()
        {
            InitializeComponent();
            MayaMaya = new BestelSysteem("MayaMaya");
            string naam = MayaMaya.Naam();
            Lbl_Naam.Text = naam;
        }

        private void Btn_Tafels_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tafelscherm scherm = new Tafelscherm();
            scherm.Show();
        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            MayaMaya.LogUit();
            this.Hide();
        }
        
        private void Gereedscherm_Load(object sender, EventArgs e)
        {
            MayaMaya.ZetGereed();
            MayaMaya.ZetGeserveerd();
            MayaMaya.ToonBestelling(List_Bestellingen);
            MayaMaya.GereedDrinken(List_GereedDrinken);
            MayaMaya.GereedVoedsel(List_GereedEten);
        }

        private void Btn_Verwijder_Click(object sender, EventArgs e)
        {
            int index = List_Bestellingen.SelectedIndex;
            MayaMaya.VerwijderBestelling(index, List_Bestellingen);
            MayaMaya.ToonBestelling(List_Bestellingen);
            
        }

        private void Btn_EGeserveerd_Click(object sender, EventArgs e)
        {
            int index = List_GereedEten.SelectedIndex;
            MayaMaya.EtenGeserveerd(index);
            MayaMaya.ZetGeserveerd();
            List_GereedEten.Items.Clear();
            MayaMaya.GereedVoedsel(List_GereedEten);
        }

        private void Btn_DGeserveerd_Click_1(object sender, EventArgs e)
        {
            int index = List_GereedDrinken.SelectedIndex;
            MayaMaya.DrinkenGeserveerd(index);
            MayaMaya.ZetGeserveerd();
            List_GereedDrinken.Items.Clear();
            MayaMaya.GereedDrinken(List_GereedDrinken);
        }

        private void Btn_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Klik op een bestelling om deze te verwijderen of om aan te geven dat deze geserveerd is.");
        }
    }
}
