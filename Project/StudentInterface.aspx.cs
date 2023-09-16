using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DBPROJECT
{
    public partial class StudentInterface : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = Request.Cookies["User"].Value;
            Response.Write("UserID: " + userid);

            //grid 1 INFO
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn.Open();
            string sql = "Select U.UserID, CONCAT(U.FirstName, ' ', U.LastName) As Name, S.StudentGrade As Grade From Users U, Student S where S.UserID = U.UserID AND U.UserID = " + userid;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            cmd.Dispose();
            conn.Close();

            //grid 2 Project
            SqlConnection conn2 = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn2.Open();
            string sql2 = "Select Project.ProjectID, CONCAT(U1.FirstName, ' ', U1.LastName) As Member_1, CONCAT(U2.FirstName, ' ', U2.LastName) As Member_2 , CONCAT(U3.FirstName, ' ', U3.LastName) As Member_3 from Project, Users U1, Users U2, Users U3 WHERE U1.UserID = Project.Member1_UserId AND U2.UserID = Project.Member2_UserId AND U3.UserID = Project.Member3_UserId AND (U1.UserID = " + userid + " OR U2.UserID = " + userid + " OR U3.UserID =" + userid + ")";
            SqlCommand cmd2 = new SqlCommand(sql2, conn2);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            GridView2.DataSource = reader2;
            GridView2.DataBind();
            cmd2.Dispose();
            conn2.Close();

            //grid 3 Deadline
            SqlConnection conn6 = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn6.Open();
            string sql6 = "Select D.ProjectID, convert(varchar(10), DeadlineDate, 111) as Date, CONVERT(varchar(15),CAST(DeadlineTime AS TIME),100) as Time from Project, Users U1, Users U2, Users U3, Deadline D WHERE D.ProjectID = Project.ProjectID AND U1.UserID = Project.Member1_UserId AND U2.UserID = Project.Member2_UserId AND U3.UserID = Project.Member3_UserId AND (U1.UserID = " + userid + " OR U2.UserID = " + userid + " OR U3.UserID =" + userid + ")";
            SqlCommand cmd6 = new SqlCommand(sql6, conn6);
            SqlDataReader reader6 = cmd6.ExecuteReader();
            GridView3.DataSource = reader6;
            GridView3.DataBind();
            cmd6.Dispose();
            conn6.Close();

            //grid 4
            SqlConnection conn3 = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn3.Open();
            string sql3 = "Select CONCAT(Sup1.FirstName, ' ', Sup1.LastName) as Supervisor from Project, Users U1, Users U2, Users U3, Users Sup1 WHERE U1.UserID = Project.Member1_UserId AND U2.UserID = Project.Member2_UserId AND U3.UserID = Project.Member3_UserId AND Sup1.UserID = Project.Supervisor_UserId AND (U1.UserID = " + userid + " OR U2.UserID = " + userid + " OR U3.UserID =" + userid + ")";
            SqlCommand cmd3 = new SqlCommand(sql3, conn3);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            GridView4.DataSource = reader3;
            GridView4.DataBind();
            cmd3.Dispose();
            conn3.Close();

            //grid 5
            SqlConnection conn4 = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn4.Open();
            string sql4 = "Select Project.Review from Project, Users U1, Users U2, Users U3, Users Sup1 WHERE U1.UserID = Project.Member1_UserId AND U2.UserID = Project.Member2_UserId AND U3.UserID = Project.Member3_UserId AND Sup1.UserID = Project.Supervisor_UserId AND (U1.UserID = " + userid + " OR U2.UserID = " + userid + " OR U3.UserID =" + userid + ")";
            SqlCommand cmd4 = new SqlCommand(sql4, conn4);
            SqlDataReader reader4 = cmd4.ExecuteReader();
            GridView5.DataSource = reader4;
            GridView5.DataBind();
            cmd4.Dispose();
            conn4.Close();

            //grid 6
            SqlConnection conn5 = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn5.Open();
            string sql5 = "Select PPM.Evaluation from Project_PanelMembers PPM, Project, Users U1, Users U2, Users U3, Users Sup1 WHERE PPM.ProjectID = Project.ProjectID AND U1.UserID = Project.Member1_UserId AND U2.UserID = Project.Member2_UserId AND U3.UserID = Project.Member3_UserId AND Sup1.UserID = Project.Supervisor_UserId AND (U1.UserID = " + userid + " OR U2.UserID = " + userid + " OR U3.UserID =" + userid + ")";
            SqlCommand cmd5 = new SqlCommand(sql5, conn5);
            SqlDataReader reader5 = cmd5.ExecuteReader();
            GridView6.DataSource = reader5;
            GridView6.DataBind();
            cmd5.Dispose();
            conn5.Close();

            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}