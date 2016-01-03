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
    public partial class List_Barscherm : Form
    {
        Methodes MayaMaya;
        public List_Barscherm()
        {
            InitializeComponent();
            MayaMaya = new Methodes("MayaMaya");
        }

        private void List_Barscherm_Load(object sender, EventArgs e)
        {

        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            MayaMaya.LogUit();
            this.Hide();
        }
    }
}
