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
    public partial class Bestelling : Form
    {        public Bestelling()
        {

            InitializeComponent();
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
            Gereed scherm = new Gereed();
            scherm.Show();
        }

        private void Btn_Drinken_Click(object sender, EventArgs e)
        {

        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inlogscherm scherm = new Inlogscherm();
            scherm.Show();
        }
    }
}
