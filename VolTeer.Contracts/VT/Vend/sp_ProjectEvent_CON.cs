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
        sp_ProjectEvent_DM ListEvents(Guid? EventID);
        sp_ProjectEvent_DM InsertEventContext(ref sp_ProjectEvent_DM _cEvent);
        void UpdateEventContext(sp_ProjectEvent_DM _cEvent);
        void DeleteEventContext(sp_ProjectEvent_DM _cEvent);
    }
}
