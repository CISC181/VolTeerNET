using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VolTeer.Account
{
    public partial class RecoverPassword1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PasswordRecovery1_UserLookupError(object sender, EventArgs e)
        {
            //pnlContinue.Visible = true;
            //lblUserNotFound.Visible = true;
        }

        protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
        {
            //pnlContinue.Visible = true;
            //rBTNContinue.Visible = true;

        }
    }
}