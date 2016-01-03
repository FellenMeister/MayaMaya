using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayaMaya
{
    class Methodes
    {
        // variabellen
        public string naam;

        // lijsten
       public List<Item> eten = new List<Item>();
       public List<Item> drinken = new List<Item>();

        // tijd
        private TimeSpan tijd = new TimeSpan(17, 0, 0);
        private TimeSpan nu = DateTime.Now.TimeOfDay;

        // methode
        public Methodes(string naam)
        {
            this.naam = naam;
        }

        // Algemeen

        public void LogIn(int wachtwoord)
        {
            int id, password = 0;
            string naam, functie = "";
            bool ingelogd;
            bool login = false;

            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select * From medewerker where medewerker_wachtwoord = @password; update medewerker set medewerker_ingelogd = 1 where medewerker_wachtwoord = @password", conn);
            command.Parameters.Add("@password", SqlDbType.Int).Value = wachtwoord;
            SqlDataReader reader = command.ExecuteReader();           
            while (reader.Read())

            {
                id = (int)reader["medewerker_id"];
                naam = (string)reader["medewerker_naam"];
                functie = (string)reader["medewerker_functie"];
                password = (int)reader["medewerker_wachtwoord"];
                ingelogd = (bool)reader["medewerker_ingelogd"];
                login = true;

                    switch (functie)
                    {
                        case "Admin":
                            Admin Admin = new Admin();
                            Admin.Show();
                            return;

                        case "Bediening":
                            Tafelscherm tafel = new Tafelscherm();
                            tafel.Show();
                            Bestellingscherm Bediening = new Bestellingscherm();
                            Bediening.Show();
                            return;

                        case "Keuken":
                            Keukenscherm Keuken = new Keukenscherm();
                            Keuken.Show();
                            return;

                        case "Bar":
                            Barscherm Bar = new Barscherm();
                            Bar.Show();
                            return;

                        case "Manager":
                            Managerscherm Manager = new Managerscherm();
                            Manager.Show();
                            return;

                        default:
                            return;
                    }
            }
            conn.Close();
            if (login == false)
            {
                Inlogscherm inlog = new Inlogscherm();
                inlog.Show();
                MessageBox.Show("Verkeerd wachtwoord ingevoerd");
            }
        }

        public void LogUit()
        {
            DialogResult logoutresult = MessageBox.Show("Weet je zeker dat je wilt uitloggen?", "Logout", MessageBoxButtons.YesNo);
            if (logoutresult == DialogResult.Yes)
            {
                
                Inlogscherm scherm = new Inlogscherm();
                scherm.Show();
                MessageBox.Show("Je bent uitgelogd");

                string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();

                SqlCommand command = new SqlCommand("update medewerker set medewerker_ingelogd = 0 where medewerker_ingelogd = @log", conn);
                command.Parameters.Add("@log", SqlDbType.Int).Value = 1;
                SqlDataReader reader = command.ExecuteReader();
                conn.Close();
            }
        }

        public string Naam()
        {
            string naamMedewerker = "";

            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand command = new SqlCommand("select medewerker_naam from medewerker where medewerker_ingelogd = @log", conn);
            command.Parameters.Add("@log", SqlDbType.Bit).Value = 1;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                naamMedewerker = (string)reader["medewerker_naam"];
            }
            conn.Close();

            return naamMedewerker;
        }

        //Tafels

            public void TafelKleur(Button tafel, int nummer)
        {
            string status = " ";
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select * From tafel where nummer = @nummer", conn);
            command.Parameters.Add("@nummer", SqlDbType.Int).Value = nummer;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())

            {
                status = (string)reader["status"];
               
                switch (status)
                {
                    case "Gereserveerd":
                        tafel.ForeColor = Color.Orange;
                        return;

                    case "Bezet":
                        tafel.ForeColor = Color.Red;
                        return;

                    default:
                        return;
                }
            }
            conn.Close();
        }
        
        // Bediening

        public void LeesEten()
        {
            if (nu < tijd)
            {
                string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();

                SqlCommand command = new SqlCommand("Select * From items where categorie_id < 4", conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())

                {
                    int id = (int)reader["item_id"];
                    int categorieId = (int)reader["categorie_id"];
                    string naam = (string)reader["item_naam"];
                    float prijs = (float)(double)reader["item_prijs"];
                    decimal btw = (decimal)reader["item_btw"];

                    Item item = new Item(id, categorieId, naam, prijs, btw);
                    eten.Add(item);
                }
                conn.Close();
            }
            else
            {
                string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();

                SqlCommand command = new SqlCommand("Select * From items Where categorie_id between 4 and 7", conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())

                {
                    int id = (int)reader["item_id"];
                    int categorieId = (int)reader["categorie_id"];
                    string naam = (string)reader["item_naam"];
                    float prijs = (float)(double)reader["item_prijs"];
                    decimal btw = (decimal)reader["item_btw"];

                    Item item = new Item(id, categorieId, naam, prijs, btw);
                    eten.Add(item);
                }
                conn.Close();
            }
        }

        public void LeesDrinken()
        {
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select * From items Where categorie_id > 7", conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())

            {
                int id = (int)reader["item_id"];
                int categorieId = (int)reader["categorie_id"];
                string naam = (string)reader["item_naam"];
                float prijs = (float)(double)reader["item_prijs"];
                decimal btw = (decimal)reader["item_btw"];

                Item item = new Item(id, categorieId, naam, prijs, btw);
                drinken.Add(item);
            }
            conn.Close();
        }
        
        public void ToonEten(ListBox lijst)
        {
            foreach(Item product in eten)
            {
                lijst.Items.Add(product);
            }
            lijst.SelectedIndex = 0;
        }

        public void ToonDrinken(ListBox lijst)
        {
            foreach (Item product in drinken)
            {
                lijst.Items.Add(product);
            }
            lijst.SelectedIndex = 0;
        }

        // Keuken


        // Bar


        // Manager


        // Admin
    }
}
