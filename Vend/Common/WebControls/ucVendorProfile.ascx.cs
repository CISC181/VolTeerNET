using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

namespace Vend.Common.WebControls
{
    public partial class ucVendorProfile : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
                    rBTNSave.Text = "Update";
        }

        protected void rBTNSave_Click(object sender, EventArgs e)
        {

        }
    }
}