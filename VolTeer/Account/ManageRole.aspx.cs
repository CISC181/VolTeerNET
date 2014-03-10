using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//TODO: Check out- http://msdn.microsoft.com/en-us/library/8aeskccd(v=vs.85).aspx How to handle roles in web.config
//TODO: Only allow access to the screen for users that have 'Admin' role (this is done with web.config setting)
//TODO: Show a Grid of existing roles, give user ability to delete role, include 'add role' button, show a column with number of users that have the role
//TODO: If User 'Deletes' a role that have assigned users, show a confirmation ("Are you sure you want to continue?"), If they do, remove role from each user then remove role
//TODO: If User clicks 'Add Role', change screen to allow user to enter Role information, call [aspnet_Roles_CreateRole], then rebind the grid

namespace VolTeer.Account
{
    public partial class ManageRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}