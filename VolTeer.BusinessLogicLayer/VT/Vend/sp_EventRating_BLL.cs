using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.DataAccessLayer.VT.Vend;


namespace VolTeer.BusinessLogicLayer.VT.Vend
{
    public class sp_EventRating_BLL
    {
        sp_EventRating_DAL DAL = new sp_EventRating_DAL();
        
        public List<sp_EventRating_DM> ListEventRatings()
        {
            return DAL.ListEventRatings();
        }

        public sp_EventRating_DM ListEventRatings(int? EventRating)
        {
            return DAL.ListEventRatings(EventRating).Single();
        }

        public void InsertEventRatingContext(sp_EventRating_DM _cEventRating)
        {
            DAL.InsertEventRatingContext(_cEventRating);
        }

        public void UpdateEventRatingContext(sp_EventRating_DM _cEventRating)
        {
            DAL.UpdateEventRatingContext(_cEventRating);
        }

        public void DeleteEventRatingContext(sp_EventRating_DM _cEventRating)
        {
            DAL.DeleteEventRatingContext(_cEventRating);
        }

    }
}
