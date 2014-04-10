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
    public class sp_VendContact_Cache
    {
        sp_VendContact_BLL BLL = new sp_VendContact_BLL();

        public List<sp_VendContact_DM> ListContacts()
        {
            return BLL.ListContacts();
        }

        /// <summary>
        /// ListContacts - There's a good chance the same record may be requested often.  Cache the contact object...
        /// 
        /// </summary>
        /// <param name="Contacts"></param>
        /// <returns></returns>
        public sp_VendContact_DM ListContacts(int? VendContact)
        {
            sp_VendContact_DM cRating = new sp_VendContact_DM();

            //Cache cache = HttpRuntime.Cache;
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_VendContact_DM cacheRating;
            cacheContact = (sp_VendContact_DM)cache[VendContact.ToString()];

            if (cacheContact == null)
            {
                caContact = BLL.ListContacts(VendContact);
                cache.Insert(caContact.ContactID.ToString(), caContact, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            }
            else
            {
                caContact = cacheContact;
            }


            return caContact;
        }

        public void InsertContactContext(sp_VendContact_DM _caContact)
        {
            BLL.InsertContactContext(_caContact);
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Insert(_caContact.ContactID.ToString(), _caContact, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

        public void UpdateContactContext(sp_VendContact_DM _caContact)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_VendContact_DM cacheContact;
            cacheContact = (sp_VendContact_DM)cache[_caContact.ContactID.ToString()];

            if (cacheContact != null)
            {
                cache.Remove(_caContact.ContactID.ToString());
            }

            cache.Insert(_caContact.ContactID.ToString(), _caContact, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            BLL.UpdateContactContext(_caContact);
        }

        public void DeleteContactContext(sp_VendContact_DM _caContact)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_VendContact_DM cacheContact;
            cacheContact = (sp_VendContact_DM)cache[_caContact.ContactID.ToString()];

            if (cacheContact != null)
            {
                cache.Remove(_caContact.ContactID.ToString());
            }
            BLL.DeleteContactContext(_caContact);
        }
    }
}