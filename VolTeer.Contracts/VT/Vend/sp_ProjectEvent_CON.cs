using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;


namespace VolTeer.Contracts.VT.Vend
{
    public interface sp_ProjectEvent_CON
    {
        List<sp_ProjectEvent_DM> ListEvents();
        sp_ProjectEvent_DM ListEvents(Guid? VendorID);
        sp_ProjectEvent_DM InsertVendorContext(ref sp_ProjectEvent_DM _cVendor);
        void UpdateVolunteerContext(sp_ProjectEvent_DM _cVendor);
        void DeleteVendorContext(sp_ProjectEvent_DM _cVendor);
    }
}
