using System;
using System.Collections.Generic;

namespace VolTeer.DomainModels.VT.Vend
{
    public partial class sp_EventRating_DM
    {
        public int RatingID { get; set; }
        public Nullable<System.Guid> EventID { get; set; }
        public Nullable<System.Guid> VolID { get; set; }
        public Nullable<int> RatingValue { get; set; }
        public bool ActiveFlg { get; set; }

        public virtual sp_ProjectEvent_DM sp_ProjectEvent_DM { get; set; }
    }
}
