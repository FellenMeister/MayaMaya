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
    public partial class Keukenvoorraadscherm : Form
    {
        BestelSysteem MayaMaya;
        public Keukenvoorraadscherm()
        {
            InitializeComponent();
            MayaMaya = new BestelSysteem("MayaMaya");
            string naam = MayaMaya.Naam();
            Lbl_Naam.Text = naam;
        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            MayaMaya.LogUit();
            this.Hide();
        }

        private void Keukenvoorraadscherm_Load(object sender, EventArgs e)
        {
            MayaMaya.VoedselVoorraad(List_Voorraad);
        }

        private void Btn_Keuken_Click(object sender, EventArgs e)
        {
            this.Hide();
            Keukenscherm scherm = new Keukenscherm();
            scherm.Show();
        }

        private void Btn_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hier staat de voorraad van de gerechten.");
        }
    }
}
