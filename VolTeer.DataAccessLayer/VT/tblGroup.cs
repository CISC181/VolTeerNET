//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VolTeer.DataAccessLayer.VT
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblGroup
    {
        public tblGroup()
        {
            this.tblGroupVols = new HashSet<tblGroupVol>();
            this.tblVolAddresses = new HashSet<tblVolAddress>();
        }
    
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public Nullable<int> ParticipationLevelID { get; set; }
        public Nullable<bool> ActiveFlg { get; set; }
    
        public virtual ICollection<tblGroupVol> tblGroupVols { get; set; }
        public virtual ICollection<tblVolAddress> tblVolAddresses { get; set; }
    }
}
