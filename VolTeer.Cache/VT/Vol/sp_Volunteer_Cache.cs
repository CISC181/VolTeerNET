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

        public void InsertVolunteerContext(sp_Volunteer_DM _cVolunteer)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Insert(_cVolunteer.VolID.ToString(), _cVolunteer, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            BLL.InsertVolunteerContext(_cVolunteer);
        }

        public void UpdateVolunteerContext(sp_Volunteer_DM _cVolunteer)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_Volunteer_DM cacheVol;
            cacheVol = (sp_Volunteer_DM)cache[_cVolunteer.VolID.ToString()];

            if (cacheVol != null)
            {
                cache.Remove(_cVolunteer.VolID.ToString());
            }

            cache.Insert(_cVolunteer.VolID.ToString(), _cVolunteer, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            BLL.UpdateVolunteerContext(_cVolunteer);
        }

        public void DeleteVolunteerContext(sp_Volunteer_DM _cVolunteer)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_Volunteer_DM cacheVol;
            cacheVol = (sp_Volunteer_DM)cache[_cVolunteer.VolID.ToString()];

            if (cacheVol != null)
            {
                cache.Remove(_cVolunteer.VolID.ToString());
            }
            BLL.DeleteVolunteerContext(_cVolunteer);
        }
    }
}
