using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DBPROJECT
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string loginType = DropDownList1.Text;
            string uname = TextBox2.Text;
            string pword = TextBox3.Text;
            if (CheckBox1.Checked && (loginType != "" && uname != "" && pword != ""))
            {
                SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
                conn.Open();
                SqlCommand cm;
                string query1 = "SELECT COUNT(UserID) FROM Users WHERE UserName = '" + uname + "' AND UserPassWord = '" + pword + "'";
                cm = new SqlCommand(query1, conn);
                object q1 = cm.ExecuteScalar();
                int q1result = int.Parse(q1.ToString());
                if (q1result == 0)
                {
                    Response.Write("Incorrect Username or Password");
                    return;
                }
                string query = "SELECT UserID FROM Users WHERE UserName = '" + uname + "' AND UserPassWord = '" + pword + "'";
                cm = new SqlCommand(query, conn);
                object res = cm.ExecuteScalar();
                string result = res.ToString();
                int currentUser = int.Parse(result);
                query = "SELECT count(USERID) from " + loginType + " WHERE USERID = " + result;
                cm = new SqlCommand(query, conn);
                object res2 = cm.ExecuteScalar();
                int result2 = int.Parse(res2.ToString());
                if (result2 == 1)
                {
                    //SEND COOKIE FOR LOGGED IN SITE
                    HttpCookie UserCookie = new HttpCookie("User");
                    UserCookie.Value = currentUser.ToString();
                    Response.Cookies.Add(UserCookie);

                    string recordQuery = "INSERT INTO Audit_Records VALUES('" + loginType + " ID#" + currentUser.ToString() + " logged in', '" + DateTime.Now + "');";
                    cm = new SqlCommand(recordQuery, conn);
                    cm.ExecuteNonQuery();
                    if (loginType == "Committee_Member")
                    {
                        Response.Redirect("FYPCommittee-Interface.aspx");
                    }
                    else if (loginType == "Student")
                    {
                        Response.Redirect("StudentInterface.aspx");                        
                    }
                    else if (loginType == "Panel_Member")
                    {
                        Response.Redirect("PanelMembers-Interface.aspx");
                    }
                    else //if( loginType == "Supervisor" )
                    {
                        Response.Redirect("FYPSupervisor-Interface.aspx");
                    }
                }
                else
                    Response.Write("Incorrect Username or Password");
                cm.Dispose();
                conn.Close();

            }
            else if (loginType == "" || uname == "" || pword == "")
                Response.Write("Required fields are empty");
            else if (!CheckBox1.Checked)
                Response.Write("Incorrect Recaptcha");
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}