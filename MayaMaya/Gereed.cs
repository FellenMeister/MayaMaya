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
    public partial class Gereed : Form
    {
        public Gereed()
        {
            InitializeComponent();
        }

        private void Btn_Bestelling_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bestelling scherm = new Bestelling();
            scherm.Show();
        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inlogscherm scherm = new Inlogscherm();
            scherm.Show();
        }
    }
}
