using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DBPROJECT
{
    public partial class NotificationViewSupervisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = Request.Cookies["User"].Value;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn.Open();
            Response.Write("UserID: " + userid);
            string sql = "Select NotificationMessage As Notifications from Users U, Notifications N where U.UserID = N.Supervisor_UserID and N.Supervisor_UserID = " + userid;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();

            cmd.Dispose();
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("FYPSupervisor-Interface.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}