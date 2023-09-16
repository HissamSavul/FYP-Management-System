using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DBPROJECT
{
    public partial class ProjectViewPanelMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = Request.Cookies["User"].Value;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn.Open();
            SqlCommand cm;
            Response.Write("UserID: " + userid);
            string sql = "SELECT Project.ProjectID, CONCAT(U1.FirstName, ' ', U1.LastName) As Member_1, CONCAT(U2.FirstName, ' ', U2.LastName) As Member_2 , CONCAT(U3.FirstName, ' ', U3.LastName) As Member_3, CONCAT(Sup1.FirstName, ' ', Sup1.LastName) As Supervisor, StudentGrade As Grade from Project, Users U1, Users U2, Users U3, Users Sup1, Users Pan1, Project_PanelMembers PPM, Student WHERE U1.UserID = Project.Member1_UserId AND U2.UserID = Project.Member2_UserId AND U3.UserID = Project.Member3_UserId AND Sup1.UserID = Project.Supervisor_UserId AND Student.UserID = U1.UserID AND PPM.ProjectID = Project.ProjectID AND PPM.PanelMemberUserId = Pan1.UserID and Pan1.UserID = " + userid;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelMembers-Interface.aspx");
        }
    }
}