using System;
using System.Data.SqlClient;


namespace TakeFlight_ASP.NET_
{

    public class SQLConn
    {
        private SqlConnection conn;

        public SQLConn()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Server=sql.cs.luc.edu;uid=tmansheim;pwd=<password>;TrustServerCertificate=True;";
            conn.Open();

        }


    }
}