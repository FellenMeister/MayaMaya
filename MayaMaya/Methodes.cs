﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
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