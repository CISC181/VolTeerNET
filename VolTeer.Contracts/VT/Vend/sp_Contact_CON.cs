using System;
using System.Collections.Generic;
using System.Linq;
using VolTeer.DomainModels.VT.Vend;

namespace VolTeer.Contracts.VT.Vend
{
    public interface sp_Contact_CON
    {
        List<sp_Contact_DM> ListContacts();
        sp_Contact_DM ListContacts(Guid? contactid);
        void InsertContactContext(ref sp_Contact_DM contact);
        void UpdateContactContext(sp_Contact_DM contact);
        void DeleteContactContext(Guid? contactid);
    }
}
