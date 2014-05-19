using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


//TODO: Only allow access to the screen for users that have 'Admin' role (this is done with web.config setting)
//TODO: Show a Grid of existing users, give Admin the ability to "turn off/on" user (make IS_APPROVED = false/true)
//TODO: Add a column in the grid that contains a checkable combo box, the column has the available roles and the roles that are currently assigned
//TODO: Show 'current roles' column when grid is in update mode.  Otherwise render the column as a listbox


namespace Vend.Account
{
    public partial class ManageUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}