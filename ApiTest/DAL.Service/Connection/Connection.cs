using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service.Connection
{
    public class Connection
    {
        public static string GetConnectionSystem()
        {
            string conString = ConfigurationManager.ConnectionStrings["CryptoEntities"].ConnectionString;

            return conString;
        }

        public static SqlConnection GetSqlConnection()
        {
            SqlConnection connect = new SqlConnection(GetConnectionSystem());

            return connect;
        }
    }
}
