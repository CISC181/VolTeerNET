using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

namespace VolTeer.Common.WebControls
{
    public partial class ucGroupInsertUpdate : System.Web.UI.UserControl
    {
        public int? PassedGroupID;
        sp_Group_BLL GroupBLL = new sp_Group_BLL();
        sp_Group_DM GroupDM = new sp_Group_DM();

        protected void Page_Load(object sender, EventArgs e)
        {
            PassedGroupID = 1;

            if (!IsPostBack)
            {
                if (PassedGroupID == null)
                {
                    rBTNSave.Text = "Insert";
                }
                else
                {
                    rBTNSave.Text = "Update";
                    GetGroupData();
                }
            }

        }

        protected void GetGroupData()
        {
            GroupDM = GroupBLL.ListGroups(Convert.ToInt32(PassedGroupID));

            HiddenField HDDGroupID = (HiddenField)Parent.FindControl("HDDGroupID");
            HDDGroupID.Value = GroupDM.GroupID.ToString();

            chkActive.Checked = (bool)GroupDM.ActiveFlg;
            rTBShortDesc.Text = GroupDM.ShortDesc;
            rTBGroupName.Text = GroupDM.GroupName;
            RadEditor1.Content = GroupDM.LongDesc;

        }


        protected void rBTNSave_Click(object sender, EventArgs e)
        {

            GroupDM.ActiveFlg = chkActive.Checked;
            GroupDM.ShortDesc = rTBShortDesc.Text.Trim();
            GroupDM.GroupName = rTBGroupName.Text.Trim();
            GroupDM.LongDesc = RadEditor1.Content;

            if (rBTNSave.Text == "Insert")
            {
                GroupBLL.InsertGroupContext(ref GroupDM);
            }
            else
            {
                HiddenField HDDGroupID = (HiddenField)Parent.FindControl("HDDGroupID");
                GroupDM.GroupID = Convert.ToInt32(HDDGroupID.Value);
                GroupBLL.UpdateGroupContext(GroupDM);

               
            }

        }
    }
}