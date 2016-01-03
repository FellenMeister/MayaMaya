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
    public partial class Admin : Form
    {
        Methodes MayaMaya;
        public Admin()
        {
            InitializeComponent();
            MayaMaya = new Methodes("MayaMaya");
            string naam = MayaMaya.Naam();
            Lbl_naam.Text = naam;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            MayaMaya.LeesMedewerkers();
            MayaMaya.ToonMedewerker(List_Medewerkers);
        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            MayaMaya.LogUit();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }   
}
