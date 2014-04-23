using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;

using System.Web;
using System.Web.Caching;

namespace VolTeer.Cache.VT.Vol
{
    public class sp_VolEmail_Cache
    {
        enum EmailType
        {
            VolEmailList,
            VolEmailDM,
            VolEmailGUID,
            VolEmailPrimary,
            VolEmail
        }
        sp_VolEmail_BLL BLL = new sp_VolEmail_BLL();
        System.Web.Caching.CacheItemRemovedCallback callback = new System.Web.Caching.CacheItemRemovedCallback(OnRemove);

        public List<sp_Email_DM> ListEmails(sp_Email_DM cVolEmail)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            List<sp_Email_DM> cacheEmails = (List<sp_Email_DM>)cache["" + EmailType.VolEmailList];
            if (cacheEmails == null)
            {
                cacheEmails = BLL.ListEmails(cVolEmail);
                cache.Insert("" + EmailType.VolEmailList, cacheEmails, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
            }
            return cacheEmails;                       
        }

        public sp_Email_DM ListPrimaryEmail(sp_Email_DM cVolEmail)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            sp_Email_DM cacheEmails = (sp_Email_DM)cache[EmailType.VolEmailPrimary + "|" + cVolEmail.EmailID];

            if (cacheEmails == null)
            {
                cacheEmails = BLL.ListPrimaryEmail(cVolEmail);
                cache.Insert("" + EmailType.VolEmailPrimary + "|" + cVolEmail.EmailID, cacheEmails, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
            }
            return cacheEmails;
        }

        public void InsertEmailContext(sp_Email_DM _cEmail)
        {
            BLL.InsertEmailContext(_cEmail);
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Insert(EmailType.VolEmail + "|" + _cEmail.VolID, _cEmail, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
        }

        public void UpdateEmailAddr(sp_Email_DM _cEmail)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            sp_Email_DM cacheEmails = (sp_Email_DM)cache[EmailType.VolEmail + "|" + _cEmail.VolID];
            if (cacheEmails != null)
            {
                cache.Remove(EmailType.VolEmail + "|" + _cEmail.VolID);
            }
            cache.Insert(EmailType.VolEmail + "|" + _cEmail.VolID, _cEmail, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
            BLL.UpdateEmailAddr(_cEmail);
        }

        public void DeleteEmailsContext(sp_Email_DM _cEmail)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            sp_Email_DM cacheEmails = (sp_Email_DM)cache[EmailType.VolEmail + "|" + _cEmail.VolID];
            if(cacheEmails != null)
            {
                cache.Remove(EmailType.VolEmail + "|" + _cEmail.VolID);
            }
            BLL.DeleteEmailsContext(_cEmail);
        }

        public static void OnRemove(string key, object cacheItem, System.Web.Caching.CacheItemRemovedReason reason)
        {
            if (reason == CacheItemRemovedReason.Expired)
            {
                //  Item Expired...  Let's deal with it!
                string[] CacheKey = key.Split(new Char[] { '|' });
            }

            //AppendLog("The cached value with key '" + key +
            //      "' was removed from the cache.  Reason: " +
            //      reason.ToString());
        }

    }
}
