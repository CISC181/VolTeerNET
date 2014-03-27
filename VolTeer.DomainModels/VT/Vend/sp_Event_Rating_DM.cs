using System;
using System.Collections.Generic;

namespace VolTeer.DomainModels.VT.Vend
{
    public partial class sp_Event_Rating_DM
    {
        public int RatingID { get; set; }
        public Nullable<System.Guid> EventID { get; set; }
        public Nullable<System.Guid> VolID { get; set; }
        public Nullable<int> RatingValue { get; set; }
        public bool ActiveFlg { get; set; }

        public virtual sp_Project_Event_DM sp_Project_Event_DM { get; set; }
    }
}
