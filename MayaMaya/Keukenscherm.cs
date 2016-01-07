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
        Methodes MayaMaya;
        public Keukenscherm()
        {
            InitializeComponent();
            MayaMaya = new Methodes("MayaMaya");
            string naam = MayaMaya.Naam();
            Lbl_Naam.Text = naam;
        }

        private void Btn_Voorraad_Click(object sender, EventArgs e)
        {

        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            MayaMaya.LogUit();
            this.Hide();
        }

        private void Keukenscherm_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Gereed_Click(object sender, EventArgs e)
        {

        }

        private void List_Bestelling_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Help_Click(object sender, EventArgs e)
        {

        }
    }
}
