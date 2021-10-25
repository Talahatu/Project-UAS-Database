using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineMart_LIB;

namespace OnlineMart_Kelompok14
{
    public partial class FormLoginPegawai : Form
    {
        public FormLoginPegawai()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormPengaturanPegawai"];

            if (form == null)
            {
                FormPengaturanPegawai form1 = new FormPengaturanPegawai();
                form1.Owner = this.MdiParent;
                form1.Show();
                Close();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }
    }
}
