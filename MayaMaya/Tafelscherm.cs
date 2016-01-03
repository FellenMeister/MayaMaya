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
    public partial class Tafelscherm : Form
    {
        Methodes MayaMaya;
        public Tafelscherm()
        {
            InitializeComponent();
            MayaMaya = new Methodes("MayaMaya");
            string naam = MayaMaya.Naam();
            Lbl_Naam.Text = naam;
        }

        private void Tafelscherm_Load(object sender, EventArgs e)
        {
            MayaMaya.TafelKleur(Btn_Tafel1, 1);
            MayaMaya.TafelKleur(Btn_Tafel2, 2);
            MayaMaya.TafelKleur(Btn_Tafel3, 3);
            MayaMaya.TafelKleur(Btn_Tafel4, 4);
            MayaMaya.TafelKleur(Btn_Tafel5, 5);
            MayaMaya.TafelKleur(Btn_Tafel6, 6);
            MayaMaya.TafelKleur(Btn_Tafel7, 7);
            MayaMaya.TafelKleur(Btn_Tafel8, 8);
            MayaMaya.TafelKleur(Btn_Tafel9, 9);
            MayaMaya.TafelKleur(Btn_Tafel10, 10);
        }

        private void Btn_Tafel1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Tafel2_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Tafel3_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Tafel4_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Tafel5_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Tafel6_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Tafel7_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Tafel8_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Tafel9_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Tafel10_Click(object sender, EventArgs e)
        {

        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            MayaMaya.LogUit();
            this.Hide();
        }
    }
}
