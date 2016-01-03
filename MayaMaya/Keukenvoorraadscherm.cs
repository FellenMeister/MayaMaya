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
    public partial class List_Keukenvoorraadscherm : Form
    {
        Methodes MayaMaya;
        public List_Keukenvoorraadscherm()
        {
            InitializeComponent();
            MayaMaya = new Methodes("MayaMaya");
        }

        private void Btn_LogOut_Click(object sender, EventArgs e)
        {
            MayaMaya.LogUit();
            this.Hide();
        }
    }
}
