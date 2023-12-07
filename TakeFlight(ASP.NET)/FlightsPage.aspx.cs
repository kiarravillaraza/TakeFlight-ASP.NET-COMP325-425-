using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms.VisualStyles;

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
                                htmlMarkup.Append("<h2>" + reader["name"].ToString().ToUpper() + "</h2>");
                                htmlMarkup.Append("<h3><i>Strength: " + reader["strength"].ToString() + "</i>  | " + reader["num"].ToString() + " drinks" + "</h3>");


                                // Splits drink names and displays each one on its own line
                                string[] drinkNames = reader["drinkNames"].ToString().Split(',');
                                htmlMarkup.Append("<ul>");



                                foreach (string drink in drinkNames)
                                {
                                    htmlMarkup.Append("<p>" + drink.Trim() + "</p>");

                                    string recipe = "";
                                    string ingredient = "";
                                    string dURL;
                                    dURL = "https://www.thecocktaildb.com/api/json/v1/1/search.php?s=" + drink.Trim();
                                    WebRequest geturldrink = WebRequest.Create(dURL);
                                    Stream objStream = geturldrink.GetResponse().GetResponseStream();
                                    StreamReader objReader = new StreamReader(objStream);
                                    string str1 = objReader.ReadToEnd();

                                    //find ingredients

                                    for (int i = 0; i < 15; i++)
                                    {
                                        string toFind2 = "\"strIngredient"+(i+1)+"\":\"";
                                        int indToFind2 = str1.IndexOf(toFind2);
                                        string str2 = str1.Remove(0, indToFind2 + 18);
                                        string[] temp = str2.Split('"');
                                        ingredient = temp[0];
                                        if (!ingredient.Contains("null") && !ingredient.Contains("ink"))
                                        {
                                            htmlMarkup.Append("<p style=\"font-size:15px\">" + ingredient + "</p>");
                                        }
                                    }


                                    //find recipe
                                    
                                    string toFind = "\"strInstructions\":\"";
                                    int indToFind = str1.IndexOf(toFind);
                                    string str3 = str1.Remove(0, indToFind+19);
                                    string[] temp2 = str3.Split('"');
                                    recipe = temp2[0];
                                    recipe = recipe.Replace("\\n", "").Replace("\\r", " ");

                                    htmlMarkup.Append("<p style=\"font-size:20px\">" + recipe + "</p>");
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


