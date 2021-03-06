﻿using System;
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
    class BestelSysteem
    {
        // Variabelen
        public string naam;

        // Lijsten
        public List<Item> eten = new List<Item>();
        public List<Item> drinken = new List<Item>();
        public List<BestellingItem> bestelling = new List<BestellingItem>();
        public List<Medewerker> medewerkers = new List<Medewerker>();
        public List<Bestelling> bestel = new List<Bestelling>();
        public List<Voorraad> voorraad = new List<Voorraad>();
        public List<Bestelling> bestellingen = new List<Bestelling>();
        public List<Bestelling> bestelEten = new List<Bestelling>();
        public List<Bestelling> bestelDrinken = new List<Bestelling>();

        // Tijd
        private TimeSpan tijd = new TimeSpan(18, 0, 0);
        private TimeSpan nu = DateTime.Now.TimeOfDay;
        private DateTime datum = DateTime.Now;

        // Constructor
        public BestelSysteem(string naam)
        {
            this.naam = naam;
        }

        // Algemeen
       
        // inloggen
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
        
        // uitloggen
        public void LogUit()
        {
            DialogResult logoutresult = MessageBox.Show("Weet je zeker dat je wilt uitloggen?", "Logout", MessageBoxButtons.YesNo);
            if (logoutresult == DialogResult.Yes)
            {

                Inlogscherm scherm = new Inlogscherm();
                scherm.Show();

                string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();

                SqlCommand command = new SqlCommand("update medewerker set medewerker_ingelogd = 0 where medewerker_ingelogd = @log", conn);
                command.Parameters.Add("@log", SqlDbType.Int).Value = 1;
                SqlDataReader reader = command.ExecuteReader();
                conn.Close();
            }
        }

        // Naam medewerker opnemen
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

        // Tafels

        // Tafelkleur aanpassen op status
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

                    case "Bezet":
                        tafel.ForeColor = Color.OrangeRed;
                        tafel.Text = "Tafel " + nummer + " Bezet";
                        return;

                    case "Wachtend":
                        tafel.ForeColor = Color.Violet;
                        tafel.Text = "Tafel " + nummer + " Wacht";
                        return;

                    case "Gereed":
                        tafel.ForeColor = Color.DeepSkyBlue;
                        tafel.Text = "Tafel " + nummer + " Gereed";

                        return;

                    default:
                        return;
                }
            }
            conn.Close();
        }

        // Een bestelling aanmaken als er een tafel geselecteerd wordt
        public void SelecteerTafel(int tafelnummer, string naam)
        {
            int medewerker_id = 0;
            int nr = 0;

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
            command = new SqlCommand("select tafel_nummer from bestelling where tafel_nummer = @tafel", conn);
            command.Parameters.Add("@tafel", SqlDbType.Int).Value = tafelnummer;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                nr = (int)reader["tafel_nummer"];
            }
            conn.Close();

            // Als bestelling er al in staat en de tafel dus al gebruikt wordt zal er geen nieuwe bestelling aan worden gemaakt
            if (nr == 0)
            {
                conn.Open();
                command = new SqlCommand("insert into bestelling (medewerker_id, tafel_nummer, status, datum_tijd, totaal_bedrag, opmerking, betaalwijze, fooi) values (@mId, @tflNr, @status, @nu, @bdrag, @opmerking, @betaalwijze, @fooi) ", conn);
                command.Parameters.Add("@mId", SqlDbType.Int).Value = medewerker_id;
                command.Parameters.Add("@tflNr", SqlDbType.Int).Value = tafelnummer;
                command.Parameters.Add("@status", SqlDbType.NVarChar).Value = "in progress";
                command.Parameters.Add("@nu", SqlDbType.DateTime).Value = DateTime.Now;
                command.Parameters.Add("@bdrag", SqlDbType.Decimal).Value = 0.00;
                command.Parameters.Add("@opmerking", SqlDbType.NVarChar).Value = "-";
                command.Parameters.Add("@betaalwijze", SqlDbType.NVarChar).Value = "nnb";
                command.Parameters.Add("@fooi", SqlDbType.Decimal).Value = 0.00;
                reader = command.ExecuteReader();
                conn.Close();

                // Tafel status op bezet zetten
                conn.Open();
                command = new SqlCommand("update tafel set status = @status where nummer = @tafel", conn);
                command.Parameters.Add("@tafel", SqlDbType.Int).Value = tafelnummer;
                command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Bezet";
                reader = command.ExecuteReader();
                conn.Close();
            }
        }

        // Bediening

        // Kaart

        // Alle gerechten uit de database halen
        public void LeesEten()
        {
            if (nu < tijd)
                // Alle lunch gerechten uit de database halen
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
            // Alle diner gerechten uit de database halen
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

        // Alle dranken uit de database halen
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

        // Alle gerechten tonen
        public void ToonEten(ListBox lijst)
        {
            foreach (Item product in eten)
            {
                lijst.Items.Add(product);
            }
            lijst.SelectedIndex = -1;
        }

        // Alle dranen tonen
        public void ToonDrinken(ListBox lijst)
        {
            foreach (Item product in drinken)
            {
                lijst.Items.Add(product);
            }
            lijst.SelectedIndex = -1;
        }

        // Bestelling

        //Bestelling opnemen
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
                    // diner gerechten
                    command = new SqlCommand("Select bestelling_id From bestelling where tafel_nummer = @tafel", conn);
                    command.Parameters.Add("@tafel", SqlDbType.Int).Value = tafelnr;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        bestellingId = (int)reader["bestelling_id"];
                    }
                    conn.Close();
                    conn.Open();
                    command = new SqlCommand("Select item_id, categorie_id, item_naam, item_prijs, item_btw, item_voorraad From items where item_id = @itemnr", conn);
                    command.Parameters.Add("@itemnr", SqlDbType.Int).Value = item + 10;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        item_id = (int)reader["item_id"];
                        string naam = (string)reader["item_naam"];
                        int categorie = (int)reader["categorie_id"];
                        voorraad = (int)reader["item_voorraad"];
                        decimal bedrag = (decimal)reader["item_prijs"];
                        decimal btw = (decimal)reader["item_btw"];
                        if (voorraad > 0)
                        {
                            BestellingItem bestelitem = new BestellingItem(bestellingId, categorie, item_id, naam, btw, bedrag);
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
                    // lunch gerechten
                    command = new SqlCommand("Select bestelling_id From bestelling where tafel_nummer = @tafel", conn);
                    command.Parameters.Add("@tafel", SqlDbType.Int).Value = tafelnr;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        bestellingId = (int)reader["bestelling_id"];
                    }
                    conn.Close();
                    conn.Open();
                    command = new SqlCommand("Select item_id, categorie_id, item_naam, item_prijs, item_btw, item_voorraad From items where item_id = @itemnr", conn);
                    command.Parameters.Add("@itemnr", SqlDbType.Int).Value = item + 1;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        item_id = (int)reader["item_id"];
                        string naam = (string)reader["item_naam"];
                        int categorie = (int)reader["categorie_id"];
                        voorraad = (int)reader["item_voorraad"];
                        decimal bedrag = (decimal)reader["item_prijs"];
                        decimal btw = (decimal)reader["item_btw"];
                        if (voorraad > 0)
                        {
                            BestellingItem bestelitem = new BestellingItem(bestellingId, categorie, item_id, naam, btw, bedrag);
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
            }
            else
            {
                // dranken
                command = new SqlCommand("Select bestelling_id From bestelling where tafel_nummer = @tafel", conn);
                command.Parameters.Add("@tafel", SqlDbType.Int).Value = tafelnr;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bestellingId = (int)reader["bestelling_id"];
                }
             
                command = new SqlCommand("Select item_id, categorie_id, item_naam, item_prijs, item_btw, item_voorraad From items where item_id = @itemnr", conn);
                command.Parameters.Add("@itemnr", SqlDbType.Int).Value = item + 21;
                conn.Close();
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    item_id = (int)reader["item_id"];
                    string naam = (string)reader["item_naam"];
                    int categorie = (int)reader["categorie_id"];
                    voorraad = (int)reader["item_voorraad"];
                    decimal bedrag = (decimal)reader["item_prijs"];
                    decimal btw = (decimal)reader["item_btw"];
                    if (voorraad > 0)
                    {
                        BestellingItem bestelitem = new BestellingItem(bestellingId, categorie, item_id, naam, btw, bedrag);
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
        }

        // Opname tonen
        public void ToonOpname(ListBox lijst)
        {
            lijst.Items.Clear();
            foreach (BestellingItem item in bestelling)
            {
                lijst.Items.Add(item.ToString());
            }
            lijst.SelectedIndex = -1;
        }

        // Geselecteerde opname verwijderen
        public void verwijderOpname(int nr)
        {
            int item_id = bestelling[nr].itemId, voorraad = 0;

            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select item_voorraad From items where item_id = @itemnr", conn);
            command.Parameters.Add("@itemnr", SqlDbType.Int).Value = item_id;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                voorraad = (int)reader["item_voorraad"];
            }
            conn.Close();

            conn.Open();
            command = new SqlCommand("update items set item_voorraad = @voorraad where item_id = @itemId", conn);
            command.Parameters.Add("@itemId", SqlDbType.Int).Value = item_id;
            command.Parameters.Add("@voorraad", SqlDbType.Int).Value = voorraad + 1;
            reader = command.ExecuteReader();
            conn.Close();

            bestelling.Remove(bestelling[nr]);
            
        }

        // De opgenomen items  plaatsen als bestelling
        public void PlaatsBestelling(ListBox lijst, int nummer)
        {
            int tId = nummer;
            foreach (BestellingItem item in bestelling)
            {
                int iId = item.itemId;
                int bId = item.bestellingId;
                int cId = item.categorie_id;
                decimal bedrag = 0, btw = item.BTW, prijs = item.prijs;
                string naam = item.item;

                string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);

                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO bestelling_items (bestelling_id, categorie_id, item_id, item_naam, status, btw_percentage, prijs) VALUES (@bId, @cId, @iId, @iNaam, @status, @btw, @prijs)", conn);
                command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = bId;
                command.Parameters.AddWithValue("@cId", SqlDbType.Int).Value = cId;
                command.Parameters.AddWithValue("@iId", SqlDbType.Int).Value = iId;
                command.Parameters.AddWithValue("@iNaam", SqlDbType.NVarChar).Value = naam;
                command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "in progress";
                command.Parameters.AddWithValue("@btw", SqlDbType.Decimal).Value = btw;
                command.Parameters.AddWithValue("@prijs", SqlDbType.Decimal).Value = prijs;

                SqlDataReader reader = command.ExecuteReader();
                conn.Close();

                foreach (BestellingItem euro in bestelling)
                {
                    bedrag = bedrag + euro.prijs;
                }

                conn.Open();
                command = new SqlCommand("update bestelling set datum_tijd = @tijd, totaal_bedrag = @bedrag where bestelling_id = @bId", conn);
                command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = bId;
                command.Parameters.AddWithValue("@tijd", SqlDbType.DateTime).Value = datum;
                command.Parameters.AddWithValue("@bedrag", SqlDbType.Decimal).Value = bedrag;
                reader = command.ExecuteReader();
                conn.Close();

                conn.Open();
                command = new SqlCommand("update tafel set status= @status where nummer = @tNr; update bestelling set status= @status where tafel_nummer = @tNr", conn);
                command.Parameters.AddWithValue("@tNr", SqlDbType.Int).Value = tId;
                command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Wachtend";
                reader = command.ExecuteReader();
                conn.Close();
            }
            lijst.Items.Clear();
        }

        //Alle openstaande bestellingen tonen
        public void ToonBestelling(ListBox lijst)
        {
            lijst.Items.Clear();
            bestel.Clear();

            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand command;
            SqlDataReader reader;

            conn.Open();
            command = new SqlCommand("select distinct * from bestelling where status = @status", conn);
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Wachtend";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                DateTime nu = (DateTime)reader["datum_tijd"];
                int bestellingId = (int)reader["bestelling_id"];
                int medewerkerId = (int)reader["medewerker_id"];
                int tafelNummer = (int)reader["tafel_nummer"];
                decimal totaalBedrag = (decimal)reader["totaal_bedrag"];
                string status = (string)reader["status"];

                Bestelling bestelling = new Bestelling(nu, bestellingId, medewerkerId, tafelNummer, totaalBedrag, status);
                bestel.Add(bestelling);

                
            }
            foreach (Bestelling best in bestel)
            {
                lijst.Items.Add(best.ToString());
            }
            lijst.SelectedIndex = -1;
            conn.Close();
           
        }

        // De status van een bestelling waarvan het eten en drinken gereed is aanpassen naar gereed
        public void ZetGereed()
        {
            bool gereed = true;
            string status = "";
            int tId = 0;
  
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand command = new SqlCommand("select bestelling_id, tafel_nummer from bestelling where status = @status", conn);
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Wachtend";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int bId = (int)reader["bestelling_id"];
                tId = (int)reader["tafel_nummer"];

                Bestelling een = new Bestelling(bId, tId);
                bestellingen.Add(een);
            }
            conn.Close();

            foreach (Bestelling best in bestellingen)
            {
                conn.Open();
                int bId = best.bestellingId;
                command = new SqlCommand("select status from bestelling_items where bestelling_id = @bId", conn);
                command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = bId;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    status = (string)reader["status"];

                    if (status == "in progress")
                    {
                        gereed = false;
                    }
                }
                conn.Close();

                if (gereed)
                {
                    conn.Open();
                    command = new SqlCommand("update bestelling set status = @status where bestelling_id = @bId", conn);
                    command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Gereed";
                    command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = bId;
                    reader = command.ExecuteReader();
                    conn.Close();

                    conn.Open();
                    command = new SqlCommand("update tafel set status = @status where nummer = @tafel", conn);
                    command.Parameters.Add("@tafel", SqlDbType.Int).Value = tId;
                    command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Gereed";
                    reader = command.ExecuteReader();
                    conn.Close();
                
            }
            }
            bestellingen.Clear();
        }

        // De status van een eet items die geserveerd zijn aanpassen naar geserveerd
        public void EtenGeserveerd(int index)
        {
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();
            SqlCommand command = new SqlCommand("select bestelling_id, tafel_nummer from bestelling where status = @status or status = @status2", conn);
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Wachtend";
            command.Parameters.AddWithValue("@status2", SqlDbType.NVarChar).Value = "Gereed";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int bId = (int)reader["bestelling_id"];
                int tId = (int)reader["tafel_nummer"];

                Bestelling een = new Bestelling(bId, tId);
                bestellingen.Add(een);
            }
            conn.Close();

            int nummer = bestellingen[index].bestellingId;
            conn.Open();
            command = new SqlCommand("update bestelling_items set status = @status where bestelling_id = @bId and categorie_id < 8", conn);
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Geserveerd";
            command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = nummer;
            reader = command.ExecuteReader();
            conn.Close();
            bestellingen.Clear();
        }

        // De status van een drank items die geserveerd zijn aanpassen naar geserveerd
        public void DrinkenGeserveerd(int index)
        {
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();
            SqlCommand command = new SqlCommand("select bestelling_id, tafel_nummer from bestelling where status = @status or status = @status2", conn);
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Wachtend";
            command.Parameters.AddWithValue("@status2", SqlDbType.NVarChar).Value = "Gereed";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int bId = (int)reader["bestelling_id"];
                int tId = (int)reader["tafel_nummer"];

                Bestelling een = new Bestelling(bId, tId);
                bestellingen.Add(een);
            }
            conn.Close();

            int nummer = bestellingen[index].bestellingId;
            conn.Open();
            command = new SqlCommand("update bestelling_items set status = @status where bestelling_id = @bId and categorie_id > 7", conn);
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Geserveerd";
            command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = nummer;
            reader = command.ExecuteReader();
            conn.Close();
            bestellingen.Clear();
        }

        // De status van een bestelling waarvan het eten en drinken geserveerd is aanpassen naar geserveerd 
        public void ZetGeserveerd()
        {
            bool geserveerd = true;
            string status = "";

            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand command = new SqlCommand("select bestelling_id, tafel_nummer from bestelling where status = @status", conn);
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Gereed";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int bId = (int)reader["bestelling_id"];
                int tId = (int)reader["tafel_nummer"];

                Bestelling een = new Bestelling(bId, tId);
                bestellingen.Add(een);
            }
            conn.Close();

            conn.Open();

            foreach (Bestelling best in bestellingen)
            {
                int bId = best.bestellingId;
                command = new SqlCommand("select status from bestelling_items where bestelling_id = @bId", conn);
                command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = bId;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    status = (string)reader["status"];

                    if (status == "Gereed")
                    {
                        geserveerd = false;
                    }
                }
                conn.Close();

                if (geserveerd)
                {
                    conn.Open();
                    command = new SqlCommand("update bestelling set status = @status where bestelling_id = @bId", conn);
                    command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Bezet";
                    command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = bId;
                    reader = command.ExecuteReader();
                }
            }
            bestellingen.Clear();
        }

        // Geselecteerde bestelling verwijderen
        public void VerwijderBestelling(int index, ListBox lijst)
        {
            int tafelnummer = 0, nr = bestel[index].bestellingId;
            
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand command = new SqlCommand("select tafel_nummer from bestelling where bestelling_id  = @bId", conn);
            command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = nr;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tafelnummer = (int)reader["tafel_nummer"];
            }
            conn.Close();
            conn.Open();
            command = new SqlCommand("Delete from bestelling_items where bestelling_id = @bId; update tafel set status = @status where nummer = @tafel ; update bestelling set status = @bstatus, totaal_bedrag = 0 where tafel_nummer = @tafel", conn);
            command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = nr;
            command.Parameters.AddWithValue("@tafel", SqlDbType.Int).Value = tafelnummer;
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Bezet";
            command.Parameters.AddWithValue("@bstatus", SqlDbType.NVarChar).Value = "In Progress";
            reader = command.ExecuteReader();
            conn.Close();
        }

        // Afrekenen

        // De rekening van de bestelling laden en tonen
        public void LaadRekening(int tafelId, ListBox Lijst)
        {
            int bId = 0;
            decimal btwItem = 0, btwBedrag = 0, totaalBedrag = 0, fooi = 0;
            string opmerking = " ", betaalwijze = " ";
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            
            // Ophalen
            conn.Open();
            SqlCommand command = new SqlCommand("select bestelling_id, opmerking, betaalwijze, fooi from bestelling where tafel_nummer = @tafelnr", conn);
            command.Parameters.AddWithValue("@tafelnr", SqlDbType.Int).Value = tafelId;
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "in progress" /*Afgehandeld*/;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                bId = (int)reader["bestelling_id"];
                opmerking = (string)reader["opmerking"];
                betaalwijze = (string)reader["betaalwijze"];
                fooi = (decimal)reader["fooi"];   
            }
            conn.Close();

            conn.Open();
            command = new SqlCommand("select item_naam, btw_percentage, prijs from bestelling_items where bestelling_id = @bId ", conn);
            command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value =bId;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string naam = (string)reader["item_naam"];
                decimal btw = (decimal)reader["btw_percentage"];
                decimal prijs = (decimal)reader["prijs"];

                Lijst.Items.Add(naam + "   btw %: " + (btw * 100).ToString(" #0") + "%   €" + prijs);
                btwItem = btw * prijs;
                btwBedrag = btwBedrag + btwItem;
                totaalBedrag = totaalBedrag + prijs;
            }
            // Tonen
            Lijst.Items.Add("");
            Lijst.Items.Add("Opmerking: " + opmerking);
            Lijst.Items.Add("");
            Lijst.Items.Add("Betaalwijze: " + betaalwijze);
            Lijst.Items.Add("Bedrag: €" + totaalBedrag);
            Lijst.Items.Add("BTW bedrag: €" + btwBedrag.ToString(" #0.00"));
            Lijst.Items.Add("Fooi: €" + fooi.ToString(" #0.00"));
            Lijst.Items.Add("Totaal bedrag: €" + (totaalBedrag + fooi));
            conn.Close();
        }

        // Betaalwijze, Opmerking en fooi toevoegen aan rekening
        public void VoegToe(int tafelId, string Opmerking, string betaalwijze, decimal fooi)
        {
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();
            SqlCommand command = new SqlCommand("update bestelling set opmerking = @opmerking, fooi = @fooi, betaalwijze = @betaalwijze where tafel_nummer = @tafelnr", conn);
            command.Parameters.AddWithValue("@tafelnr", SqlDbType.Int).Value = tafelId;
            command.Parameters.AddWithValue("@opmerking", SqlDbType.NVarChar).Value = Opmerking;
            command.Parameters.AddWithValue("@betaalwijze", SqlDbType.NVarChar).Value = betaalwijze;
            command.Parameters.AddWithValue("@fooi", SqlDbType.Decimal).Value = fooi;
            SqlDataReader reader = command.ExecuteReader();
            conn.Close();
        }

        // De status van een bestelling aanpassen naar afgehandelt
        public void Afrekenen(int tafelId)
        {
            int bId = 0;
            decimal bedrag = 0, totaalbedrag = 0, fooi = 0;
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();
            SqlCommand command = new SqlCommand("select bestelling_id, totaal_bedrag, fooi from bestelling where tafel_nummer = @tafelnr", conn);
            command.Parameters.AddWithValue("@tafelnr", SqlDbType.Int).Value = tafelId;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                bId = (int)reader["bestelling_id"];
                bedrag = (decimal)reader["totaal_bedrag"];
                fooi = (decimal)reader["fooi"];
            }
            conn.Close();

            totaalbedrag = bedrag + fooi;

            conn.Open();
            command = new SqlCommand("update bestelling set betaald_bedrag = @totaal, status = @status where bestelling_id = @bId", conn);
            command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = bId;
            command.Parameters.AddWithValue("@totaal", SqlDbType.Decimal).Value = totaalbedrag;
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Afgerond";
            reader = command.ExecuteReader();
            conn.Close();

            conn.Open();
            command = new SqlCommand("Delete from bestelling_items where bestelling_id = @bId ", conn);
            command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = bId;
            reader = command.ExecuteReader();
            conn.Close();

            conn.Open();
            command = new SqlCommand("update tafel set status = @status where nummer = @tafelnr", conn);
            command.Parameters.AddWithValue("@tafelnr", SqlDbType.Int).Value = tafelId;
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Vrij";
            reader = command.ExecuteReader();
            conn.Close();

        }
        
        // Keuken

        public void ToonEetBestelling(ListBox lijst)
        {
            lijst.Items.Clear();
            bestelEten.Clear();

            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand command;
            SqlDataReader reader;

            conn.Open();
            command = new SqlCommand("select distinct * from bestelling where status = @status", conn);
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Wachtend";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                DateTime nu = (DateTime)reader["datum_tijd"];
                int bestellingId = (int)reader["bestelling_id"];
                int medewerkerId = (int)reader["medewerker_id"];
                int tafelNummer = (int)reader["tafel_nummer"];
                decimal totaalBedrag = (decimal)reader["totaal_bedrag"];
                string status = (string)reader["status"];

                Bestelling bestelling = new Bestelling(nu, bestellingId, medewerkerId, tafelNummer, totaalBedrag, status);
                bestelEten.Add(bestelling);


            }
            foreach (Bestelling best in bestelEten)
            {
                lijst.Items.Add(best.ToString());
            }
            lijst.SelectedIndex = -1;
            conn.Close();
        }

        public void ToonVoedsel(ListBox lijst, int index)
        {
            eten.Clear();
            int nummer = bestelEten[index].bestellingId;
            string naam = " ";
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();
            SqlCommand command = new SqlCommand("select * from bestelling_items where bestelling_id = @bId and categorie_id < 8", conn);
            command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = nummer;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                naam = (string)reader["item_naam"];
                Item eet = new Item(naam);
                eten.Add(eet);
            }
            conn.Close();

            foreach (Item eetje in eten)
            {
                lijst.Items.Add(eetje.ToString());
            }
            lijst.SelectedIndex = -1;
        }

        public void VoedselGereed(int index)
        {
            int nummer = bestelEten[index].bestellingId;
            bestelEten.Remove(bestelEten[index]);
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();
            SqlCommand command = new SqlCommand("update bestelling_items set status = @status where bestelling_id = @bId and categorie_id < 8", conn);
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Gereed";
            command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = nummer;
            SqlDataReader reader = command.ExecuteReader();
            conn.Close();
        }

        public void GereedVoedsel(ListBox lijst)
        {
            int bId = 0, tId = 0;
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();
            SqlCommand command = new SqlCommand("select bestelling_id from bestelling_items where status = @status and categorie_id < 8", conn);
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Gereed";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                bId = (int)reader["bestelling_id"];
            }
            conn.Close();
            conn.Open();
            command = new SqlCommand("select tafel_nummer from bestelling where bestelling_id = @bId", conn);
            command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = bId;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                tId = (int)reader["tafel_nummer"];
                Bestelling gereed = new Bestelling(bId, tId);
                bestel.Add(gereed);
            }
            conn.Close();
            foreach(Bestelling gerecht in bestelEten)
            {
                lijst.Items.Add("Tafel " + gerecht.tafelNummer + "\t bestelling " + gerecht.bestellingId);
            }
          
        }

        public void VoedselVoorraad(ListBox lijst)
        {
            string item = "";
            int aantal = 0;
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand command;
            SqlDataReader reader;

            conn.Open();
            command = new SqlCommand("select item_naam, item_voorraad from items where categorie_id < 8", conn);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                item = (string)reader["item_naam"];
                aantal = (int)reader["item_voorraad"];
                Voorraad Voedsel = new Voorraad(item, aantal);
                voorraad.Add(Voedsel);

            }
            foreach (Voorraad drankje in voorraad)
            {
                lijst.Items.Add(drankje);
            }
            conn.Close();
            voorraad.Clear();
        }
    
        // Bar

        public void ToonDrinkBestelling(ListBox lijst)
        {
            lijst.Items.Clear();
            bestelDrinken.Clear();

            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand command;
            SqlDataReader reader;

            conn.Open();
            command = new SqlCommand("select distinct * from bestelling where status = @status", conn);
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Wachtend";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                DateTime nu = (DateTime)reader["datum_tijd"];
                int bestellingId = (int)reader["bestelling_id"];
                int medewerkerId = (int)reader["medewerker_id"];
                int tafelNummer = (int)reader["tafel_nummer"];
                decimal totaalBedrag = (decimal)reader["totaal_bedrag"];
                string status = (string)reader["status"];

                Bestelling bestelling = new Bestelling(nu, bestellingId, medewerkerId, tafelNummer, totaalBedrag, status);
                bestelDrinken.Add(bestelling);


            }
            foreach (Bestelling best in bestelDrinken)
            {
                lijst.Items.Add(best.ToString());
            }
            lijst.SelectedIndex = -1;
            conn.Close();
        }

        public void ToonDrinken(ListBox lijst, int index)
        {
            drinken.Clear();
            int nummer = bestelDrinken[index].bestellingId;
            string naam = " ";
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();
            SqlCommand command = new SqlCommand("select * from bestelling_items where bestelling_id = @bId and categorie_id > 7", conn);
            command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = nummer;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                naam = (string)reader["item_naam"];
                Item drank = new Item(naam);
                drinken.Add(drank);
            }
            conn.Close();

            foreach (Item drankje in drinken)
            {
                lijst.Items.Add(drankje.ToString());
            }
            lijst.SelectedIndex = -1;
        }

        public void DrinkenGereed(int index)
        {
            int nummer = bestelDrinken[index].bestellingId;
            bestelDrinken.Remove(bestelDrinken[index]);
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();
            SqlCommand command = new SqlCommand("update bestelling_items set status = @status where bestelling_id = @bId and categorie_id > 7", conn);
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Gereed";
            command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = nummer;
            SqlDataReader reader = command.ExecuteReader();
            conn.Close();
        }

        public void GereedDrinken(ListBox lijst)
        {
            int bId = 0, tId = 0;
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();
            SqlCommand command = new SqlCommand("select bestelling_id from bestelling_items where status = @status and categorie_id > 7", conn);
            command.Parameters.AddWithValue("@status", SqlDbType.NVarChar).Value = "Gereed";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                bId = (int)reader["bestelling_id"];
            }
            conn.Close();
            conn.Open();
            command = new SqlCommand("select tafel_nummer from bestelling where bestelling_id = @bId", conn);
            command.Parameters.AddWithValue("@bId", SqlDbType.Int).Value = bId;
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                tId = (int)reader["tafel_nummer"];
                Bestelling gereed = new Bestelling(bId, tId);
                bestel.Add(gereed);
            }
            conn.Close();
            foreach (Bestelling gerecht in bestelDrinken)
            {
                lijst.Items.Add("Tafel " + gerecht.tafelNummer + "\t bestelling " + gerecht.bestellingId);
            }
            
        }

        public void DrankVoorraad(ListBox lijst)
        {
            string item = "";
            int aantal = 0;
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand command;
            SqlDataReader reader;

            conn.Open();
            command = new SqlCommand("select item_naam, item_voorraad from items where categorie_id > 7", conn);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                item = (string)reader["item_naam"];
                aantal = (int)reader["item_voorraad"];
                Voorraad Drank = new Voorraad(item, aantal);
                voorraad.Add(Drank);
                
            }
            foreach(Voorraad drankje in voorraad)
            {
                lijst.Items.Add(drankje);
            }
            conn.Close();
            voorraad.Clear();
        }

        // Admin

        // Alle medewerkers ophalen uit de database
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

        // Alle medewekers tonen
        public void ToonMedewerker(ListBox lijst)
        {
            foreach (Medewerker medewerker in medewerkers)
            {
                lijst.Items.Add(medewerker);
            }
            lijst.SelectedIndex = -1;
        }

        // De geselecteerde medewerker tonen in de tekstbalken
        public void ToonWerker(int index, out string naam, out int wachtwoord, out string functie)
        {
            int nummer = medewerkers[4].id;
            naam = " ";
            functie = " ";
            wachtwoord = 0;

            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand command = new SqlCommand("Select * From medewerker where medewerker_id = @Id", conn);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = nummer;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())

            {
                naam = (string)reader["medewerker_naam"];
                functie = (string)reader["medewerker_functie"];
                wachtwoord = (int)reader["medewerker_wachtwoord"];
            }
            conn.Close();
        }

        // Medewerker toevoegen aan de database na invullen tekstvakken
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

        // Medewerker wijzigen nadat deze geselecteerd is en de tekstvakken zijn aangepast
        public void WijzigMedewerker(int index, TextBox naam, TextBox wachtwoord, string functie)
        {
            int nummer = medewerkers[index].id;
            int ww = int.Parse(wachtwoord.Text);
            string connString = ConfigurationManager.ConnectionStrings["Databasje"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("Update medewerker Set medewerker_naam = @medewerker_naam, medewerker_functie = @medewerker_functie, medewerker_wachtwoord = @medewerker_wachtwoord where medewerker_id = @nummer" , conn);
            cmd.Parameters.AddWithValue("@nummer", SqlDbType.Int).Value = nummer;
            cmd.Parameters.AddWithValue("@medewerker_naam", SqlDbType.NVarChar).Value = naam.Text;
            cmd.Parameters.AddWithValue("@medewerker_functie", SqlDbType.NVarChar).Value = functie;
            cmd.Parameters.AddWithValue("@medewerker_Wachtwoord", SqlDbType.Int).Value = ww;
            SqlDataReader reader = cmd.ExecuteReader();
            conn.Close();

            medewerkers.Clear();
        }
        
        // Geselecteerde medewerker verwijderen
        public void VerwijderMedewerker(int index)
        {
            int nummer = medewerkers[index].id;
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
