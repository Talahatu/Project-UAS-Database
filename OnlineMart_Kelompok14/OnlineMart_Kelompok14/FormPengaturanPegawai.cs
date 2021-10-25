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
    public partial class FormPengaturanPegawai : Form
    {
        public FormPengaturanPegawai()
        {
            InitializeComponent();
        }
        List<Pegawai> listPegawai;

        public void FormPengaturanPegawai_Load(object sender, EventArgs e)
        {

            listPegawai = Pegawai.ReadData("", "");
            if (listPegawai.Count > 0)
            {
                dataGridViewPegawai.DataSource = listPegawai;
                //dataGridViewPegawai.Columns[3].Visible = false;

                if (!dataGridViewPegawai.Columns.Contains("btnUbahGrid"))
                {
                    DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
                    btnCol.HeaderText = "Aksi";
                    btnCol.Text = "Ubah";
                    btnCol.Name = "btnUbahGrid";
                    btnCol.UseColumnTextForButtonValue = true;
                    dataGridViewPegawai.Columns.Add(btnCol);

                    DataGridViewButtonColumn btnCol2 = new DataGridViewButtonColumn();
                    btnCol2.HeaderText = "Aksi2";
                    btnCol2.Text = "Hapus";
                    btnCol2.Name = "btnHapusGrid";
                    btnCol2.UseColumnTextForButtonValue = true;
                    dataGridViewPegawai.Columns.Add(btnCol2);

                }
            }
            else
            {
                dataGridViewPegawai.DataSource = null;
            }
        }

        private void textBoxPegawai_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPegawai.Text == "Id")
                {
                    listPegawai = Pegawai.ReadData("id", textBoxPegawai.Text);
                }
                else if (comboBoxPegawai.Text == "Nama")
                {
                    listPegawai = Pegawai.ReadData("nama", textBoxPegawai.Text);
                }
                else if (comboBoxPegawai.Text == "Email")
                {
                    listPegawai = Pegawai.ReadData("email", textBoxPegawai.Text);
                }
                else if (comboBoxPegawai.Text == "Telepon")
                {
                    listPegawai = Pegawai.ReadData("telepon", textBoxPegawai.Text);
                }

                if (listPegawai.Count > 0)
                {
                    dataGridViewPegawai.DataSource = listPegawai;
                }
                else
                {
                    dataGridViewPegawai.DataSource = null;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridViewPegawai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridViewPegawai.CurrentRow.Cells["id"].Value.ToString();
            string nama = dataGridViewPegawai.CurrentRow.Cells["nama"].Value.ToString();
            string email = dataGridViewPegawai.CurrentRow.Cells["email"].Value.ToString();
            string password = dataGridViewPegawai.CurrentRow.Cells["password"].Value.ToString();
            string telepon = dataGridViewPegawai.CurrentRow.Cells["telp"].Value.ToString();

            if (e.ColumnIndex == dataGridViewPegawai.Columns["btnHapusGrid"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show(this, "Anda Yakin Ingin Menghapus " +
                    id + " - " + nama + "?", "HAPUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Boolean hapus = Pegawai.DeleteData(int.Parse(id));

                    if (hapus)
                    {
                        MessageBox.Show("Data Berhasil Dihapus!");
                        FormPengaturanPegawai_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Data Gagal Dihapus!");
                    }
                }
            }
            else
            {
                FormUbahPegawai ubah = new FormUbahPegawai();
                ubah.Owner = this;
                ubah.textBoxId.Text = id;
                ubah.textBoxNamaPegawai.Text = nama;
                ubah.textBoxEmail.Text = email;
                ubah.textBoxPassword.Text = password;
                ubah.textBoxTelepon.Text = telepon;
                ubah.Show();
            }
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPegawai form1 = new FormTambahPegawai();
            form1.Owner = this;
            form1.Show();
        }
    }
}
