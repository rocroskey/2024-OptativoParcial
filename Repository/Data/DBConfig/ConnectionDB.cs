using Npgsql;
using System;

namespace Repository.Data.DBConfig
{
    public class ConnectionDB
    {
        private static readonly string defaultConnectionString = "Host=localhost;Username=postgres;Password=rc12345;Database=optativo";
        public string connectionString;

        public ConnectionDB(string _connectionString = null)
        {
            connectionString = _connectionString ?? defaultConnectionString;
        }

        public NpgsqlConnection OpenConnection()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
                throw;
            }
            return connection;
        }

        public void CloseConnection(NpgsqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
                throw;
            }
        }

        public static ConnectionDB CreateDefaultInstance()
        {
            return new ConnectionDB();
        }
    }
}