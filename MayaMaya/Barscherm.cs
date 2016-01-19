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
    public partial class Barscherm : Form
    {
        BestelSysteem MayaMaya;
        public Barscherm()
        {
            InitializeComponent();
            MayaMaya = new BestelSysteem("MayaMaya");
            string naam = MayaMaya.Naam();
            Lbl_Naam.Text = naam;
        }

        private void List_Barscherm_Load(object sender, EventArgs e)
        {
            MayaMaya.ToonBestelling(List_Tafels);
        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            MayaMaya.LogUit();
            this.Hide();
        }

        private void Btn_Voorraad_Click(object sender, EventArgs e)
        {
            this.Hide();
            Barvoorraadscherm scherm = new Barvoorraadscherm();
            scherm.Show();
        }

        private void List_Tafels_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = List_Tafels.SelectedIndex;
            List_Bestelling.Items.Clear();
            MayaMaya.ToonDrinken(List_Bestelling, index);
        }

        private void Btn_Gereed_Click(object sender, EventArgs e)
        {
            int index = List_Tafels.SelectedIndex;
            MayaMaya.DrinkenGereed(index);
            MayaMaya.GereedDrinken(List_Gereed);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Klik op een tafel om de bestelling te kunnen inzien.\n Als deze bestelling gereed is klik dan op gereed.");
        }
    }
}
