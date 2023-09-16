using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DBPROJECT
{
    public partial class NewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1MN5JIR\\SQLEXPRESS03;Initial Catalog=DBProject;Integrated Security=True");
            conn.Open();
            SqlCommand cm;
            string firstname = TextBox1.Text;
            string lastname = TextBox2.Text;
            string username = TextBox3.Text;
            string password = TextBox4.Text;
            string loginType = DropDownList1.Text;
            if (loginType != "" && firstname != "" && lastname != "" && username != "" && password != "")
            {
                string usernameUniqueCheck = "Select count(UserID) FROM Users WHERE Username = '" + username + "'";
                cm = new SqlCommand(usernameUniqueCheck, conn);
                object uniqueCheck = cm.ExecuteScalar();
                int res = int.Parse(uniqueCheck.ToString());
                if (res == 0)
                {
                    string query1 = "SELECT COUNT(UserID) FROM Users";
                    cm = new SqlCommand(query1, conn);
                    object q1 = cm.ExecuteScalar();
                    int idUser = int.Parse(q1.ToString());
                    idUser++;
                    string query = "INSERT INTO Users VALUES(" + idUser.ToString() + ",'" + username + "','" + password + "','" + firstname + "','" + lastname + "')";
                    cm = new SqlCommand(query, conn);
                    cm.ExecuteNonQuery();
                    if (loginType == "Committee_Member")
                        query = "INSERT INTO Committee_Member VALUES(" + idUser.ToString() + ");";
                    else if (loginType == "Student")
                        query = "INSERT INTO Student VALUES(" + idUser.ToString() + ", NULL);";
                    else if (loginType == "Panel_Member")
                        query = "INSERT INTO Panel_Member VALUES(" + idUser.ToString() + ");";
                    else //if( loginType == "Supervisor" )
                        query = "INSERT INTO Supervisor VALUES(" + idUser.ToString() + ", 0);";
                    cm = new SqlCommand(query, conn);
                    cm.ExecuteNonQuery();
                    cm.Dispose();
                    conn.Close();
                    Response.Redirect("FYPCommittee-Interface.aspx");
                }
                else
                    Response.Write("Username is taken");
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