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
    
    public partial class tblVendorProjContact
    {
        public System.Guid VendorID { get; set; }
        public System.Guid ProjectID { get; set; }
        public System.Guid ContactID { get; set; }
        public Nullable<bool> PrimaryContact { get; set; }
    
        public virtual tblContact tblContact { get; set; }
        public virtual tblProject tblProject { get; set; }
        public virtual tblVendor tblVendor { get; set; }
    }
}