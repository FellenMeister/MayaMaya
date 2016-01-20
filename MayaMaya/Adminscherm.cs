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
        BestelSysteem MayaMaya;

        string functie;
        public Admin()
        {
            InitializeComponent();
            MayaMaya = new BestelSysteem("MayaMaya");
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
        private void List_Medewerkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = List_Medewerkers.SelectedIndex;
            string naam, functie;
            int wachtwoord;
            MayaMaya.ToonWerker(index, out naam, out wachtwoord, out functie);
            txtAddnaam.Text = naam;
            txtWachtwoord.Text = wachtwoord.ToString();
            if (functie == "Keuken")
            {
                RBtn_Keuken.Select();
            }
            else if (functie == "Bediening")
            {
                RBtn_Bediening.Select();
            }
            else if (functie == "Bar")
            {
                RBtn_Bar.Select();
            }

        }

        private void Btn_Verwijderen_Click(object sender, EventArgs e)
        {
            int index = List_Medewerkers.SelectedIndex;
            MayaMaya.VerwijderMedewerker(index);
            List_Medewerkers.Items.Clear();
            MayaMaya.LeesMedewerkers();
            MayaMaya.ToonMedewerker(List_Medewerkers);
        }

        private void Btn_Wijzigen_Click(object sender, EventArgs e)
        {
            int index = List_Medewerkers.SelectedIndex;

            // De functie meegeven aan de hand van de radiobuttons
            if (RBtn_Keuken.Checked)
            {
                functie = "Keuken";
            }
            else if (RBtn_Bediening.Checked)
            {
                functie = "Bediening";
            }
            else if (RBtn_Bar.Checked)
            {
                functie = "Bar";
            }
            MayaMaya.WijzigMedewerker(index, txtAddnaam, txtWachtwoord, functie);
            List_Medewerkers.Items.Clear();
            MayaMaya.LeesMedewerkers();
            MayaMaya.ToonMedewerker(List_Medewerkers);
        }

        private void Btn_Toevoegen_Click(object sender, EventArgs e)
        {          
            if(RBtn_Keuken.Checked)
            {
                functie = "Keuken";
            }
            else if (RBtn_Bediening.Checked)
            {
                functie = "Bediening";
            }
            else if (RBtn_Bar.Checked)
            {
                functie = "Bar";
            }
            MayaMaya.AddMedewerker(List_Medewerkers, txtAddnaam, txtWachtwoord, functie);
            List_Medewerkers.Items.Clear();
            MayaMaya.LeesMedewerkers();
            MayaMaya.ToonMedewerker(List_Medewerkers);
        }

        private void Btn_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Account verwijderen:\n Selecteer een account en klik op de knop 'Verwijderen'.\n\n Account toevoegen:\n Vul de gegevens in in de daarvoor bestemde tesktvakken en klik op de knop 'Toevoegen'.");
        }

    }   
}
