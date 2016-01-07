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
        private DateTime datum = DateTime.Now;

        // Constructor
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

                    case "Wachtend":
                        tafel.ForeColor = Color.BurlyWood;
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
            command = new SqlCommand("insert into bestelling (medewerker_id, tafel_nummer, status) values (@mId, @tflNr, @status) ", conn);
            command.Parameters.Add("@mId", SqlDbType.Int).Value = medewerker_id;
            command.Parameters.Add("@tflNr", SqlDbType.Int).Value = tafelnummer;
            command.Parameters.Add("@status", SqlDbType.NVarChar).Value = "in progress";
            reader = command.ExecuteReader();
            conn.Close();
        }

        public string Tafelnaam()
        {
            string tafel = "";

            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand command = new SqlCommand("select tafel_naam from nieuwetafel", conn);
            command.Parameters.Add("@naam", SqlDbType.NVarChar).Value = naam;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tafel = (string)reader["tafel_naam"];
            }
            conn.Close();

            return tafel;
        }

        // bediening
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
                    decimal prijs = (decimal)(decimal)reader["item_prijs"];
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
                    decimal prijs = (decimal)reader["item_prijs"];
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
                decimal prijs = (decimal)reader["item_prijs"];
                decimal btw = (decimal)reader["item_btw"];

                Item item = new Item(id, categorieId, naam, prijs, btw);
                drinken.Add(item);
            }
            conn.Close();
        }

        public void ToonEten(ListBox lijst)
        {
            foreach (Item product in eten)
            {
                lijst.Items.Add(product);
            }
            lijst.SelectedIndex = -1;
        }

        public void ToonDrinken(ListBox lijst)
        {
            foreach (Item product in drinken)
            {
                lijst.Items.Add(product);
            }
            lijst.SelectedIndex = -1;
        }

        // Bestelling
        //afmaken
        public void NeemOp(int tafelnr, int item, bool eten)
        {
            int bestellingId = 0, item_id = 0, voorraad = 0;
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand command;
            SqlDataReader reader;

            conn.Open();

            if (eten)
            {
                if (nu > tijd)
                {
                    // ...
                    command = new SqlCommand("Select bestelling_id From bestelling where tafel_nummer = @tafel", conn);
                    command.Parameters.Add("@tafel", SqlDbType.Int).Value = tafelnr;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        bestellingId = (int)reader["bestelling_id"];
                    }
                    conn.Close();
                    conn.Open();
                    command = new SqlCommand("Select item_id, categorie_id, item_naam, item_voorraad From items where item_id = @itemnr", conn);
                    command.Parameters.Add("@itemnr", SqlDbType.Int).Value = item + 10;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        item_id = (int)reader["item_id"];
                        string naam = (string)reader["item_naam"];
                        int categorie = (int)reader["categorie_id"];
                        voorraad = (int)reader["item_voorraad"];
                        if (voorraad > 0)
                        {
                            BestellingItem bestelitem = new BestellingItem(bestellingId, categorie, item_id, naam);
                            bestelling.Add(bestelitem);
                        }
                        else
                        {
                            MessageBox.Show("Het geselecteerde gerecht is niet meer op voorraad.");
                            continue;
                        }
                    }
                    conn.Close();
                }
                else
                {
                    // ...
                    command = new SqlCommand("Select bestelling_id From bestelling where tafel_nummer = @tafel", conn);
                    command.Parameters.Add("@tafel", SqlDbType.Int).Value = tafelnr;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        bestellingId = (int)reader["bestelling_id"];
                    }
                    conn.Close();
                    conn.Open();
                    command = new SqlCommand("Select item_id, categorie_id, item_naam, item_voorraad From items where item_id = @itemnr", conn);
                    command.Parameters.Add("@itemnr", SqlDbType.Int).Value = item + 10;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        item_id = (int)reader["item_id"];
                        string naam = (string)reader["item_naam"];
                        int categorie = (int)reader["categorie_id"];
                        voorraad = (int)reader["item_voorraad"];
                        BestellingItem bestelitem = new BestellingItem(bestellingId, categorie, item_id, naam);
                        bestelling.Add(bestelitem);
                    }
                    conn.Close();
                }
            }
            else
            {
                // ...
                command = new SqlCommand("Select bestelling_id From bestelling where tafel_nummer = @tafel", conn);
                command.Parameters.Add("@tafel", SqlDbType.Int).Value = tafelnr;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bestellingId = (int)reader["bestelling_id"];
                }
                conn.Close();
                conn.Open();
                command = new SqlCommand("Select item_id, categorie_id, item_naam, item_voorraad From items where item_id = @itemnr", conn);
                command.Parameters.Add("@itemnr", SqlDbType.Int).Value = item + 10;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item_id = (int)reader["item_id"];
                    string naam = (string)reader["item_naam"];
                    int categorie = (int)reader["categorie_id"];
                    voorraad = (int)reader["item_voorraad"];
                    BestellingItem bestelitem = new BestellingItem(bestellingId, categorie, item_id, naam);
                    bestelling.Add(bestelitem);
                }
                conn.Close();
            }
            if (voorraad > 0)
            {
                conn.Open();
                command = new SqlCommand("update items set item_voorraad = @voorraad where item_id = @itemId", conn);
                command.Parameters.Add("@itemId", SqlDbType.Int).Value = item_id;
                command.Parameters.Add("@voorraad", SqlDbType.Int).Value = voorraad - 1;
                reader = command.ExecuteReader();
            }

            conn.Close();
        }

        public void ToonOpname(ListBox lijst)
        {
            lijst.Items.Clear();
            foreach (BestellingItem item in bestelling)
            {
                lijst.Items.Add(item.ToString());
            }
            lijst.SelectedIndex = -1;
        }

        public void verwijderOpname(int nr)
        {
            bestelling.Remove(bestelling[nr]);

            //command = new SqlCommand("update items set item_voorraad = @voorraad where item_id = @itemId", conn);
            //command.Parameters.Add("@itemId", SqlDbType.Int).Value = item_id;
            //command.Parameters.Add("@voorraad", SqlDbType.Int).Value = voorraad - 1;
            //reader = command.ExecuteReader();
        }



        public void PlaatsBestelling(ListBox lijst)
        {
            foreach (BestellingItem item in bestelling)
            {
                int iId = item.itemId;
                int bId = item.bestellingId;
                int cId = item.categorie_id;
                string naam = item.item;

                string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);

                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO bestelling_items (bestelling_id, categorie_id, item_id, item_naam, status) VALUES (@bId, @cId, @iId, @iNaam, @status)", conn);
                command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = bId;
                command.Parameters.AddWithValue("@cId", SqlDbType.Int).Value = cId;
                command.Parameters.AddWithValue("@iId", SqlDbType.Int).Value = iId;
                command.Parameters.AddWithValue("@iNaam", SqlDbType.NVarChar).Value = naam;
                command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "in progress";
                SqlDataReader reader = command.ExecuteReader();
                conn.Close();

                conn.Open();
                command = new SqlCommand("update bestelling set datum_tijd = @tijd where bestelling_id = @bId", conn);
                command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = bId;
                command.Parameters.AddWithValue("@tijd", SqlDbType.DateTime).Value = datum;
                reader = command.ExecuteReader();
                conn.Close();
            }
            lijst.Items.Clear();
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
            lijst.SelectedIndex = -1;
        }

        public void AddMedewerker(ListBox Lijst, TextBox naam, TextBox wachtwoord, string functie)
        {
            int ww = int.Parse(wachtwoord.Text);
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO medewerker (medewerker_naam, medewerker_functie, medewerker_wachtwoord, medewerker_ingelogd) VALUES (@medewerker_naam, @medewerker_functie, @medewerker_wachtwoord, @medewerker_ingelogd)", conn);
            cmd.Parameters.AddWithValue("@medewerker_naam", SqlDbType.NVarChar).Value = naam.Text;
            cmd.Parameters.AddWithValue("@medewerker_functie", SqlDbType.NVarChar).Value = functie;
            cmd.Parameters.AddWithValue("@medewerker_Wachtwoord", SqlDbType.Int).Value = ww;
            cmd.Parameters.AddWithValue("@medewerker_ingelogd", SqlDbType.Bit).Value = 0;
            SqlDataReader reader = cmd.ExecuteReader();
            conn.Close();
            
            medewerkers.Clear();
    }
        
        public void VerwijderMedewerker(int nummer)
        {
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM medewerker WHERE medewerker_id = @nummer", conn);
            cmd.Parameters.AddWithValue("@nummer", SqlDbType.Int).Value = nummer;
            SqlDataReader reader = cmd.ExecuteReader();
            conn.Close();

            medewerkers.Clear();

        }
    }
}
