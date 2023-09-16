using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DBPROJECT
{
    public partial class AssignPanelMember : System.Web.UI.Page
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
            string ProjID = TextBox1.Text;
            string PanelMemID = TextBox2.Text;

            if (ProjID != "" && PanelMemID != "")
            {
                string ProjectIDCheck = "select count(P.ProjectID),count(UserID) FROM Project P, Panel_Member PM WHERE P.ProjectID = '" + ProjID + "' AND PM.UserID = '" + PanelMemID + "'";
                cm = new SqlCommand(ProjectIDCheck, conn);
                object IDCheck = cm.ExecuteScalar();
                int res = int.Parse(IDCheck.ToString());
                if (res != 0)
                {
                    string UniqueProjectIDCheck = "select count(ProjectID),count(PanelMemberUserId) FROM Project_PanelMembers WHERE ProjectID = '" + ProjID + "' AND PanelMemberUserId = '" + PanelMemID + "'";
                    cm = new SqlCommand(UniqueProjectIDCheck, conn);
                    object uniqueCheck = cm.ExecuteScalar();
                    int res2 = int.Parse(uniqueCheck.ToString());
                    if (res2 == 0)
                    {
                        string query = "INSERT INTO Project_PanelMembers VALUES('" + ProjID + "','" + PanelMemID + "', NULL); ";
                        cm = new SqlCommand(query, conn);
                        cm.ExecuteNonQuery();
                        cm.Dispose();
                        conn.Close();
                        Response.Redirect("FYPCommittee-Interface.aspx");
                    }
                    else
                        Response.Write("Panel Member is already assigned this Project");
                }
                else
                    Response.Write("Project or PanelMember doesnot Exist");
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