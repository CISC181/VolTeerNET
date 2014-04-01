using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolTeer.App_Code;

namespace VolTeer.SampleControls
{
    public partial class SampleSimpleControls : System.Web.UI.Page
    {

        protected void Page_Init(object sender, EventArgs e)
        {

            cValidations.SetValidations(this.Form , this.Form);


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
    }
}