using System;
using System.Data.SqlClient;


namespace TakeFlight_ASP.NET_
{

    public class SQLConnection
    {
        private SqlConnection conn;

        public SQLConnection()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Server=sql.cs.luc.edu;uid=tmansheim;pwd=p40901;TrustServerCertificate=True;";
            conn.Open();

        }


    }
}