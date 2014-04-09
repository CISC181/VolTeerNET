using System;
using System.Linq;

using VolTeer.DomainModels.VT.Vend;
using VolTeer.BusinessLogicLayer.VT.Vend;
using System.Collections.Generic;

using System.Web;
using System.Web.Caching;


namespace VolTeer.Cache.VT.Vend
{
    public class sp_EventRating_Cache
    {
        sp_EventRating_BLL BLL = new sp_EventRating_BLL();

        public List<sp_EventRating_DM> ListEventRatings()
        {
            return BLL.ListEventRatings();
        }

        /// <summary>
        /// ListEventRatings - There's a good chance the same record may be requested often.  Cache the event rating object...
        /// 
        /// </summary>
        /// <param name="EventRating"></param>
        /// <returns></returns>
        public sp_EventRating_DM ListEventRatings(int? EventRating)
        {
            sp_EventRating_DM cRating = new sp_EventRating_DM();

            //Cache cache = HttpRuntime.Cache;
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_EventRating_DM cacheRating;
            cacheRating = (sp_EventRating_DM)cache[EventRating.ToString()];

            if (cacheRating == null)
            {
                cRating = BLL.ListEventRatings(EventRating);
                cache.Insert(cRating.RatingID.ToString(), cRating, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            }
            else
            {
                cRating = cacheRating;
            }


            return cRating;
        }

        public void InsertEventRatingContext(sp_EventRating_DM _cRating)
        {
            BLL.InsertEventRatingContext(_cRating);
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            cache.Insert(_cRating.RatingID.ToString(), _cRating, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

        public void UpdateEventRatingContext(sp_EventRating_DM _cRating)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_EventRating_DM cacheRating;
            cacheRating = (sp_EventRating_DM)cache[_cRating.RatingID.ToString()];

            if (cacheRating != null)
            {
                cache.Remove(_cRating.RatingID.ToString());
            }

            cache.Insert(_cRating.RatingID.ToString(), _cRating, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            BLL.UpdateEventRatingContext(_cRating);
        }

        public void DeleteEventRatingContext(sp_EventRating_DM _cRating)
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;

            sp_EventRating_DM cacheRating;
            cacheRating = (sp_EventRating_DM)cache[_cRating.RatingID.ToString()];

            if (cacheRating != null)
            {
                cache.Remove(_cRating.RatingID.ToString());
            }
            BLL.DeleteEventRatingContext(_cRating);
        }
    }
}
