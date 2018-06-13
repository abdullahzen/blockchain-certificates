using MySql.Data;
using MySql.Data.MySqlClient;

namespace BlockchainCertificates.Helpers
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        public MySqlConnection Connection { get; private set; }

        private static DBConnection _instance;
        public static DBConnection Instance()
        {
            return _instance ?? (_instance = new DBConnection());
        }

        public bool IsConnect()
        {
            if (Connection != null) return true;
            Connection = new MySqlConnection("Server=localhost; database=blockchain_certificates; UID=root; password=admin;");
            Connection.Open();
            return true;
        }

        public void Close()
        {
            Connection.Close();
        }
    }
}
