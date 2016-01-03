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
        public List<BestellingItem> bestelling = new List<BestellingItem>();
       public List<Medewerker> medewerkers = new List<Medewerker>();

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

        public void SelecteerTafel(int tafelnummer, string naam)
        {
            int medewerker_id = 0;

            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand command = new SqlCommand("select medewerker_id from medewerker where medewerker_naam = @naam", conn);
            command.Parameters.Add("@naam", SqlDbType.NVarChar).Value = naam;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                medewerker_id = (int)reader["medewerker_id"];
            }
            conn.Close();
            conn.Open();
            command = new SqlCommand("insert into bestelling (medewerker_id, tafel_nummer, status) values (@mId, @tflNr, @status)", conn);
            command.Parameters.Add("@mId", SqlDbType.Int).Value = medewerker_id;
            command.Parameters.Add("@tflNr", SqlDbType.Int).Value = tafelnummer;
            command.Parameters.Add("@status", SqlDbType.NVarChar).Value = "in progress";
            reader = command.ExecuteReader();
            conn.Close();
        }

        //public string Tafelnummer(int nummer)
        //{
        //    string knop = "";
        //    switch (nummer)
        //    {
        //        case 1:
        //            knop = "Tafel 1";
        //            break;
        //        case 2:
        //            knop = "Tafel 2";
        //            break;
        //        case 3:
        //            knop = "Tafel 3";
        //            break;
        //        case 4:
        //            knop = "Tafel 4";
        //            break;
        //        case 5:
        //            knop = "Tafel 5";
        //            break;
        //        case 6:
        //            knop = "Tafel 6";
        //            break;
        //        case 7:
        //            knop = "Tafel 7";
        //            break;
        //        case 8:
        //            knop = "Tafel 8";
        //            break;
        //        case 9:
        //            knop = "Tafel 9";
        //            break;
        //        case 10:
        //            knop = "Tafel 10";
        //            break;
        //        default:
        //            return knop = "ja";
        //    }
        //    return knop;
        //}

        
        
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

        // Bestelling
        //tafelnummer klopt niet
        public void NeemOp(int item, bool eten)
        {
            int bestellingId = 0, item_id = 0; 
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            if (eten)
            {
                if (nu > tijd)
                {
                    SqlCommand command = new SqlCommand("Select bestelling_id From bestelling where tafel_nummer = @tafel; select item_id from item where item_id = @itemnr", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    command.Parameters.Add("@tafel", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@itemnr", SqlDbType.Int).Value = item + 9;
                    while (reader.Read())
                    {
                        bestellingId = (int)reader["bestelling_id"];
                        item_id = (int)reader["item_id"];
                        BestellingItem bestelitem = new BestellingItem(bestellingId, item_id);
                        bestelling.Add(bestelitem);
                    }
                }
                else
                {
                    SqlCommand command = new SqlCommand("Select bestelling_id From bestelling where tafel_nummer = @tafel; select item_id from item where item_id = @itemnr", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    command.Parameters.Add("@tafel", SqlDbType.Int).Value = 1;
                    command.Parameters.Add("@itemnr", SqlDbType.Int).Value = item;
                    while (reader.Read())
                    {
                        bestellingId = (int)reader["bestelling_id"];
                        item_id = (int)reader["item_id"];
                        BestellingItem bestelitem = new BestellingItem(bestellingId, item_id);
                        bestelling.Add(bestelitem);
                    }
                }
            }
            else
            {
                SqlCommand command = new SqlCommand("Select bestelling_id From bestelling where tafel_nummer = @tafel; select item_id from item where item_id = @itemnr", conn);
                SqlDataReader reader = command.ExecuteReader();
                command.Parameters.Add("@tafel", SqlDbType.Int).Value = 1;
                command.Parameters.Add("@itemnr", SqlDbType.Int).Value = item + 20;
                while (reader.Read())
                {
                    bestellingId = (int)reader["bestelling_id"];
                    item_id = (int)reader["item_id"];
                    BestellingItem bestelitem = new BestellingItem(bestellingId, item_id);
                    bestelling.Add(bestelitem);
                }
            }
        }

        public void ToonOpname(ListBox lijst)
        {
            foreach (BestellingItem item in bestelling)
            {
                lijst.Items.Add(item);
            }
            lijst.SelectedIndex = 0;
        }
        // Keuken


        // Bar


        // Manager


        // Admin
        public void LeesMedewerkers()
        {
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select * From medewerker", conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())

            {
                int id = (int)reader["medewerker_id"];
                string naam = (string)reader["medewerker_naam"];
                string functie = (string)reader["medewerker_functie"];
                int wachtwoord = (int)reader["medewerker_wachtwoord"];
                bool ingelogd = (bool)reader["medewerker_ingelogd"];

                Medewerker medewerker = new Medewerker(id, naam, functie, wachtwoord, ingelogd);
                medewerkers.Add(medewerker);
            }
            conn.Close();
        }

        public void ToonMedewerker(ListBox lijst)
        {
            foreach (Medewerker medewerker in medewerkers)
            {
                lijst.Items.Add(medewerker);
            }
            lijst.SelectedIndex = 0;
        }

        public void AddMedewerker()
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlCommand cmd = new SqlCommand("INSERT INTO Data (Name, PhoneNo, Address) VALUES (@Name, @PhoneNo, @Address)");
            //    cmd.CommandType = CommandType.Text;
            //    cmd.Connection = connection;
            //    cmd.Parameters.AddWithValue("@Name", txtName.Text);
            //    cmd.Parameters.AddWithValue("@PhoneNo", txtPhone.Text);
            //    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            //    connection.Open();
            //    cmd.ExecuteNonQuery();
            //}

            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO medewerker (medewerker_id, medewerker_naam, medewerker_functie, medewerker_wachtwoord, medewerker_ingelogd) VALUES @medewerker_id, @medewerker_naam, @medewerker_functie, @medewerker_wachtwoord, @medewerker_ingelogd)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@medewerker_naam", "");
        }
    }
}
