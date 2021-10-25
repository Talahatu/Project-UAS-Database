using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace OnlineMart_LIB
{
    public class Koneksi
    {
        private MySqlConnection konDB;
        #region properties
        public MySqlConnection KonDB { get => konDB; private set => konDB = value; }
        #endregion

        #region methods
        public void Connect()
        {
            if (KonDB.State == System.Data.ConnectionState.Open)
            {
                KonDB.Close();
            }
            KonDB.Open();
        }

        public static MySqlDataReader RunQuery(string query)
        {
            Koneksi connection = new Koneksi();

            MySqlCommand command = new MySqlCommand(query, connection.KonDB);

            MySqlDataReader result = command.ExecuteReader();

            return result;
        }

        public static int RunDMLCommand(string query)
        {
            Koneksi connection = new Koneksi();

            MySqlCommand command = new MySqlCommand(query, connection.KonDB);

            return command.ExecuteNonQuery();
        }
        #endregion

        #region Constructor
        public Koneksi(string _server, string _database, string _username, string _password)
        {
            string strCon = "server=" + _server + ";database=" + _database + ";uid=" + _username + ";password=" + _password + ";SSL Mode=None"; //buat connectionstring
            KonDB = new MySqlConnection(); //inisialisasi koneksi
            KonDB.ConnectionString = strCon; //set connection string dgn strCon
            Connect(); //panggil method connect
        }

        public Koneksi()
        {
            Configuration myConf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSectionGroup userSettings = myConf.SectionGroups["userSettings"];
            var settingSection = userSettings.Sections["OnlineMart_Kelompok14.db"] as ClientSettingsSection;

            string DbServer = settingSection.Settings.Get("DbServer").Value.ValueXml.InnerText;
            string DbName = settingSection.Settings.Get("DbName").Value.ValueXml.InnerText;
            string DbUsername = settingSection.Settings.Get("DbUsername").Value.ValueXml.InnerText;
            string DbPassword = settingSection.Settings.Get("DbPassword").Value.ValueXml.InnerText;

            string connectString = "server=" + DbServer + ";database=" + DbName + ";uid=" + DbUsername + ";password=" + DbPassword + ";ssl mode=none";

            KonDB = new MySqlConnection();
            KonDB.ConnectionString = connectString;
            Connect();
        }
        #endregion
    }
}
