using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4
{
    public partial class instructor : System.Web.UI.Page
    {
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\maeso\\OneDrive - North Dakota University System\\Desktop\\CompSci\\GitHub\\Assignment4\\Assignment4\\App_Data\\KarateSchool(1).mdf\";Integrated Security=True;Connect Timeout=30";
        KarateSchoolDataContext dbcon;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(connString);

            if (User.Identity.IsAuthenticated)
            {
                if (Session.Count != 0)
                {
                    int id = 0;
                    foreach (var item in Session.Keys)
                    {
                        id = int.Parse(item.ToString());
                    }
                    var user = from record in dbcon.Instructors
                               where record.InstructorID == id
                               select new { record.InstructorFirstName, record.InstructorLastName };

                    string first = user.FirstOrDefault().InstructorFirstName;
                    string last = user.FirstOrDefault().InstructorLastName;
                    lblInstructorName.Text = first + " " + last;

                    var records = from section in dbcon.Sections
                                  from instruct in dbcon.Instructors
                                  from mem in dbcon.Members
                                  where instruct.InstructorLastName == last &&
                                  instruct.InstructorFirstName == first &&
                                  instruct.InstructorID == id &&
                                  instruct.InstructorID == section.Instructor_ID &&
                                  section.Member_ID == mem.Member_UserID
                                  select new { section.SectionName, mem.MemberFirstName, mem.MemberLastName };

                    GridView1.DataSource = records;
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