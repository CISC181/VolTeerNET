using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.BusinessLogicLayer;
using VolTeer.BusinessLogicLayer.AspNet;
using VolTeer.BusinessLogicLayer.AspNet;
using VolTeer.DomainModels;
using Telerik.Web.UI;

namespace VolTeer.SampleControls
{
    public partial class DataManipulation : System.Web.UI.Page
    {
        private AspNetRolesBLL RoleBLL = new AspNetRolesBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = RoleBLL.ListAspNetRoles();
        }

        private void RadGrid1_Rebind()
        {
            RadGrid1.DataSource = RoleBLL.ListAspNetRoles();
            RadGrid1.DataBind();

        }


        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            RoleBLL.AddRole("/", txtRole.Text.ToString());
            RadGrid1_Rebind();
        }

        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            String Parm;

            Parm = e.CommandArgument.ToString();

            if (e.CommandName == "Delete")

                RoleBLL.DeleteRole("/", e.CommandArgument.ToString(), true);
            {

                RadGrid1_Rebind();
            }

        }
    }
}