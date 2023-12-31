﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TakeFlight_ASP.NET_
{
    public class RequestResponse
    {
        public static void Response()
        {
            string pass = "p40901";
            int id = 0;
            string alc = "";
            int num = 3;

            //finds last entered flight request
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "sql.cs.luc.edu";
                builder.UserID = "tmansheim";
                builder.Password =pass;
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

                }
            }
            catch (SqlException expectiontwo)
            {

            }

            string[] alcohol = alc.Split(',');
            string fulllist = "";


            for (int i = 0; i < alcohol.Length; i++)
            {
                alc = alcohol[i];
                string sURL;
                sURL = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?i=" + alc;

                WebRequest geturl;
                geturl = WebRequest.Create(sURL);
                Stream objStream;
                objStream = geturl.GetResponse().GetResponseStream();

                //reading and parsing
                StreamReader objReader = new StreamReader(objStream);
                string str1 = objReader.ReadToEnd();
                string str = str1.Remove(str1.Length - 2, 2);
                str = str.Remove(0, 11);
                fulllist = fulllist + str;

            }
            string[] drinks = fulllist.Split('}');

            //getting rid of errant char
            for (int i = 0; i < drinks.Length; i++)
            {
                drinks[i] = drinks[i] + "}";
            }

            for (int i = 1; i < drinks.Length; i++)
            {
                drinks[i] = drinks[i].Remove(0, 1);
            }

            //creating array with just drink names
            string[] drinkNamesorig = new string[drinks.Length-1];

            for (int i = 0; i < drinks.Length-1; i++)
            {
                string temp = drinks[i];
                temp = temp.Remove(0, 13);
                string[] tempArray = temp.Split('"');

                int ind = tempArray[0].IndexOf('\'');
                if (ind != -1)
                {
                    tempArray[0] = tempArray[0].Insert(ind, "\'");
                }

                drinkNamesorig[i] = tempArray[0];
            }

            var drinkNames = drinkNamesorig.Shuffle();

            string drinkNamesToEnter = "";
            //listing drink names


            drinkNamesToEnter = drinkNamesToEnter + drinkNames[0];

            alc = Regex.Replace(alc, @"\s", "");
            if (alc!="Whiskey")
            {
                for (int i = 1; i < num; i++)
                {
                    drinkNamesToEnter = drinkNamesToEnter + ", " + drinkNames[i];
                }
            } else
            {
                drinkNamesToEnter = "Hot Toddy, Damned if you do, Owen''s Grandmother''s Revenge";
            }


            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "sql.cs.luc.edu";
                builder.UserID = "tmansheim";
                builder.Password =pass;
                builder.InitialCatalog = "Cocktail Flight";
                builder.TrustServerCertificate = true;

                string sql = "UPDATE flights SET drinkNames = '" + drinkNamesToEnter + "' WHERE flightID = " + id + ";";

                using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    SqlCommand command = new SqlCommand(sql, connection);

                    SqlDataReader reader = command.ExecuteReader();
                    

                    connection.Close();



                }
            }
            catch (SqlException exceptionone)
            {

            }
        }

        /* TODO:
         * add user entry methods
         * rating drink method?
         */
    }
}