using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DBPROJECT
{
    public partial class SendNotification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn.Open();
            SqlCommand cm;
            string supID = TextBox1.Text;
            string Notification = TextBox2.Text;


            if (supID != "" && Notification != "")
            {
                string query1 = "Select count(s.UserID) FROM Supervisor s, Project p WHERE s.UserID = '" + supID + "' AND p.Supervisor_UserId = '" + supID + "'";
                cm = new SqlCommand(query1, conn);
                object uniqueCheck = cm.ExecuteScalar();
                int res = int.Parse(uniqueCheck.ToString());
                if (res != 0)
                {
                    string query = "INSERT INTO Notifications VALUES(" + supID + ",'" + Notification + "')";
                    cm = new SqlCommand(query, conn);
                    cm.ExecuteNonQuery();
                    cm.Dispose();
                    conn.Close();
                    Response.Redirect("FYPCommittee-Interface.aspx");
                }
                else
                    Response.Write("Either Supervisor doesn't exist in database or they dont have Project(s) assigned");
            }
            else
                Response.Write("Required fields are empty");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("FYPCommittee-Interface.aspx");
        }
    }
}