using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.Cache.VT.Vol;
using System.Web.Security;

using System.Web.Caching;

namespace VolTeer.Volunteer
{
    public partial class VolunterInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadPage();
            }

            //ucVolAddress.gAddrOwner = new Guid();


            //ucVolAddress.iRecordTypeID = 1;

            //sp_Sample_Address_Select_DM dm = new sp_Sample_Address_Select_DM();

            //Cache.Add("Key1", "Value 1", null, DateTime.Now.AddSeconds(60), Cache.NoSlidingExpiration, CacheItemPriority.High, onRemove);


        }

        protected void LoadPage()
        {
            MembershipUser currentUser;
            currentUser = Membership.GetUser();
            Guid? UserID;
            UserID = (Guid)currentUser.ProviderUserKey;

            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_Vol_Address_Cache VolCASH = new sp_Vol_Address_Cache();
            sp_Volunteer_DM VolDM = new sp_Volunteer_DM();

            VolDM = VolCASH.ListVolunteers(UserID);

            ctl02.Text = (string)DataBinder.Eval(VolDM, "VolID");
            
            //Cache.Add(UserID.ToString(), VolDM, null, DateTime.Now.AddSeconds(60), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

    }
}