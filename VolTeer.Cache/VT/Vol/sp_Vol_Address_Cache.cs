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
        sp_Vol_Address_BLL BLL = new sp_Vol_Address_BLL();

        //public List<sp_Vol_Address_DM> ListAddresses()
        //{
        //    return BLL.ListAddresses();
        //}

        /// <summary>
        /// ListAddress - There's a good chance the same record may be requested often.  Cache the address object...
        /// 
        /// </summary>
        /// <param name="Address"></param>
        /// <returns></returns>
        //public sp_Vol_Address_DM ListAddresses(int? Address)
        //{
        //    sp_Vol_Address_DM cAddress = new sp_Vol_Address_DM();

        //    //Cache cache = HttpRuntime.Cache;
        //    System.Web.Caching.Cache cache = HttpRuntime.Cache;

        //    sp_Vol_Address_DM cacheAddress;
        //    cacheAddress = (sp_Vol_Address_DM)cache[Address.ToString()];

        //    if (cacheAddress == null)
        //    {
        //        cAddress = BLL.ListAddresses(Address);
        //        cache.Insert(cAddress.AddrID.ToString(), cAddress, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        //    }
        //    else
        //    {
        //        cAddress = cacheAddress;
        //    }


        //    return cAddress;
        //}

        public void InsertAddressContext(sp_Vol_Address_DM _cAddress, ref sp_Vol_Addr_DM _cVolAddr)
        {
            BLL.InsertAddressContext(ref _cAddress, ref _cVolAddr);
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Insert(_cAddress.AddrID.ToString(), _cAddress, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

        public void UpdateAddressContext(sp_Vol_Address_DM _cAddress, sp_Vol_Addr_DM _cVolAddr)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_Vol_Address_DM cacheAddress;
            cacheAddress = (sp_Vol_Address_DM)cache[_cAddress.AddrID.ToString()];

            if (cacheAddress != null)
            {
                cache.Remove(_cAddress.AddrID.ToString());
            }

            cache.Insert(_cAddress.AddrID.ToString(), _cAddress, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            BLL.UpdateAddressContext(_cAddress, _cVolAddr);
        }

        public void DeleteAddressContext(sp_Vol_Address_DM _cAddress, sp_Vol_Addr_DM _cVolAddr)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_Vol_Address_DM cacheAddress;
            cacheAddress = (sp_Vol_Address_DM)cache[_cAddress.AddrID.ToString()];

            if (cacheAddress != null)
            {
                cache.Remove(_cAddress.AddrID.ToString());
            }
            BLL.DeleteAddressContext(_cAddress, _cVolAddr);
        }
    }
}
