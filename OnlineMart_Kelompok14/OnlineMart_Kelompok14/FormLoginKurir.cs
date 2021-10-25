using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineMart_Kelompok14
{
    public partial class FormLoginKurir : Form
    {
        public FormLoginKurir()
        {
            InitializeComponent();
        }

        private void labelDaftar_Click(object sender, EventArgs e)
        {
            FormRegisterKurir form = new FormRegisterKurir();
            form.Owner = this;
            form.ShowDialog();
        }
    }
}
