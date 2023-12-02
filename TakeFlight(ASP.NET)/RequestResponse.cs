using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TakeFlight_ASP.NET_
{
    public class RequestResponse
    {
        public static void Response()
        {
            int id = 0;
            string alc = "";
            int num = 3;

            //finds last entered flight request
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "sql.cs.luc.edu";
                builder.UserID = "tmansheim";
                builder.Password = "password";
                builder.InitialCatalog = "Cocktail Flight";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    String sql = "SELECT * FROM flights";
                    Console.WriteLine(connection.ToString());

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            //returns true while there are more lines to read
                            while (reader.Read())
                            {
                                id++;
                            }

                        }
                    }

                    sql = "select * from flights;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            //returns true while there are more lines to read
                            while (reader.Read())
                            {
                                //Console.WriteLine("UID: "+reader.GetInt64(0)+" password: "+reader.GetString(1)+" email: "+reader.GetString(2));
                                if (reader.GetInt64(0) == id)
                                {
                                    //finds alcohol they wanted in that flight
                                    alc = reader.GetString(5);

                                    //finds number of drinks they wanted
                                    num = (int)reader.GetInt64(2);

                                }
                            }
                            connection.Close();
                        }
                    }


                    connection.Close();

                }
            }
            catch (SqlException expectiontwo)
            {

            }

            string sURL;
            sURL = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?i=" + alc;

            WebRequest geturl;
            geturl = WebRequest.Create(sURL);
            Stream objStream;
            objStream = geturl.GetResponse().GetResponseStream();

            //reading and parsing
            StreamReader objReader = new StreamReader(objStream);
            string str = objReader.ReadToEnd();
            str = str.Remove(0, 11);
            string[] drinks = str.Split('}');


            for (int i = 0; i < drinks.Length; i++)
            {
                drinks[i] = drinks[i] + "}";
            }

            for (int i = 1; i < drinks.Length; i++)
            {
                drinks[i] = drinks[i].Remove(0, 1);
            }

            for (int i = 0; i < num; i++)
            {
                System.Windows.Forms.MessageBox.Show(drinks[i]);
            }
        }


    }
}