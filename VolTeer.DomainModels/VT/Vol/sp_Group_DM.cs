using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VolTeer.DomainModels.VT.Vol
{

    public partial class sp_Group_DM
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public Nullable<int> ParticipationLevelID { get; set; }
        public Nullable<bool> ActiveFlg { get; set; }
    }
}
