using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vend.Masters
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                if (HttpContext.Current.Request.IsAuthenticated)
                {
                    

                    RadMenu1.Items[1].Items[0].Visible = true;
                    RadMenu1.Items[1].Items[1].Visible = true;
                    RadMenu1.Items[1].Items[2].Visible = false;
                    RadMenu1.Items[1].Items[3].Visible = true;

                    RadMenu1.Height = 48;
                }
                else
                {
                    RadMenu1.Items[1].Items[0].Visible = true;
                    RadMenu1.Items[1].Items[1].Visible = false;
                    RadMenu1.Items[1].Items[2].Visible = true;
                    RadMenu1.Items[1].Items[3].Visible = true;

                    RadMenu1.Height = 80;
                }
//                RadMenu1.Height = rHeight;

            }

        }
    }
}