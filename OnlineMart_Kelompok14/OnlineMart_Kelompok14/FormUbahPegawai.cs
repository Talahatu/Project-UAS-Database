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
    public partial class FormUbahPegawai : Form
    {
        public FormUbahPegawai()
        {
            InitializeComponent();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                Pegawai kategori = new Pegawai(int.Parse(textBoxId.Text),textBoxNamaPegawai.Text,textBoxEmail.Text,textBoxPassword.Text,textBoxTelepon.Text);
                Pegawai.UpdateData(kategori);
                MessageBox.Show("Ubah data berhasil!", "Info");

                FormPengaturanPegawai parent = (FormPengaturanPegawai)this.Owner;
                parent.FormPengaturanPegawai_Load(buttonKeluar, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ubah data gagal..." + ex.Message, "Info");
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxEmail.Text = "";
            textBoxId.Text = "";
            textBoxNamaPegawai.Text = "";
            textBoxPassword.Text = "";
            textBoxTelepon.Text = "";
        }
    }
}
