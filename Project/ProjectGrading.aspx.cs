using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DBPROJECT
{
    public partial class ProjectGrading : System.Web.UI.Page
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
            string Evaluation = TextBox2.Text;
            string grade = DropDownList1.Text;

            if (projID != "" && Evaluation != "" && grade != "")
            {
                string query1 = "select count(p.ProjectID) from Project p inner join Project_PanelMembers PM on (p.ProjectID = PM.ProjectID) where p.ProjectID ='" + projID + "' AND PM.PanelMemberUserId = '" + userid + "'";
                cm = new SqlCommand(query1, conn);
                object uniqueCheck = cm.ExecuteScalar();
                int res = int.Parse(uniqueCheck.ToString());
                if (res != 0)
                {
                    string query2 = "select count(p.Evaluation) from Project_PanelMembers p where p.ProjectID = '" + projID + "' AND p.PanelMemberUserId = '" + userid + "'";
                    cm = new SqlCommand(query2, conn);
                    object q2 = cm.ExecuteScalar();
                    int res2 = int.Parse(q2.ToString());
                    if (res2 == 0)
                    {
                        string query3 = "UPDATE Project_PanelMembers set Evaluation = '" + Evaluation + "' Where ProjectID = '" + projID + "' AND PanelMemberUserId =  '" + userid + "'";
                        cm = new SqlCommand(query3, conn);
                        cm.ExecuteNonQuery();
                        string query4 = "select s.UserID from Student s inner join Project p on(s.UserID = p.Member1_UserId) where p.ProjectID = '" + projID + "'";
                        cm = new SqlCommand(query4, conn);
                        object q4 = cm.ExecuteScalar();
                        int stud1ID = int.Parse(q4.ToString());
                        string query5 = "select s.UserID from Student s inner join Project p on(s.UserID = p.Member2_UserId) where p.ProjectID = '" + projID + "'";
                        cm = new SqlCommand(query5, conn);
                        object q5 = cm.ExecuteScalar();
                        int stud2ID = int.Parse(q5.ToString());
                        string query6 = "select s.UserID from Student s inner join Project p on(s.UserID = p.Member3_UserId) where p.ProjectID = '" + projID + "'";
                        cm = new SqlCommand(query6, conn);
                        object q6 = cm.ExecuteScalar();
                        int stud3ID = int.Parse(q6.ToString());
                        string query7 = "UPDATE Student set StudentGrade = '" + grade + "' where UserID = '" + stud1ID.ToString() + "' OR UserID = '" + stud2ID.ToString() + "'OR UserID = '" + stud3ID.ToString() + "'";
                        cm = new SqlCommand(query7, conn);
                        cm.ExecuteNonQuery();
                        cm.Dispose();
                        conn.Close();
                        Response.Redirect("PanelMembers-Interface.aspx");
                    }
                    else
                        Response.Write("Panelist has already evaluated the stated project");

                }
                else
                    Response.Write("Either Project, Panel Member dont exist or the stated project has not been assigned to the Panel Member");

            }
            else
                Response.Write("Required fields are empty");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelMembers-Interface.aspx");
        }
    }
}
