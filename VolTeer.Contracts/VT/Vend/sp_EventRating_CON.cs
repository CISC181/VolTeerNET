using System;
using System.Collections.Generic;
using System.Linq;
using VolTeer.DomainModels.VT.Vend;


namespace VolTeer.Contracts.VT.Vend
{
    public interface sp_EventRating_CON
    {
        List<sp_EventRating_DM> ListEventRatings();

        sp_EventRating_DM InsertEventRatingContext(sp_EventRating_DM InputRating);
        void UpdateEventRatingContext(sp_EventRating_DM InputRating);
        void DeleteEventRatingContext(sp_EventRating_DM InputRating);
    }
}
