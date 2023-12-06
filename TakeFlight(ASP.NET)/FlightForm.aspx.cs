using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace TakeFlight_ASP.NET_
{
    public partial class FlightForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //grabs data from form
        protected void button1_Click(object sender, EventArgs e)
        {
            string uid = UserID.Text;
            string Flight = FlightName.Text;
            int Drinks = ddlNumDrinks.SelectedIndex + 3;
            string Strength = DrinkStrength.Text; ;
            string Alcohol = "";
            bool firstItem = false;
            if (Vodka.Checked)
            {
                Alcohol = Alcohol + "Vodka";
                firstItem = true;
            }
            if (Whiskey.Checked)
            {
                if (firstItem)
                {
                    Alcohol = Alcohol + ",";
                }
                Alcohol = Alcohol + "Whiskey";
                firstItem = true;
            }
            if (Rum.Checked)
            {
                if (firstItem)
                {
                    Alcohol = Alcohol + ",";
                }
                Alcohol = Alcohol + "Rum";
                firstItem = true;
            }
            if (Gin.Checked)
            {
                if (firstItem)
                {
                    Alcohol = Alcohol + ",";
                }
                Alcohol = Alcohol + "Gin";
                firstItem = true;
            }
            if (Brandy.Checked)
            {
                if (firstItem)
                {
                    Alcohol = Alcohol + ",";
                }
                Alcohol = Alcohol + "Brandy";
                firstItem = true;
            }
            if (Tequila.Checked)
            {
                if (firstItem)
                {
                    Alcohol = Alcohol + ",";
                }
                Alcohol = Alcohol + "Tequila";
                firstItem = true;
            }

            //id to count and then assign free flightID
            int id = 01;
            int userid = 01;
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "sql.cs.luc.edu";
                builder.UserID = "tmansheim";
                builder.Password = "p40901";
                builder.InitialCatalog = "Cocktail Flight";

                using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    String sql = "SELECT * FROM flights";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            //returns true while there are more lines to read
                            while (reader.Read())
                            {
                                id++;
                            }
                            connection.Close();
                        }
                    }

                }

                using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    String sql = "SELECT * FROM \"user\";";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            //returns true while there are more lines to read
                            while (reader.Read())
                            {
                                string normalized1 = Regex.Replace(reader.GetString(1), @"\s", "");
                            if (normalized1.Equals(uid))
                                {
                                    userid = (int) reader.GetInt64(0);
                                    MessageBox.Show(userid.ToString());
                                } 
                            }
                            connection.Close();
                        }
                    }

                }

                //connection to assign data to found flightID

                using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    String sql = "insert into flights(flightid, name, num, strength, userID, alcohol)\r\nvalues\r\n(" + id + ", '" + Flight + "', " + Drinks + ", '" + Strength + "', " + userid + ", '" + Alcohol + "')";


                    SqlCommand command = new SqlCommand(sql, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    connection.Close();

                }

            //calls Response method
            RequestResponse.Response();
        }
    }
}