using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DBPROJECT
{
    public partial class FYPProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn.Open();
            SqlCommand cm;
            string SupID = TextBox1.Text;
            string stud1ID = TextBox2.Text;
            string stud2ID = TextBox3.Text;
            string stud3ID = TextBox4.Text;
            if (SupID != "" && stud1ID != "" && stud2ID != "" && stud3ID != "")
            {
                string userIDCheck = "select count(su.UserID),count(s1.UserID),count(s2.UserID),count(s3.UserID) from Supervisor su, Student s1, Student s2, Student s3 WHERE su.UserID = '" + SupID + "' AND s1.UserID = '" + stud1ID + "' AND s2.UserID = '" + stud2ID + "' AND s3.UserID = '" + stud3ID + "' AND s1.UserID != s2.UserID AND s1.UserID != s3.UserID AND s2.UserID != s3.UserID";
                cm = new SqlCommand(userIDCheck, conn);
                object IDCheck = cm.ExecuteScalar();
                int res = int.Parse(IDCheck.ToString());
                if (res != 0)
                {
                    string query2 = "select count(Supervisor_UserId) FROM Project where Supervisor_UserId = '" + SupID + "'";
                    cm = new SqlCommand(query2, conn);
                    object uniqueCheck = cm.ExecuteScalar();
                    int res2 = int.Parse(uniqueCheck.ToString());
                    if (res2 != 6)
                    {
                        res2++;
                        string query3 = "SELECT COUNT(Project.ProjectID) FROM Project";
                        cm = new SqlCommand(query3, conn);
                        object q1 = cm.ExecuteScalar();
                        int idProj = int.Parse(q1.ToString());
                        idProj++;
                        string query4 = "select count(Member1_UserId),count(Member2_UserId),count(Member3_UserId) FROM Project where Member1_UserId = '" + stud1ID + "' OR Member1_UserId = '" + stud2ID + "' OR Member1_UserId = '" + stud3ID + "' OR Member2_UserId = '" + stud1ID + "' OR Member2_UserId = '" + stud2ID + "' OR Member2_UserId = '" + stud3ID + "' OR Member3_UserId = '" + stud1ID + "' OR Member3_UserId = '" + stud2ID + "' OR Member3_UserId ='" + stud3ID + "'";
                        cm = new SqlCommand(query4, conn);
                        object check2 = cm.ExecuteScalar();
                        int res3 = int.Parse(check2.ToString());
                        if (res3 == 0)
                        {
                            string query = "INSERT INTO Project VALUES(" + idProj.ToString() + ",'" + SupID + "','" + stud1ID + "','" + stud2ID + "','" + stud3ID + "', NULL); ";
                            cm = new SqlCommand(query, conn);
                            cm.ExecuteNonQuery();
                            string updquery = "UPDATE Supervisor SET NumFYP = '" + res2.ToString() + "' Where UserID = '" + SupID + "'";
                            cm = new SqlCommand(updquery, conn);
                            cm.ExecuteNonQuery();
                            cm.Dispose();
                            conn.Close();
                            Response.Redirect("FYPCommittee-Interface.aspx");
                        }
                        else
                            Response.Write("Any of the Student(s) is already assigned a Project");

                    }
                    else if (res2 == 6)
                        Response.Write("Supervisor Already has 6 FYPs Assigned");
                }
                else
                    Response.Write("Either Supervisor or any of the Student(s) doesn't exist in the Database");
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