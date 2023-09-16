using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBPROJECT
{
    public partial class FYPCommittee_Interface : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewUser.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("FYPDeadline.aspx");
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Response.Redirect("FYPDeadline.aspx");
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("FYPProject.aspx");
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuditRecordsView.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssignPanelMember.aspx");
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("SendNotification.aspx");
        }

        protected void Button17_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewInfo.aspx");
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            Response.Redirect("GradeReport.aspx");
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            Response.Redirect("FacultyReport.aspx");
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            Response.Redirect("MissingEvaluationReport.aspx");
        }
    }
}