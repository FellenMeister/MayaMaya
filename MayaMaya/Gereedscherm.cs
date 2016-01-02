﻿using System;
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
    public partial class Gereedscherm : Form
    {
        public Gereedscherm()
        {
            InitializeComponent();
        }

        private void Btn_Bestelling_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bestellingscherm scherm = new Bestellingscherm();
            scherm.Show();
        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inlogscherm scherm = new Inlogscherm();
            scherm.Show();
        }
    }
}