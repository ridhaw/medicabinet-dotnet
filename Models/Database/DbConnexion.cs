using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCabinet.Models.Database
{
    public static class DbConnexion
    {
        // Modifiez cette chaîne selon votre configuration SQL Server
        private static readonly string connectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=MediCabinetDB;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Méthode utilitaire pour tester la connexion
        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
