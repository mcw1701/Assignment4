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
        //Establishing Connection and Authentication 
        KarateSchoolDataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\maeso\\OneDrive - North Dakota University System\\Desktop\\CompSci\\GitHub\\Assignment4\\Assignment4\\App_Data\\KarateSchool(1).mdf\";Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(conn);
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string username = Login1.UserName;
            string password = Login1.Password;

            var user = from u in dbcon.NetUsers
                       where u.UserName == username &&
                       u.UserPassword == password
                       select u;

            if (user.Count() != 0)
            {
                string id = user.FirstOrDefault().UserID.ToString();
                bool rememberMe = Login1.RememberMeSet;
                FormsAuthentication.SetAuthCookie(username, rememberMe);
                Session.Add(id, username);
                string type = user.FirstOrDefault().UserType.ToString();
                if (type == "Member")
                {
                    Response.Redirect("~/userPages/member.aspx", true);
                }
                else if (type == "Instructor")
                {
                    Response.Redirect("~/userPages/instructor.aspx", true);
                }
                else if (type == "Administrator")
                {
                    Response.Redirect("~/userPages/admin.aspx", true);
                }
                else
                {
                    Response.Redirect("login.aspx", true);
                }
            }
            else
            {
                Response.Redirect("login.aspx", true);
            }
        }
    }
}