using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.BusinessLogicLayer;
using VolTeer.BusinessLogicLayer.AspNet;
using VolTeer.DomainModels;

namespace VolTeer.SampleControls
{
    public partial class TestForm1 : System.Web.UI.Page
    {
        private AspNetUsersBLL UserBLL = new AspNetUsersBLL();
        private AspNetRolesBLL RoleBLL = new AspNetRolesBLL();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                rDDRoles2.DataSource = RoleBLL.ListAspNetRoles();
                rDDRoles2.DataTextField = "RoleName";
                rDDRoles2.DataValueField = "RoleID";
                rDDRoles2.DataBind();

            }

            
        }



        protected void rDDRoles2_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            rdUserGrid.DataSource = UserBLL.vMembershipUsers_In_Role(rDDRoles2.SelectedText);
            rdUserGrid.DataBind();
        }
    }
}