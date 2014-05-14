using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;

namespace VolTeer.Contracts.VT.Vend
{
    public interface sp_VendorProjContact_CON
    {
        List<sp_VendorProjContact_DM> ListContact(Guid VendorID, Guid ProjectID, Guid ContactID);
        List<sp_VendorProjContact_DM> ListContact();
        Guid InsertContactContext(sp_VendorProjContact_DM InputContact);
        void UpdateContactContext(sp_VendorProjContact_DM InputContact);
        void DeleteContactContext(sp_VendorProjContact_DM InputContact);
    }
}
