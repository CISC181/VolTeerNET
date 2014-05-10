using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;


public partial class RadEditorWebForm : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void rBTNSave_Click(object sender, EventArgs e)
    {
        sp_Group_DM GroupDM = new sp_Group_DM();
        sp_Group_BLL GroupBLL = new sp_Group_BLL();
       
        GroupDM.ActiveFlg = chkActive.Checked;
        GroupDM.ShortDesc = rTBShortDesc.Text.Trim();
        GroupDM.GroupName = rTBGroupName.Text.Trim();
        GroupDM.LongDesc = RadEditor1.Content;

        GroupBLL.InsertGroupContext(ref GroupDM);



    }
}
