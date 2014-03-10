using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolTeer.BusinessLogicLayer.VT;
using System.Web.Security;
using System.Web.ApplicationServices;


//Checkout: http://demos.telerik.com/aspnet-ajax/treelist/examples/overview/defaultcs.aspx#qsf-demo-source


//TODO: Create stored procedure to AddSkill (You'll need to know the MstrSkillID, SkillName)
//TODO: Create an add method to add a skill to a node on the tree
//TODO: Create stored procedure to DeleteSkill (You'll need SkillID).  Make sure to delete only skills that haven't been associated
//TODO: Add button on rTLSkills to delete a skill

//TODO: The AddSkill / DeleteSkill functions shoudl only be available to users with 'Admin' role.  

namespace VolTeer.Common.WebControls
{
    public partial class ucSkill : System.Web.UI.UserControl
    {
        private SkillBLL BLL = new SkillBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipUser currentUser;
            string[] strRoles;            

            currentUser = Membership.GetUser();
            strRoles = Roles.GetRolesForUser(currentUser.ToString());
            Boolean bHasRole =  Roles.IsUserInRole(currentUser.ToString(), "Admin");

            
        }
        protected void rTLSkills_NeedDataSource(object sender, Telerik.Web.UI.TreeListNeedDataSourceEventArgs e)
        {
            rTLSkills.DataSource = BLL.ListSkills();

        }
    }
}