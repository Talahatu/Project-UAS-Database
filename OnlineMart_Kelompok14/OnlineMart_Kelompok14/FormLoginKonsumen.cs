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
    public partial class FormLoginKonsumen : Form
    {
        public FormLoginKonsumen()
        {
            InitializeComponent();
        }

        private void labelDaftar_Click(object sender, EventArgs e)
        {
            FormRegisterKonsumen form = new FormRegisterKonsumen();
            form.Owner = this;
            form.ShowDialog();
        }
    }
}
