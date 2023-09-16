using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DBPROJECT
{
    public partial class GradeReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn.Open();
            string sql = "Select U.UserID, CONCAT(U.FirstName, ' ', U.LastName) As Name, count(StudentGrade) As No_of_A_grades_given FROM Project P, Users U, Project_PanelMembers PPM, Student S WHERE P.ProjectID = PPM.ProjectID AND U.UserID = PPM.PanelMemberUserId AND P.Member1_UserId = S.UserID AND S.StudentGrade = 'A' GROUP BY U.UserID, CONCAT(U.FirstName, ' ', U.LastName) having COUNT(StudentGrade) = (Select top 1 count(StudentGrade) As No_of_A_grades_given FROM Project P, Users U, Project_PanelMembers PPM, Student S WHERE P.ProjectID = PPM.ProjectID AND U.UserID = PPM.PanelMemberUserId AND P.Member1_UserId = S.UserID AND S.StudentGrade = 'A' GROUP BY U.UserID, CONCAT(U.FirstName, ' ', U.LastName) ORDER BY COUNT(StudentGrade) DESC)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            cmd.Dispose();
            conn.Close();

            //grid 2 Project
            SqlConnection conn2 = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn2.Open();
            string sql2 = "SELECT StudentGrade As Grade, COUNT(UserID) As No_of_Students From Student WHERE StudentGrade IS NOT NULL Group by StudentGrade";
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