using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DBPROJECT
{
    public partial class ViewInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //grid 1
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn.Open();
            string sql = "SELECT U.UserID, CONCAT(FirstName, ' ', LastName) As Name, Username As Username, UserPassword Password, StudentGrade As Grade From Users U, Student S WHERE U.UserID = S.UserID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            cmd.Dispose();
            conn.Close();

            //grid 2
            SqlConnection conn2 = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn2.Open();
            string sql2 = "SELECT U.UserID, CONCAT(FirstName, ' ', LastName) As Name, Username As Username, UserPassword Password, NumFYP As No_Of_FYPs From Users U, Supervisor S WHERE U.UserID = S.UserID";
            SqlCommand cmd2 = new SqlCommand(sql2, conn2);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            GridView2.DataSource = reader2;
            GridView2.DataBind();
            cmd2.Dispose();
            conn2.Close();

            //grid 3
            SqlConnection conn3 = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn3.Open();
            string sql3 = "SELECT U.UserID, CONCAT(FirstName, ' ', LastName) As Name, Username As Username, UserPassword Password From Users U, Panel_Member P WHERE U.UserID = P.UserID";
            SqlCommand cmd3 = new SqlCommand(sql3, conn3);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            GridView3.DataSource = reader3;
            GridView3.DataBind();
            cmd3.Dispose();
            conn3.Close();

            //grid 4
            SqlConnection conn4 = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn4.Open();
            string sql4 = "Select Project.ProjectID, CONCAT(U1.FirstName, ' ', U1.LastName) As Member_1, CONCAT(U2.FirstName, ' ', U2.LastName) As Member_2 , CONCAT(U3.FirstName, ' ', U3.LastName) As Member_3, CONCAT(Sup1.FirstName, ' ', Sup1.LastName) as Supervisor from Project, Users U1, Users U2, Users U3, Users Sup1 WHERE U1.UserID = Project.Member1_UserId AND U2.UserID = Project.Member2_UserId AND U3.UserID = Project.Member3_UserId AND Sup1.UserID = Project.Supervisor_UserId";
            SqlCommand cmd4 = new SqlCommand(sql4, conn4);
            SqlDataReader reader4 = cmd4.ExecuteReader();
            GridView4.DataSource = reader4;
            GridView4.DataBind();
            cmd4.Dispose();
            conn4.Close();

            //grid 5
            SqlConnection conn5 = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn5.Open();
            string sql5 = "select PPM.ProjectID, CONCAT(FirstName, ' ', LastName) As Panel_Member, Evaluation from Project_PanelMembers PPM, Users U WHERE U.UserID = PPM.PanelMemberUserId ORDER BY PPM.ProjectID ASC";
            SqlCommand cmd5 = new SqlCommand(sql5, conn5);
            SqlDataReader reader5 = cmd5.ExecuteReader();
            GridView5.DataSource = reader5;
            GridView5.DataBind();
            cmd5.Dispose();
            conn5.Close();

            //grid 6
            SqlConnection conn6 = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn6.Open();
            string sql6 = "Select ProjectID, convert(varchar(10), DeadlineDate, 111) as Date, CONVERT(varchar(15),CAST(DeadlineTime AS TIME),100) as Time from Deadline";
            SqlCommand cmd6 = new SqlCommand(sql6, conn6);
            SqlDataReader reader6 = cmd6.ExecuteReader();
            GridView6.DataSource = reader6;
            GridView6.DataBind();
            cmd6.Dispose();
            conn6.Close();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("FYPCommittee-Interface.aspx");
        }
    }
}