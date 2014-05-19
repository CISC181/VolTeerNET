using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Telerik.Web.UI;
using VolTeer.App_Code;
using VolTeer.BusinessLogicLayer.VT.Vend;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.BusinessLogicLayer.VT.Other;
using VolTeer.Cache.VT.Vend;
using VolTeer.GoogleAPI;
using System.Web.ApplicationServices;
using System.Web.Security;

using VolTeer.DomainModels.Service;
using System.IO;



namespace Vend.Common.WebControls
{
    public partial class ucVendorProjects : System.Web.UI.UserControl
    {
        public delegate void ButtonClickEventHandler(string data);
        public event ButtonClickEventHandler ButtonClickEvent = null;

        sp_VendorProjContact_BLL vpcBLL = new sp_VendorProjContact_BLL();
        sp_Project_BLL projectBLL = new sp_Project_BLL();
        MembershipUser currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = Membership.GetUser();

        }

        protected void rGridVendProjects_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                sp_Vendor_DM vendor = new sp_Vendor_DM();
                vendor.VendorID = (Guid)currentUser.ProviderUserKey;
                //List<sp_VendorProjContact_DM> vpcDMs = vpcBLL.ListContact();

                //vendProjContact.VendorID = (Guid)currentUser.ProviderUserKey;

                rGridVendProjects.DataSource = projectBLL.ListProjects();
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.

            }
        }

        protected void rGridVendProjects_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {

        }

        protected void rGridVendProjects_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            sp_Project_DM projectDM = new sp_Project_DM();

            try
            {
                /*
                GroupVol.VolID = (Guid)currentUser.ProviderUserKey;
                GroupVol.GroupID = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["GroupID"];

                GroupVolBLL.LeaveGroup(GroupVol);*/

            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                string errMethod = sf.GetMethod().Name.ToString();  // Get the current method name
                string errMsg = "600";                              // Gotta pass something, we're retro-fitting an existing method
                Session["LastException"] = ex;                      // Throw the exception in the session variable, will be used in error page
                string url = string.Format(ConfigurationManager.AppSettings["ErrorPageURL"], errMethod, errMsg); //Set the URL
                Response.Redirect(url);                             // Go to the error page.

            }
        }

        protected void rGridVendProjects_ItemCommand(object sender, GridCommandEventArgs e)
        {

            if (e.CommandName == "UpdateGroup")
            {
                HiddenField HDDGroupID = (HiddenField)Parent.FindControl("HDDGroupID");
                HDDGroupID.Value = e.CommandArgument.ToString();

                RadTabStrip ParentRadTabStrip = (RadTabStrip)Parent.FindControl("RadTabStrip1");
                ParentRadTabStrip.Tabs[1].Selected = true;

                RadMultiPage ParentRadMultiPage = (RadMultiPage)Parent.FindControl("RadMultiPage1");
                RadPageView pageview = (RadPageView)ParentRadMultiPage.FindPageViewByID("RadPageView2");
                pageview.Selected = true;
                RadTabStrip tabstrip = (RadTabStrip)pageview.FindControl("RadTabStrip3");
                tabstrip.Tabs[1].Selected = true;

                //  Select the correct multipage
                RadMultiPage multipage = (RadMultiPage)pageview.FindControl("RadMultiPage5");
                RadPageView rPageView = (RadPageView)multipage.FindPageViewByID("RadPageView6");
                rPageView.Selected = true;
            }


        }

        public void UpdateGroup(int GroupID)
        {


        }
    }

}