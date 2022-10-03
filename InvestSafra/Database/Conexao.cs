using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace InvestSafra.Database
{
    internal class Conexao
    {
        private static string host = "localhost";

        private static string port = "3306";

        private static string user = "root";

        private static string password = "Lohainy//2004";

        private static string dbname = "bd_safra";

        private static MySqlConnection connection;

        private static MySqlCommand command;

        public Conexao()
        {
            try
            {
                connection = new MySqlConnection($"server={host};database={dbname};port={port};user={user};password={password}");
                connection.Open();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public MySqlCommand Query()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                return command;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
