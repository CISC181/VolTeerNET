using System;
using System.Linq;

using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;
using System.Collections.Generic;

using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;
using System.Web;
using System.Web.Caching;




namespace VolTeer.Cache.VT.Vol
{
    public class sp_Volunteer_Cache
    {
        sp_Volunteer_BLL BLL = new sp_Volunteer_BLL();

        public List<sp_Volunteer_DM> ListVolunteers()
        {
            return BLL.ListVolunteers();
        }

        /// <summary>
        /// ListVolunteers - There's a good chance the same record may be requested often.  Cache the vol object...
        /// 
        /// </summary>
        /// <param name="Volunteer"></param>
        /// <returns></returns>
        public sp_Volunteer_DM ListVolunteers(Guid? Volunteer)
        {
            sp_Volunteer_DM cVol = new sp_Volunteer_DM();

            //Cache cache = HttpRuntime.Cache;
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_Volunteer_DM cacheVol;
            cacheVol = (sp_Volunteer_DM)cache[Volunteer.ToString()];

            if (cacheVol == null)
            {
                cVol = BLL.ListVolunteers(Volunteer);
                cache.Insert(cVol.VolID.ToString(), cVol, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            }
            else
            {
                cVol = cacheVol;
            }


            return cVol;
        }
    }
}
