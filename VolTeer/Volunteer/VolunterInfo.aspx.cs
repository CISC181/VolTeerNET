using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace VolTeer.Volunteer
{
    public partial class VolunterInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ucVolAddress.gAddrOwner = new Guid();
            ucVolAddress.iRecordTypeID = 1;
        }
    }
}