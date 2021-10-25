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
    public partial class FormTambahPegawai : Form
    {
        public FormTambahPegawai()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text != textBoxUlangPass.Text)
            {
                MessageBox.Show("Password tidak sesuai!");
            }
            else
            {
                try
                {
                    Pegawai newKategori = new Pegawai(textBoxId.TextLength, textBoxNamaPegawai.Text, textBoxEmail.Text, textBoxPassword.Text, textBoxTelepon.Text);
                    Pegawai.AddData(newKategori);

                    MessageBox.Show("Tambah data berhasil!", "Info");

                    FormPengaturanPegawai parent = (FormPengaturanPegawai)this.Owner;
                    parent.FormPengaturanPegawai_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tambah data gagal..." + ex.Message, "Info");
                }
            }
        }

        private void buttonKosongi_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            textBoxEmail.Text = "";
            textBoxNamaPegawai.Text = "";
            textBoxPassword.Text = "";
            textBoxTelepon.Text = "";
            textBoxUlangPass.Text = "";
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
