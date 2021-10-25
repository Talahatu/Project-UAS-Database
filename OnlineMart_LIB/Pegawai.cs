using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace OnlineMart_LIB
{

    public class Pegawai
    {
        #region Field
        private int id;
        private string nama;
        private string email;
        private string password;
        private string telp;
        #endregion
        #region Constructor
        public Pegawai(int id, string nama, string email, string password, string telp)
        {
            this.Id = id;
            this.Nama = nama;
            this.Email = email;
            this.Password = password;
            this.Telp = telp;
        }
        #endregion
        #region Properties
        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Telp
        {
            get => telp;
            set
            {
                if (value.Count() == 12)
                {
                    telp = value;
                }
                else
                {
                    throw (new ArgumentException("No telp salah1"));
                }
            }
        }
        #endregion
        #region Method

        public static List<Pegawai> ReadData(string kriteria, string nilaiKriteria)
        {
            string query = "";
            if (kriteria == "")
            {
                query = "SELECT * FROM pegawais";
            }
            else
            {
                query = "SELECT * FROM pegawais WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader result = Koneksi.RunQuery(query);

            List<Pegawai> listPegawai = new List<Pegawai>();

            while (result.Read())
            {
                Pegawai newPegawai = new Pegawai(
                    Convert.ToInt32(result.GetValue(0)),
                    result.GetValue(1).ToString(),
                    result.GetValue(2).ToString(),
                    result.GetValue(3).ToString(),
                    result.GetValue(4).ToString());
                listPegawai.Add(newPegawai);
            }
            return listPegawai;
        }
        public static void AddData(Pegawai pegawai)
        {
            string query = "INSERT INTO pegawais (nama, email, password, telepon) " +
                "VALUES ('" +
                pegawai.Nama.Replace("'", "\\'") + "','" +
                pegawai.Email + "','" +
                pegawai.Password.Replace("'", "\\'") + "','" +
                pegawai.Telp +
                        "')";
            Koneksi.RunDMLCommand(query);
        }
        public static void UpdateData(Pegawai pegawai)
        {
            string query = "UPDATE pegawais SET nama='" +
                pegawai.Nama.Replace("'", "\\'") + "', email='" +
                pegawai.Email + "', password=SHA2('" +
                pegawai.Password.Replace("'", "\\'") + "',512), telepon='" +
                pegawai.Telp +
                        "' WHERE id='" + pegawai.Id + "'";
            Koneksi.RunDMLCommand(query);
        }

        public static Boolean DeleteData(int id)
        {
            string query = "DELETE FROM pegawais WHERE id='" + id + "'";
            int jumlahDataBerubah = Koneksi.RunDMLCommand(query);
            if (jumlahDataBerubah == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public static Pegawai CekLogin(string email, string password)
        {
            string query = "SELECT *" +
                "           FROM pegawais "+
                "           WHERE email='" + email + "' AND password=SHA2('" + password + "',512)";
            MySqlDataReader result = Koneksi.RunQuery(query);

            while (result.Read())
            {
                Pegawai confirmedPegawai = new Pegawai(
                    Convert.ToInt32(result.GetValue(0)),
                    result.GetValue(1).ToString(),
                    result.GetValue(2).ToString(),
                    result.GetValue(3).ToString(),
                    result.GetValue(4).ToString()
                    );
                return confirmedPegawai;
            }
            return null;
        }
        #endregion
    }
}
