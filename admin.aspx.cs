using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4
{
    public partial class admin : System.Web.UI.Page
    {

        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\maeso\\OneDrive - North Dakota University System\\Desktop\\CompSci\\GitHub\\Assignment4\\Assignment4\\App_Data\\KarateSchool(1).mdf\";Integrated Security=True;Connect Timeout=30";
        KarateSchoolDataContext dbcon;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(connString);
            LoadRecords();
        }

        private void LoadRecords()
        {
            var records = from mem in dbcon.Members
                          select new { mem.MemberFirstName, mem.MemberLastName, mem.MemberDateJoined };

            GridView1.DataSource = records;
            GridView1.DataBind();
        }
    }
}