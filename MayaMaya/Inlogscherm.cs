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
    public partial class Inlogscherm : Form
    {
        Methodes MayaMaya;
        public Inlogscherm()
        {
            InitializeComponent();
            MayaMaya = new Methodes("MayaMaya");
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            int wachtwoord = int.Parse(Txt_Ww.Text);
            this.Hide();
            MayaMaya.LogIn(wachtwoord);
        }

        private void Btn_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voer je wachtwoord in en druk op oke.\nBent u uw wachtwoord vergeten neem contact op met de Admin.");
        }
    }
}    