using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace COMPANY_A2.persistence
{
    internal class DBBroker
    {
        private static string? connectionString;
        private static MySqlConnection? connection;
        private static DBBroker? instance;

        private DBBroker()
        {
            DBBroker.connectionString = Environment.GetEnvironmentVariable("COMPANY_DB_CONNECTION")
                ?? "server=localhost;database=Company;uid=root;pwd=;CharSet=utf8;";
            DBBroker.connection = new MySqlConnection(DBBroker.connectionString);
        }
        public static DBBroker GetInstance()
        {
            if (instance == null)
            {
                instance = new DBBroker();
            }
            return instance;
        }
        public List<string[]> Read(string sql)
        {
            List<string[]> result = new List<string[]>();
            MySqlCommand command = new MySqlCommand(sql, connection);

            connect();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string[] row = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[i] = reader[i].ToString();
                }
                result.Add(row);
            }
            reader.Close();
            disconnect();
            return result;
        }
        public int Change(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, connection);
            int result;
            connect();
            result = command.ExecuteNonQuery();
            disconnect();
            return result;
        }
        public void connect()
        {
            if (DBBroker.connection != null)
            {
                if (DBBroker.connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
        }
        public void disconnect()
        {
            if (DBBroker.connection != null)
            {
                if (DBBroker.connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
