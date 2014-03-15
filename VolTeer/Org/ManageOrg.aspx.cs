using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VolTeer.DomainModels.VT;
using VolTeer.BusinessLogicLayer.VT;

namespace VolTeer.Org
{
    public partial class ManageOrg : System.Web.UI.Page
    {
        private sp_Group_Select_BLL BLL = new sp_Group_Select_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void LoadGrid()        
        {
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = BLL.ListGroups(1);

        }


    }
}