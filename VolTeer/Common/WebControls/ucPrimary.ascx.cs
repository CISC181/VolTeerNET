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
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Other;
using VolTeer.Cache.VT.Vol;
using VolTeer.GoogleAPI;
using System.Web.ApplicationServices;
using System.Web.Security;
using VolTeer.DomainModels.Service;
using VolTeer.GoogleAPI;
using System.IO;


namespace VolTeer.Common.WebControls
{
    public partial class ucPrimary : System.Web.UI.UserControl
    {

        // Event handler to call method on the main page.
        public event EventHandler ShowErrorOccurs;

        // Pass in the AddrOwner (VolID, GroupID, etc) and the RecordType (what kind of record it is)
        MembershipUser currentUser;
        public int iRecordTypeID;

        //  Object References
        private sp_Vol_Address_Cache VolAddrCash = new sp_Vol_Address_Cache();
        private sp_VolEmail_Cache VolEmailCache = new sp_VolEmail_Cache();
        private sp_VolPhone_Cache VolPhoneCache = new sp_VolPhone_Cache();

        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = Membership.GetUser();

            if (!IsPostBack)
            {
                HandleScreenLoad();
            }
        }

        protected void HandleScreenLoad()
        {
            SetPrimaryValues();
            pnlPrimaryInfo.Visible = true;

        }


        /// <summary>
        /// SetPrimaryValues - Paint the screen with default values (use non-telerik controls)
        /// </summary>
        protected void SetPrimaryValues()
        {
            //setup and bind all 3 primary values
            currentUser = Membership.GetUser();
            sp_Vol_Address_DM address_DM = new sp_Vol_Address_DM();
            sp_Email_DM email_DM = new sp_Email_DM();
            sp_Phone_DM phone_DM = new sp_Phone_DM();
            StringBuilder sb = new StringBuilder();

            try
            {
                //email code
                email_DM.VolID = (Guid)currentUser.ProviderUserKey;
                email_DM = VolEmailCache.ListPrimaryEmail(email_DM);
                if (email_DM != null)
                {
                    PrimaryEmail.Text = email_DM.EmailAddr;
                }
                else
                {
                    PrimaryEmail.Text = "-- NONE --";
                }


                //phone code
                phone_DM.VolID = (Guid)currentUser.ProviderUserKey;
                phone_DM = VolPhoneCache.ListPrimaryPhone(phone_DM);

                if (phone_DM != null)
                {
                    PrimaryPhone.Text = phone_DM.PhoneNbr;
                }
                else
                {
                    PrimaryPhone.Text = "-- NONE --";
                }

                //address code
                address_DM.VolID = (Guid)currentUser.ProviderUserKey;
                address_DM = VolAddrCash.ListPrimaryAddress(address_DM);

                sb.Clear();
                if (address_DM != null)
                {
                    sb.Append(address_DM.AddrLine1.ToString());
                    sb.Append(" ");
                    if (!string.IsNullOrEmpty(address_DM.AddrLine2))
                    {
                        sb.Append(address_DM.AddrLine2.ToString());
                        sb.Append(" ");
                    }
                    if (!string.IsNullOrEmpty(address_DM.AddrLine3))
                    {
                        sb.Append(address_DM.AddrLine3.ToString());
                        sb.Append(" ");
                    }
                    sb.Append(", ");
                    sb.Append(address_DM.City.ToString());
                    sb.Append(" ");
                    sb.Append(address_DM.St.ToString());
                    sb.Append(",  ");
                    sb.Append(address_DM.Zip.ToString());
                    if (!string.IsNullOrEmpty(address_DM.Zip4.ToString()))
                    {
                        sb.Append('-');
                        sb.Append(address_DM.Zip4.ToString());
                    }
                }
                PrimaryAddress.Text = sb.ToString();


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

        protected void CallSisterUserControl(string main_tabStrip, string main_multiPage, string first_pageView, string sec_tabStrip,
            int img ,string sec_multiPage, string sec_pageView)
        {

            RadTabStrip ParentRadTabStrip = (RadTabStrip)Parent.FindControl(main_tabStrip);
            ParentRadTabStrip.Tabs[0].Selected = true;

            RadMultiPage ParentRadMultiPage = (RadMultiPage)Parent.FindControl(main_multiPage);
            RadPageView pageview = (RadPageView)ParentRadMultiPage.FindPageViewByID(first_pageView);
            pageview.Selected = true;
            RadTabStrip tabstrip = (RadTabStrip)pageview.FindControl(sec_tabStrip);
            tabstrip.Tabs[img].Selected = true;

            //  Select the correct multipage
            RadMultiPage multipage = (RadMultiPage)pageview.FindControl(sec_multiPage);
            RadPageView rPageView = (RadPageView)multipage.FindPageViewByID(sec_pageView);
            rPageView.Selected = true;

        }

        protected void PrimaryEmail_Click(object sender, EventArgs e)
        {
            RadButton rbt = (RadButton)sender;
            CallSisterUserControl("RadTabStrip1", "RadMultiPage1", "RadPageView1", "RadTabStrip2", 1,  "RadMultiPage2", "PageView2");
        }

        protected void PrimaryPhone_Click(object sender, EventArgs e)
        {
            RadButton rbt = (RadButton)sender;
            CallSisterUserControl("RadTabStrip1", "RadMultiPage1", "RadPageView1", "RadTabStrip2", 2,"RadMultiPage2", "PageView3");
        }

        protected void PrimaryAddress_Click(object sender, EventArgs e)
        {
            RadButton rbt = (RadButton)sender;
            CallSisterUserControl("RadTabStrip1", "RadMultiPage1", "RadPageView1", "RadTabStrip2", 3,"RadMultiPage2", "PageView4");
        }

    }
}