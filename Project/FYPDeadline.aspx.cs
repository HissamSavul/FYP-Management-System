using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DBPROJECT
{
    public partial class FYPDeadline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            
          
            
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn.Open();
            SqlCommand cm;
            string ProjID = TextBox1.Text;
            string DDate = TextBox2.Text;
            string DTime = TextBox3.Text;

            if (ProjID != "" && DDate != "" && DTime != "")
            {
                string ProjectIDCheck = "Select count(ProjectID) FROM Project WHERE ProjectID = '" + ProjID + "'";
                cm = new SqlCommand(ProjectIDCheck, conn);
                object IDCheck = cm.ExecuteScalar();
                int res = int.Parse(IDCheck.ToString());
                if (res == 1)
                {
                    string UniqueProjectIDCheck = "Select count(ProjectID) FROM Deadline WHERE ProjectID = '" + ProjID + "'";
                    cm = new SqlCommand(UniqueProjectIDCheck, conn);
                    object uniqueCheck = cm.ExecuteScalar();
                    int res2 = int.Parse(uniqueCheck.ToString());
                    if (res2 == 0)
                    {
                        string query = "INSERT INTO Deadline VALUES('" + ProjID + "','" + DDate + "','" + DTime + "')";
                        cm = new SqlCommand(query, conn);
                        cm.ExecuteNonQuery();
                        cm.Dispose();
                        conn.Close();
                        Response.Redirect("FYPCommittee-Interface.aspx");
                    }
                    else
                        Response.Write("Project Deadline Already Exists");
                }
                else
                    Response.Write("Project doesnot Exist");
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