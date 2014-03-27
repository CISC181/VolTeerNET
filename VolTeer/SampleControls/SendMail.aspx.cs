using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolTeer.App_Code;

namespace VolTeer.SampleControls
{
    public partial class SendMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cMail.SendMessage("to@test.com", "tstbag@yahoo.com", "test subject", "Test body");

        }
    }
}