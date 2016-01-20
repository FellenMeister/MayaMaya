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
    public partial class Bestellingscherm : Form
    {
        private int tafelId;
        private string tafel;
        BestelSysteem MayaMaya;
        bool eten = true;
        

        public Bestellingscherm(int tafelId, string tafel)
        {
            InitializeComponent();

            this.tafelId = tafelId;
            MayaMaya = new BestelSysteem("MayaMaya");
            this.tafel = tafel;
            lbl_Tafelnr.Text = tafel;
            string naam = MayaMaya.Naam();
            Lbl_naam.Text = naam;

        }

        private void Bestelling_Load(object sender, EventArgs e)
        {
            MayaMaya.LeesEten();
            MayaMaya.LeesDrinken();
            MayaMaya.ToonEten(List_Kaart);
        }

        private void List_Kaart_SelectedIndexChanged(object sender, EventArgs e)
        {
            int item = List_Kaart.SelectedIndex;
            MayaMaya.NeemOp(tafelId, item, eten);
            MayaMaya.ToonOpname(List_Bestelling);
        }

        private void Btn_Tafels_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tafelscherm scherm = new Tafelscherm();
            scherm.Show();
        }

        private void Btn_Rekening_Click(object sender, EventArgs e)
        {
            this.Hide();
            Afrekenenscherm scherm = new Afrekenenscherm(tafelId, tafel);
            scherm.Show();
        }
        
        private void Btn_Drinken_Click(object sender, EventArgs e)
        {
            Btn_Drinken.BackColor = Color.FromArgb(100, 82, 64);
            Btn_Eten.BackColor = Color.FromArgb(139, 74, 54);
            List_Kaart.Items.Clear();
            MayaMaya.ToonDrinken(List_Kaart);
            eten = false;
        }

        private void Btn_Eten_Click(object sender, EventArgs e)
        {
            Btn_Eten.BackColor = Color.FromArgb(100, 82, 64);
            Btn_Drinken.BackColor = Color.FromArgb(139, 74, 54);
            List_Kaart.Items.Clear();
            MayaMaya.ToonEten(List_Kaart);
            eten = true;
        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            MayaMaya.LogUit();
            this.Hide();
        }

        private void List_Bestelling_SelectedIndexChanged(object sender, EventArgs e)
        {
            int item = List_Bestelling.SelectedIndex;
            MayaMaya.verwijderOpname(item);
            MayaMaya.ToonOpname(List_Bestelling);
        }

        private void Btn_Plaats_Click(object sender, EventArgs e)
        {
            MayaMaya.PlaatsBestelling(List_Bestelling, tafelId);
        }

        private void Btn_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecteer een gerecht om deze toe te voegen aan de bestelling. \n Druk op een bestelitem om deze weer te verwijderen. \n Druk op plaats om de bestelling te plaatsen.");
        }
    }
}
