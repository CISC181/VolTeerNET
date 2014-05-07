using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;
using VolTeer.Contracts.VT.Vol;

using System.Web;
using System.Web.Caching;

namespace VolTeer.Cache.VT.Vol
{
    public class sp_GroupAddr_Cache
    {   

        sp_GroupAddr_BLL BLL = new sp_GroupAddr_BLL();
        System.Web.Caching.CacheItemRemovedCallback callback = new System.Web.Caching.CacheItemRemovedCallback(OnRemove);

        public List<sp_GroupAddr_DM> ListAddresses(sp_GroupAddr_DM cGroupAddr)
        {
            List<sp_GroupAddr_DM> cAddress = new List<sp_GroupAddr_DM>();

            //Cache cache = HttpRuntime.Cache;
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            List<sp_GroupAddr_DM> cacheAddress;
            cacheAddress = (List<sp_GroupAddr_DM>)cache[cGroupAddr.GroupID.ToString()];

            if (cacheAddress == null)
            {
                cAddress = BLL.ListAddresses(cGroupAddr);
                cache.Insert(cGroupAddr.GroupID.ToString(), cAddress, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
            }
            else
            {
                cAddress = cacheAddress;
            }
            return cAddress;
        }

        public List<sp_GroupAddr_DM> ListAddresses(int? GroupID, int? Address)
        {
            List<sp_GroupAddr_DM> cAddress = new List<sp_GroupAddr_DM>();

            //Cache cache = HttpRuntime.Cache;
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            List<sp_GroupAddr_DM> cacheAddress;
            cacheAddress = (List<sp_GroupAddr_DM>)cache[GroupID.ToString() + "|" + Address.ToString()];

            if (cacheAddress == null)
            {
                cAddress = BLL.ListAddresses(GroupID, Address);
                cache.Insert(GroupID.ToString() + "|" + Address.ToString(), cAddress, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
            }
            else
            {
                cAddress = cacheAddress;
            }
            return cAddress;
        }

        public sp_GroupAddr_DM ListPrimaryAddress(sp_GroupAddr_DM cGroupAddr)
        {
            sp_GroupAddr_DM cAddress = new sp_GroupAddr_DM();

            //Cache cache = HttpRuntime.Cache;
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_GroupAddr_DM cacheAddress;
            cacheAddress = (sp_GroupAddr_DM)cache[cGroupAddr.GroupID.ToString()];

            if (cacheAddress == null)
            {
                cAddress = BLL.ListPrimaryAddress(cGroupAddr);
                cache.Insert(cGroupAddr.GroupID.ToString() + "|" + cAddress.AddrID.ToString(), cAddress, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
            }
            else
            {
                cAddress = cacheAddress;
            }
            return cAddress;
        }

        public void InsertAddressContext(ref sp_Vol_Address_DM _cAddress, ref sp_GroupAddr_DM _cGroupAddr)
        {
            BLL.InsertAddressContext(ref _cAddress, ref _cGroupAddr);
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Insert(_cGroupAddr.GroupID.ToString() + "|" + _cAddress.AddrID.ToString(), _cAddress, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
        }

        public void UpdateAddressContext(sp_Vol_Address_DM _cAddress, sp_GroupAddr_DM _cGroupAddr)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_GroupAddr_DM cacheAddress;
            cacheAddress = (sp_GroupAddr_DM)cache[_cAddress.AddrID.ToString()];

            if (cacheAddress != null)
            {
                cache.Remove(_cGroupAddr.GroupID.ToString() + "|" + _cAddress.AddrID.ToString());
            }

            cache.Insert(_cGroupAddr.GroupID.ToString() + _cAddress.AddrID.ToString(), _cAddress, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
            BLL.UpdateAddressContext(_cAddress, _cGroupAddr);
        }

        public void DeleteAddressContext(sp_Vol_Address_DM _cAddress, sp_GroupAddr_DM _cGroupAddr)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_GroupAddr_DM cacheAddress;
            cacheAddress = (sp_GroupAddr_DM)cache[_cGroupAddr.GroupID.ToString() + _cAddress.AddrID.ToString()];

            if (cacheAddress != null)
            {
                cache.Remove(_cGroupAddr.GroupID.ToString() + "|" + _cAddress.AddrID.ToString());
            }
            BLL.DeleteAddressContext(_cAddress, _cGroupAddr);
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
