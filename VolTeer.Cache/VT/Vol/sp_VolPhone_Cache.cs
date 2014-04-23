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
    public class sp_VolPhone_Cache
    {
        enum RecordType
        {
            VolPhoneList,
            VolPhoneDM,
            VolPhoneGUID,
            VolPhonePrimary,
            VolPhone
        }
        sp_VolPhone_BLL BLL = new sp_VolPhone_BLL();
        System.Web.Caching.CacheItemRemovedCallback callback = new System.Web.Caching.CacheItemRemovedCallback(OnRemove);

        public List<sp_Phone_DM> ListPhones(sp_Phone_DM cPhone)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            List<sp_Phone_DM> cachePhones = (List<sp_Phone_DM>)cache["" + RecordType.VolPhoneList];
            if (cachePhones == null)
            {
                cachePhones = BLL.ListPhones(cPhone);
                cache.Insert(RecordType.VolPhoneList + "|" + cPhone.VolID.ToString(), cPhone, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
            }
            return cachePhones;
        }

<<<<<<< HEAD
=======
        /*
        public sp_Email_DM ListEmails(Guid? Volunteer)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            sp_Email_DM cacheEmails = (sp_Email_DM)cache[EmailType.VolEmailGUID + "|" + Volunteer];

            if (cacheEmails == null)
            {
                cacheEmails = BLL.ListEmails(Volunteer);
                cache.Insert("" + EmailType.VolEmailGUID + "|" + Volunteer, cacheEmails, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
            }
            return cacheEmails;
        }
         */
        /*
        public sp_Phone_DM ListPhone(sp_Phone_DM cPhone)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            sp_Phone_DM cacheEmails = (sp_Phone_DM)cache[EmailType.VolEmailDM + "|" + EmailIds];

            if (cacheEmails == null)
            {
                cacheEmails = BLL.ListEmails(EmailIds);
                cache.Insert("" + EmailType.VolEmailDM + "|" + EmailIds, cacheEmails, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
            }
            return cacheEmails;
        }
        */
>>>>>>> a09d8748a32add4edb9b63f0291d50d87afa34a9
        public sp_Phone_DM ListPrimaryPhone(sp_Phone_DM cPhone)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            sp_Phone_DM cachePhones = (sp_Phone_DM)cache[RecordType.VolPhonePrimary + "|" + cPhone.PhoneID];

            if (cachePhones == null) 
            {
                cachePhones = BLL.ListPrimaryPhones(cPhone);
                cache.Insert("" + RecordType.VolPhonePrimary + "|" + cPhone.VolID.ToString(), cPhone, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
            }
            return cachePhones;
        }

        public void InsertEmailContext(sp_Phone_DM cPhone)
        {
            BLL.InsertPhonesContext(cPhone);
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Insert(RecordType.VolPhone + "|" + cPhone.VolID, cPhone, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
        }

        public void UpdatePhoneNbr(sp_Phone_DM cPhone)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            sp_Phone_DM cachePhones = (sp_Phone_DM)cache[RecordType.VolPhone + "|" + cPhone.VolID];
            if (cachePhones != null)
            {
                cache.Remove(RecordType.VolPhone + "|" + cPhone.VolID);
            }
            cache.Insert(RecordType.VolPhone + "|" + cPhone.VolID, cPhone, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
            BLL.UpdatePhoneNbr(cPhone);
        }

        public void DeletePhonesContext(sp_Phone_DM cPhone)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            sp_Phone_DM cachePhones = (sp_Phone_DM)cache[RecordType.VolPhone + "|" + cPhone.VolID];
            if (cachePhones != null)
            {
                cache.Remove(RecordType.VolPhone + "|" + cPhone.VolID);
            }
            BLL.DeletePhonesContext(cPhone);
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

