using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBPROJECT
{
    public partial class FYPSupervisor_Interface : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {            
            Response.Redirect("ProjectViewSupervisor.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProjectReview.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("NotificationViewSupervisor.aspx");
        }
    }
}