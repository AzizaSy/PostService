using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamsGH.Classes
{
    public static class DB
    {
        public static SqlConnection Connect
        {
            get
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                return connection;
            }
        }

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DreamsGH"].ConnectionString;
            }
        }
    }
}
