using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TakeFlight_ASP.NET_
{
    public partial class UserForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button2_Click(object sender, EventArgs e)
        {
            string email = FullName.Text;
            string username = Username.Text;
            string pass = Password.Text;
            string dob = Birthday.Text;
            
            //id to count and then assign free userid
            int id = 01;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "sql.cs.luc.edu";
                builder.UserID = "tmansheim";
                builder.Password = "p40901";
                builder.InitialCatalog = "Cocktail Flight";

                using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    String sql = "SELECT * FROM \"user\"";
                    

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
                MessageBox.Show("Your UserID is: " + id);

                //connection to assign data to found userid

                using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    String sql = "insert into \"user\"(userID, name, pass, email, DOB)\r\nvalues\r\n(" + id + ", '" + username + "', '" + pass + "', '" + email + "', '" + dob + "')";
                    MessageBox.Show(sql);

                    SqlCommand command = new SqlCommand(sql, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    connection.Close();



                }
            }
            catch (SqlException exceptionone)
            {

            }
        }
        }
}