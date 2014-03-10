using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VolTeer.Account
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Guid CID;

            //TODO If user has CID in the query string, set the CID parm and call FinishPasswordForgotten
        }

        protected void FinishPasswordForgotten(Guid CID)
        {
            int i = 0;
            //TODO Check the 'Confirmation' table, if exists, set correct status, if not exists, show error (Confirmation does not exist).

            //TODO If CID is valid, reset the user's password with randomly changed password and email the Password to the user.

            //TODO After password is emailed to user, display message and link to continue to log in.

        }

        protected void rBTSubmit_Click(object sender, EventArgs e)
        {
            //TODO Check to see if Email exists for user, Fail if it doesn't

            //TODO Create a new GUID, then create new 'Confirmation' record

            //TODO Set the user's "IS_APPROVED" to false (turn off their account).

            //TODO Send a mail to the user with the ForgotPassword.aspx?CID=GUID so the user can reset their password

        }
    }
}