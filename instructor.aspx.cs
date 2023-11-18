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

        string firstName;
        string lastName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session.Count != 0)
            {
                foreach (var item in Session.Keys) {
                    lastName = Session[item.ToString()].ToString();
                    firstName = item.ToString();
                }
            } else
            {
                firstName = "Anne";
                lastName = "Denton";
            }
            lblInstructorName.Text = firstName + " " + lastName;
            dbcon = new KarateSchoolDataContext(connString);
            LoadSections();
        }

        private void LoadSections()
        {
            var records = from section in dbcon.Sections
                          from instruct in dbcon.Instructors
                          from mem in dbcon.Members
                          where instruct.InstructorLastName == lastName &&
                          instruct.InstructorFirstName == firstName &&
                          instruct.InstructorID == section.Instructor_ID &&
                          section.Member_ID == mem.Member_UserID
                          select new { section.SectionName, mem.MemberFirstName, mem.MemberLastName };

            GridView1.DataSource = records;
            GridView1.DataBind();
        }
    }
}