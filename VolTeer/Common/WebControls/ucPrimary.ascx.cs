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

		}


        /// <summary>
        /// SetPrimaryValues - Paint the screen with default values (use non-telerik controls)
        /// </summary>
        protected void SetPrimaryValues()
        {
            //setup and bind all 3 primary values
            sp_Vol_Address_DM address_DM = new sp_Vol_Address_DM();
            sp_Email_DM email_DM = new sp_Email_DM();
            sp_Phone_DM phone_DM = new sp_Phone_DM();
            StringBuilder sb = new StringBuilder();

            try
            {
                //email code
                email_DM.VolID = (Guid)currentUser.ProviderUserKey;
                email_DM = VolEmailCache.ListPrimaryEmail(email_DM);
                PrimaryEmail.Text = email_DM.EmailAddr;


                //phone code
                phone_DM.VolID = (Guid)currentUser.ProviderUserKey;
                phone_DM = VolPhoneCache.ListPrimaryPhone(phone_DM);
                PrimaryPhone.Text = phone_DM.PhoneNbr;

                //address code
                address_DM.VolID = (Guid)currentUser.ProviderUserKey;
                address_DM = VolAddrCash.ListPrimaryAddress(address_DM);

                sb.Clear();
                sb.Append(address_DM.City.ToString());
                sb.Append(", ");
                sb.Append(address_DM.St.ToString());
                sb.Append("   ");
                sb.Append(address_DM.Zip.ToString());
                if (!string.IsNullOrEmpty(address_DM.Zip4.ToString()))
                {
                    sb.Append('-');
                    sb.Append(address_DM.Zip4.ToString());
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
	}
}