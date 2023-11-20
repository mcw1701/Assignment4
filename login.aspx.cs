using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Establishing Connection and Authentication 
        SqlConnection dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\cadek\\Desktop\\Kellar\\Assignment4-main\\Assignment4-main\\App_Data\\KarateSchool(1).mdf;Integrated Security=True;Connect Timeout=30";
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string userName = Login1.UserName;
            string pass = Login1.Password;

            string userType = "";
            string dbUser = "";
            string dbPass = "";
           
            
            //Getting User info from the table
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                string query = "SELECT UserType, UserName, UserPassword FROM NetUser WHERE UserName = @UserName;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userType = reader["UserType"].ToString();
                            dbUser = reader["UserName"].ToString();
                            dbPass = reader["Password"].ToString();
                        }
                    }
                }
            }
            //Checks the role and sends to what they are 
            if (userType == "Member" && dbUser == userName && dbPass == pass)
            {
                FormsAuthentication.RedirectFromLoginPage(userName, true);
                Response.Redirect("member.aspx", true);
            }
            else if (userType == "Instructor" && dbUser == userName && dbPass == pass)
            {
                FormsAuthentication.RedirectFromLoginPage(userName, true);
                Response.Redirect("instructor.aspx", true);
            }
            else if (userType == "Administrator" && dbUser == userName && dbPass == pass)
            {
                FormsAuthentication.RedirectFromLoginPage(userName, true);
                Response.Redirect("administrator.aspx", true);
            }
            else
                Response.Redirect("login.aspx", true);

        }

        //UserID get
        public int GetUserID(string username)
        {
            string userIDStr = "";

            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                string query = "SELECT UserID FROM NetUSer WHERE UserName = @UserName;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userIDStr = reader["UserID"].ToString();

                        }
                    }
                }
            }

            //String to integer
            int userID = int.Parse(userIDStr);
            return userID;
        }
    }
}