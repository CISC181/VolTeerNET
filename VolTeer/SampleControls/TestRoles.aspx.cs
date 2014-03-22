using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace VolTeer.SampleControls
{
    public partial class TestRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole("Admin"))
            {
                lblAdmin.Visible  = true;
            }
            else
            {
                lblNonAdmin.Visible = true;
            }
        }
    }
}