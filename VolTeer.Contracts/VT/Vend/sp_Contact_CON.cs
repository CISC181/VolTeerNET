using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;

namespace VolTeer.Contracts.VT.Vend
{
    public interface sp_Contact_CON {
        List<sp_Contact_DM> ListContacts();
        List<sp_Contact_DM> ListContacts(Guid ContactID);
        void insert(sp_Contact_DM Contact);
        void update(sp_Contact_DM contact);
        void delete(Guid ContactID);
    }
}
