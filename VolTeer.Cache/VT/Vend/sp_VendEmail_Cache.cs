using System;
using System.Linq;

using VolTeer.DomainModels.VT.Vend;
using VolTeer.BusinessLogicLayer.VT.Vend;
using System.Collections.Generic;

using System.Web;
using System.Web.Caching;




using System;
using System.Linq;

using VolTeer.DomainModels.VT.Vend;
using VolTeer.BusinessLogicLayer.VT.Vend;
using System.Collections.Generic;

using System.Web;
using System.Web.Caching;


namespace VolTeer.Cache.VT.Vend
{
    public class sp_VendEmail_Cache
    {
        sp_VendEmail_BLL BLL = new sp_VendEmail_BLL();

        public List<sp_VendEmail_DM> ListEmails()
        {
            return BLL.ListEmails();
        }

        /// <summary>
        /// ListEmails - There's a good chance the same record may be requested often.  Cache the Email object...
        /// 
        /// </summary>
        /// <param name="Emails"></param>
        /// <returns></returns>
        public sp_VendEmail_DM ListEmails(int VendEmail)
        {
            sp_VendEmail_DM caEmail = new sp_VendEmail_DM();

            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_VendEmail_DM cacheEmail;
            cacheEmail = (sp_VendEmail_DM)cache[VendEmail.ToString()];

            if (cacheEmail == null)
            {
                caEmail = BLL.ListEmails(VendEmail);
                cache.Insert(caEmail.EmailID.ToString(), caEmail, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            }
            else
            {
                caEmail = cacheEmail;
            }


            return caEmail;
        }

        public void InsertEmailContext(sp_VendEmail_DM _caEmail)
        {
            BLL.InsertEmailContext(_caEmail);
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Insert(_caEmail.EmailID.ToString(), _caEmail, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

        public void UpdateEmailContext(sp_VendEmail_DM _caEmail)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_VendEmail_DM cacheEmail;
            cacheEmail = (sp_VendEmail_DM)cache[_caEmail.EmailID.ToString()];

            if (cacheEmail != null)
            {
                cache.Remove(_caEmail.EmailID.ToString());
            }

            cache.Insert(_caEmail.EmailID.ToString(), _caEmail, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            BLL.UpdateEmailContext(_caEmail);
        }

        public void DeleteEmailContext(sp_VendEmail_DM _caEmail)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_VendEmail_DM cacheEmail;
            cacheEmail = (sp_VendEmail_DM)cache[_caEmail.EmailID.ToString()];

            if (cacheEmail != null)
            {
                cache.Remove(_caEmail.EmailID.ToString());
            }
            BLL.DeleteEmailContext(_caEmail);
        }
    }
}