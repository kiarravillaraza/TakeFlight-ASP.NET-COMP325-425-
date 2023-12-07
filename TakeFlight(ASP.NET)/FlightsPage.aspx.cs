﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TakeFlight_ASP.NET_
{
    public partial class FlightsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Fetch and display data
                DisplayFlightInfo();
            }
        }

        private void DisplayFlightInfo()
        {
            var pass = "p40901";
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "sql.cs.luc.edu";
                builder.UserID = "tmansheim";
                builder.Password = pass;
                builder.InitialCatalog = "Cocktail Flight";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();

                    // Select the most recent flight 
                    string sql = "SELECT TOP 1 name, num, strength, drinkNames FROM flights ORDER BY flightID DESC";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Builds HTML Markup for Display 
                                StringBuilder htmlMarkup = new StringBuilder();
                                htmlMarkup.Append("<h2>" + reader["name"].ToString() + "</h2>");
                                htmlMarkup.Append("<p>Amount: " + reader["num"].ToString() + "</p>");
                                htmlMarkup.Append("<p>Strength: " + reader["strength"].ToString() + "</p>");

                                // Splits drink names and displays each one on its own line
                                string[] drinkNames = reader["drinkNames"].ToString().Split(',');
                                htmlMarkup.Append("<p>Drinks:</p><ul>");

                                foreach (string drink in drinkNames)
                                {
                                    htmlMarkup.Append("<li>" + drink.Trim() + "</li>");
                                }

                                htmlMarkup.Append("</ul>");

                                // Set the HTML markup to the Literal control
                                LiteralFlightInfo.Text = htmlMarkup.ToString();
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}

