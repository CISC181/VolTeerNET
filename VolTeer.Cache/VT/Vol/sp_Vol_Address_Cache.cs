using System;
using System.Linq;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;



namespace VolTeer.Cache.VT.Vol
{
    public class sp_Vol_Address_Cache
    {
        enum RecordType
        {
            Volunteer ,
            Group,
            Contact,
            VolAddr,
            VolAddrs
        }

        sp_Vol_Address_BLL BLL = new sp_Vol_Address_BLL();

        System.Web.Caching.CacheItemRemovedCallback callback = new System.Web.Caching.CacheItemRemovedCallback(OnRemove);

        /// <summary>
        /// ListAddresses - Get a list of addresses from BLL and add to cache.
        /// </summary>
        /// <param name="cVolAddr"></param>
        /// <returns></returns>
        public List<sp_Vol_Address_DM> ListAddresses(sp_Vol_Address_DM cVolAddr)
        {
            List<sp_Vol_Address_DM> cAddress = new List<sp_Vol_Address_DM>();

            //Cache cache = HttpRuntime.Cache;
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            List<sp_Vol_Address_DM> cacheAddress;
            cacheAddress = (List<sp_Vol_Address_DM>)cache[RecordType.VolAddrs + cVolAddr.VolID.ToString()];

            if (cacheAddress == null)
            {
                cAddress = BLL.ListAddresses(cVolAddr);
                cache.Insert(RecordType.VolAddrs + "|" + cVolAddr.VolID.ToString(), cAddress, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
            }
            else
            {
                cAddress = cacheAddress;
            }
            return cAddress;
        }

        /// <summary>
        /// ListPrimaryAddress - Check to see if the Primary Address record is in cache.. if it's not, get it and place into cache.
        /// </summary>
        /// <param name="cVolAddr"></param>
        /// <returns></returns>
        public sp_Vol_Address_DM ListPrimaryAddress(sp_Vol_Address_DM cVolAddr)
        {
            sp_Vol_Address_DM cAddress = new sp_Vol_Address_DM();

            //Cache cache = HttpRuntime.Cache;
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_Vol_Address_DM cacheAddress;
            cacheAddress = (sp_Vol_Address_DM)cache[RecordType.VolAddr + cVolAddr.VolID.ToString()];

            if (cacheAddress == null)
            {
                cAddress = BLL.ListPrimaryAddress(cVolAddr);
                cache.Insert(RecordType.VolAddr + "|" + cVolAddr.VolID.ToString() + "|" + cAddress.AddrID.ToString(), cAddress, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
            }
            else
            {
                cAddress = cacheAddress;
            }
            return cAddress;
        }

        /// <summary>
        /// InsertAddressContext - Insert a new address into cache, then call BLL to add to database.
        /// </summary>
        /// <param name="_cAddress"></param>
        /// <param name="_cVolAddr"></param>
        public void InsertAddressContext(sp_Vol_Address_DM _cAddress, ref sp_Vol_Addr_DM _cVolAddr)
        {
            BLL.InsertAddressContext(ref _cAddress, ref _cVolAddr);
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Insert(RecordType.VolAddr + "|" + _cVolAddr.VolID.ToString() + "|" + _cAddress.AddrID.ToString(), _cAddress, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
        }

        /// <summary>
        /// UpdateAddressContext - Record is updated, remove from cache, add back to cache, and then call BLL to update database.
        /// </summary>
        /// <param name="_cAddress"></param>
        /// <param name="_cVolAddr"></param>
        public void UpdateAddressContext(sp_Vol_Address_DM _cAddress, sp_Vol_Addr_DM _cVolAddr)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_Vol_Address_DM cacheAddress;
            cacheAddress = (sp_Vol_Address_DM)cache[_cAddress.AddrID.ToString()];

            if (cacheAddress != null)
            {
                cache.Remove(RecordType.VolAddr + "|" + _cVolAddr.VolID.ToString() + "|" + _cAddress.AddrID.ToString());
            }

            cache.Insert(RecordType.VolAddr + _cVolAddr.VolID.ToString() + _cAddress.AddrID.ToString(), _cAddress, null, DateTime.Now.AddSeconds(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, callback);
            BLL.UpdateAddressContext(_cAddress, _cVolAddr);
        }

        /// <summary>
        /// DeleteAddressContext - Remove from cache and call delete method in BLL.
        /// </summary>
        /// <param name="_cAddress"></param>
        /// <param name="_cVolAddr"></param>
        public void DeleteAddressContext(sp_Vol_Address_DM _cAddress, sp_Vol_Addr_DM _cVolAddr)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_Vol_Address_DM cacheAddress;
            cacheAddress = (sp_Vol_Address_DM)cache[RecordType.VolAddr + _cVolAddr.VolID.ToString() + _cAddress.AddrID.ToString()];

            if (cacheAddress != null)
            {
                cache.Remove(RecordType.VolAddr + "|" + _cVolAddr.VolID.ToString() + "|" + _cAddress.AddrID.ToString());
            }
            BLL.DeleteAddressContext(_cAddress, _cVolAddr);
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
