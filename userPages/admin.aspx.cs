using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace Assignment4
{
    public partial class admin : System.Web.UI.Page
    {

        public admin()
        {

        }

        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\maeso\\OneDrive - North Dakota University System\\Desktop\\CompSci\\GitHub\\Assignment4\\Assignment4\\App_Data\\KarateSchool(1).mdf\";Integrated Security=True;Connect Timeout=30";
        KarateSchoolDataContext dbcon;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(connString);
            if (User.Identity.IsAuthenticated)
            { 
                if (Session.Count != 0)
                {
                    LoadMembers();
                    LoadInstructors();
                } else
                {
                    Response.Redirect("login.aspx", true);
                }
            } else
            {
                Response.Redirect("login.aspx", true);
            }
        }

        private void LoadMembers()
        {
            var records = from mem in dbcon.Members
                          select new { mem.MemberFirstName, mem.MemberLastName, mem.MemberPhoneNumber, mem.MemberDateJoined };

            MembersGridView.DataSource = records;
            MembersGridView.DataBind();
        }

        private void LoadInstructors()
        {
            var records = from inst in dbcon.Instructors
                          select new { inst.InstructorFirstName, inst.InstructorLastName };
            InstructorsGridView.DataSource = records;
            InstructorsGridView.DataBind();
        }

        protected void btnAddMemberToSection_Click(object sender, EventArgs e)
        {
            if (MembersGridView.SelectedIndex != -1 && InstructorsGridView.SelectedIndex != -1)
            {
                string memberFirstName = MembersGridView.SelectedRow.Cells[2].Text;
                string memberLastName = MembersGridView.SelectedRow.Cells[3].Text;
                Member member = (from x in dbcon.Members
                                 where memberFirstName == x.MemberFirstName &&
                                 memberLastName == x.MemberLastName
                                 select x).First();

                string instructorFirstName = InstructorsGridView.SelectedRow.Cells[2].Text;
                string instructorLastName = InstructorsGridView.SelectedRow.Cells[3].Text;
                Instructor instructor = (from x in dbcon.Instructors
                                         where instructorFirstName == x.InstructorFirstName &&
                                         instructorLastName == x.InstructorLastName
                                         select x).First();

                Section section = new Section();
                section.SectionName = ddlSections.Text;
                section.Member_ID = member.Member_UserID;
                section.Instructor_ID = instructor.InstructorID;
                section.SectionStartDate = DateTime.Now;
                section.SectionFee = Convert.ToDecimal(tbxFee.Text);

                dbcon.Sections.InsertOnSubmit(section);
                dbcon.SubmitChanges();

            }
        }

        protected void btnCreateNewUser_Click(object sender, EventArgs e)
        {

            NetUser user = new NetUser();
            user.UserName = tbxUsername.Text;
            user.UserPassword = tbxPassword.Text;
            user.UserType = ddlUserType.SelectedValue;
            dbcon.NetUsers.InsertOnSubmit(user);
            dbcon.SubmitChanges();

            NetUser u = (from x in dbcon.NetUsers
                         where x.UserName == tbxUsername.Text &&
                         x.UserPassword == tbxPassword.Text
                         select x).First();

            if (ddlUserType.SelectedValue == "Member")
            {
                Member member = new Member();
                member.Member_UserID = u.UserID;
                member.MemberFirstName = tbxFirst.Text;
                member.MemberLastName = tbxLast.Text;
                member.MemberDateJoined = DateTime.Now;
                member.MemberPhoneNumber = tbxPhone.Text;
                member.MemberEmail = tbxEmail.Text;
                dbcon.Members.InsertOnSubmit(member);
                dbcon.SubmitChanges();
            } else
            {
                Instructor instructor = new Instructor();
                instructor.InstructorID = u.UserID;
                instructor.InstructorFirstName = tbxFirst.Text;
                instructor.InstructorLastName = tbxLast.Text;
                instructor.InstructorPhoneNumber = tbxPhone.Text;
                dbcon.Instructors.InsertOnSubmit(instructor);
                dbcon.SubmitChanges();
            }

            LoadMembers();
            LoadInstructors();
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (ddlUserType.SelectedValue == "Member") Panel1.Visible = true;
                else Panel1.Visible = false;
            }
        }
    }
}