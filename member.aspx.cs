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

        SqlConnection dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\cadek\\Desktop\\Kellar\\Assignment4-main\\Assignment4-main\\App_Data\\KarateSchool(1).mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checking to see if User is in right place
            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                login loginPage = new login();

                //Get current members ID and retrieve member info 
                int currentMemberID = loginPage.GetUserID(username);
                var query = "SELECT " + "S.SectionName, " + "I.InstructorFirstName, " + "I.InstructorLastName, " + "S.SectionStartDate, " + "S.SectionFee, " + "FROM Section S " + "JOIN Instructor I ON S.Instructor_ID = I.InstructorID " + "WHERE S.Member_ID = @MemberID;";

                //Connecting to database  and takes care of GridView of users 
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@MemberID", currentMemberID);
                    var dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);

                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();

                    using (KarateSchoolDataContext dbcon = new KarateSchoolDataContext(conn))
                    {
                        var memberInfo = dbcon.Members
                            .Where(m => m.Member_UserID == currentMemberID)
                            .Select(m => new
                            {
                                FirstName = m.MemberFirstName,
                                LastName = m.MemberLastName
                            })
                            .FirstOrDefault();

                        if (memberInfo != null)
                        {
                            Label1.Text = memberInfo.FirstName;
                            Label2.Text = memberInfo.LastName;
                        }
                    }
                }
            }
        }
    }
}