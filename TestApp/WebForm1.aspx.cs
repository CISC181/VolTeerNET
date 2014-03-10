using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolTeer.BusinessLogicLayer.AspNet;


namespace TestApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private AspNetRolesBLL RoleBLL = new AspNetRolesBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            AddRole();
        }

        public void AddRole()
        {
            string AppName = "/";
            string RoleName = "Test4";

            RoleBLL.AddRole(AppName, RoleName);

        }
    }
}