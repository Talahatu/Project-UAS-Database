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
    public partial class mdiOnlineMart : Form
    {
        public mdiOnlineMart()
        {
            InitializeComponent();
        }
        public Pegawai loggedPegawai;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void mdiOnlineMart_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            try
            {
                Koneksi koneksi = new Koneksi(db.Default.DbServer, db.Default.DbName, db.Default.DbUsername, db.Default.DbPassword);


                MessageBox.Show("Koneksi berhasil", "Informasi");
            }
            catch (Exception x)
            {
                MessageBox.Show("Koneksi Gagal. Pesan kesalahan : " + x.Message);
            }

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormLoginKonsumen"];
            if (form == null)
            {
                FormLoginKonsumen formL = new FormLoginKonsumen();
                formL.MdiParent = this;
                formL.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormLoginPegawai"];
            if (form == null)
            {
                FormLoginPegawai formL = new FormLoginPegawai();
                formL.MdiParent = this;
                formL.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormLoginKurir"];
            if (form == null)
            {
                FormLoginKurir formL = new FormLoginKurir();
                formL.MdiParent = this;
                formL.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
