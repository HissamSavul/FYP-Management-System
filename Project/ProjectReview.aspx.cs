using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DBPROJECT
{
    public partial class ProjectReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string userid = Request.Cookies["User"].Value;
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn.Open();
            SqlCommand cm;
            string projID = TextBox1.Text;
            string Review = TextBox2.Text;


            if (projID != "" && Review != "")
            {
                string query1 = " Select count(s.UserID) from Supervisor s inner join Project p on (s.UserID = p.Supervisor_UserId) where p.ProjectID = '" + projID + "' AND s.UserID =  '" + userid + "'";
                cm = new SqlCommand(query1, conn);
                object uniqueCheck = cm.ExecuteScalar();
                int res = int.Parse(uniqueCheck.ToString());
                if (res != 0)
                {
                    string query = "UPDATE Project set Review = '" + Review + "' Where ProjectID = '" + projID + "' AND Supervisor_UserId =  '" + userid + "'";
                    cm = new SqlCommand(query, conn);
                    cm.ExecuteNonQuery();
                    cm.Dispose();
                    conn.Close();
                    Response.Redirect("FYPSupervisor-Interface.aspx");
                }
                else
                    Response.Write("Either the Project,Supervisor doesn't exist in database or the supervisor is not incharge of the stated Project");
            }
            else
                Response.Write("Required fields are empty");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("FYPSupervisor-Interface.aspx");
        }
    }
}
