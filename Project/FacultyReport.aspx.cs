using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DBPROJECT
{
    public partial class FacultyReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn.Open();
            string sql = "select s.UserID, CONCAT(u.FirstName,' ',u.LastName) as Supervisor, s.NumFYP from Users u inner join Supervisor s on (s.UserID=u.UserID)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            cmd.Dispose();
            conn.Close();

            //grid 2 Project
            SqlConnection conn2 = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn2.Open();
            string sql2 = "select s.UserID, CONCAT(u.FirstName,' ',u.LastName) as Supervisor, p.ProjectID from Users u inner join Supervisor s on (s.UserID=u.UserID) inner join Project p on (s.UserID=p.Supervisor_UserId)";
            SqlCommand cmd2 = new SqlCommand(sql2, conn2);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            GridView2.DataSource = reader2;
            GridView2.DataBind();
            cmd2.Dispose();
            conn2.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("FYPCommittee-Interface.aspx");
        }
    }
}