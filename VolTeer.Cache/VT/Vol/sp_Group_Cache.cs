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
    class sp_Group_Cache
    {
        sp_Group_BLL BLL = new sp_Group_BLL();

        public List<sp_Group_DM> ListGroups()
        {
            return BLL.ListGroups();
        }

        /// <summary>
        /// ListGroups - There's a good chance the same record may be requested often.  Cache the vol object...
        /// 
        /// </summary>
        /// <param name="Group"></param>
        /// <returns></returns>
        public sp_Group_DM ListGroups(int IGroupID)
        {
            sp_Group_DM cGroup = new sp_Group_DM();

            //Cache cache = HttpRuntime.Cache;
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_Group_DM cacheGroup;
            cacheGroup = (sp_Group_DM)cache[IGroupID.ToString()];

            if (cacheGroup == null)
            {
                cGroup = BLL.ListGroups(IGroupID);
                cache.Insert(cGroup.GroupID.ToString(), cGroup, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            }
            else
            {  
                cGroup = cacheGroup;
            }


            return cGroup;
        }

        public sp_Group_DM InsertGroupContext(sp_Group_DM _cGroup)
        {
            BLL.InsertGroupContext(ref _cGroup);
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Insert(_cGroup.GroupID.ToString(), _cGroup, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);

            return _cGroup;
        }

        public void UpdateGroupContext(sp_Group_DM _cGroup)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_Group_DM cacheVol;
            cacheVol = (sp_Group_DM)cache[_cGroup.GroupID.ToString()];

            if (cacheVol != null)
            {
                cache.Remove(_cGroup.GroupID.ToString());
            }

            cache.Insert(_cGroup.GroupID.ToString(), _cGroup, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            BLL.UpdateGroupContext(_cGroup);
        }

        public void DeleteGroupContext(sp_Group_DM _cGroup)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_Group_DM cacheVol;
            cacheVol = (sp_Group_DM)cache[_cGroup.GroupID.ToString()];

            if (cacheVol != null)
            {
                cache.Remove(_cGroup.GroupID.ToString());
            }
            BLL.DeleteGroupContext(_cGroup);
        }
    }
}
