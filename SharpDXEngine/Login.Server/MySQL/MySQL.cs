using MySql.Data.MySqlClient;
using System;

namespace Login.Server
{
    static class MySQL
    {
        private static string connectionString = "server=localhost; user=ringex; password=ringex; database=pokemon";
        public static MySqlConnection connection;
        public static int id;

        public static void Start()
        {
            connection = new MySqlConnection(connectionString);

            try {
                connection.Open();
            } catch {
                Program.frmServer.addLog("Falha ao conectar no banco de dados!");
            }
        }

        public static void Close()
        {
            connection.Close();
        }

        public static MySqlDataReader Find(string query)
        {
            MySQL.Start();

            MySqlCommand command = new MySqlCommand(
                query,
                MySQL.connection
            );

            MySqlDataReader result = command.ExecuteReader();

            //MySQL.Close();

            return result;
        }

        public static bool Save(MySqlCommand query)
        {
            MySQL.Start();
            query.Connection = MySQL.connection;
            query.ExecuteNonQuery();
            MySQL.id = (int) query.LastInsertedId;
            MySQL.Close();

            return true;
        }

    }
}
