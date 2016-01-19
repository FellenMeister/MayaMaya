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
    public partial class Keukenscherm : Form
    {
        BestelSysteem MayaMaya;
        public Keukenscherm()
        {
            InitializeComponent();
            MayaMaya = new BestelSysteem("MayaMaya");
            string naam = MayaMaya.Naam();
            Lbl_Naam.Text = naam;
        }

        private void Btn_Voorraad_Click(object sender, EventArgs e)
        {
            this.Hide();
            Keukenvoorraadscherm scherm = new Keukenvoorraadscherm();
            scherm.Show();
        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            MayaMaya.LogUit();
            this.Hide();
        }

        private void Keukenscherm_Load(object sender, EventArgs e)
        {
            MayaMaya.ToonBestelling(List_Tafels);
        }

        private void Btn_Gereed_Click(object sender, EventArgs e)
        {
            int index = List_Tafels.SelectedIndex;
            MayaMaya.VoedselGereed(index);
            MayaMaya.GereedVoedsel(List_Gereed);
        }

        private void Btn_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Klik op een tafel om de bestelling te kunnen inzien.\n Als deze bestelling gereed is klik dan op gereed.");
        }

        private void List_Tafels_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = List_Tafels.SelectedIndex;
            List_Bestelling.Items.Clear();
            MayaMaya.ToonVoedsel(List_Bestelling, index);

        }
    }
}
