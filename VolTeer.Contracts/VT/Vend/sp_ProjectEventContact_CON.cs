using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;

namespace VolTeer.Contracts.VT.Vend
{
    public interface sp_ProjectEventContact_CON
    {
        List<sp_ProjectEventContact_DM> ListEventsContacts(Guid? EventID, Guid? ContactID);
        List<sp_ProjectEventContact_DM> ListEventsContacts();
        Guid InsertProjectEventContactContext(sp_ProjectEventContact_DM InputProjectEventContact);
        void UpdateProjectEventContactContext(sp_ProjectEventContact_DM InputProjectEventContact);
        void DeleteProjectEventContactContext(sp_ProjectEventContact_DM InputProjectEventContact);
    }
}
