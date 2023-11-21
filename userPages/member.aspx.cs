using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4
{
    public partial class member : System.Web.UI.Page
    {

        KarateSchoolDataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\maeso\\OneDrive - North Dakota University System\\Desktop\\CompSci\\GitHub\\Assignment4\\Assignment4\\App_Data\\KarateSchool(1).mdf\";Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(conn);

            //Checking to see if User is in right place
            if (User.Identity.IsAuthenticated)
            {
                if (Session.Count != 0)
                {
                    int id = 0;
                    foreach (var item in Session.Keys)
                    {
                        id = int.Parse(item.ToString());
                    }
                    var user = from record in dbcon.Members
                               where record.Member_UserID == id
                               select new { record.MemberFirstName, record.MemberLastName };

                    Label1.Text = user.FirstOrDefault().MemberFirstName;
                    Label2.Text = user.FirstOrDefault().MemberLastName;

                    var section = from sect in dbcon.Sections
                                   from i in dbcon.Instructors
                                   where sect.Member_ID == id &&
                                   sect.Instructor_ID == i.InstructorID
                                   select new { sect.SectionName, i.InstructorFirstName, i.InstructorLastName, 
                                       sect.SectionStartDate, sect.SectionFee };

                    GridView1.DataSource = section;
                    GridView1.DataBind();
                } else
                {
                    Response.Redirect("login.aspx", true);
                }
            } else
            {
                Response.Redirect("login.aspx", true);
            }
        }

    }
}