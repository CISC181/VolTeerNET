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
        sp_ProjectEvent_DM ListEvent(Guid EventID);

        Guid InsertProjectEventContext(sp_ProjectEvent_DM _cEvent);
        void UpdateProjectEventContext(sp_ProjectEvent_DM _cEvent);
        void DeleteProjectEventContext(sp_ProjectEvent_DM _cEvent);
    }
}
