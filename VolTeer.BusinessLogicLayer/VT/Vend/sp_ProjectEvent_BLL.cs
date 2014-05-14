using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.Contracts.VT.Vend;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.DataAccessLayer.VT.Vend;

namespace VolTeer.BusinessLogicLayer.VT.Vend
{
    public class sp_ProjectEvent_BLL : sp_ProjectEvent_CON
    {
        sp_ProjectEvent_DAL dal = new sp_ProjectEvent_DAL();
        public List<sp_ProjectEvent_DM> ListEvents()
        {
            throw new NotImplementedException();
        }

        public sp_ProjectEvent_DM ListEvents(Guid? EventID)
        {
            throw new NotImplementedException();
        }

        public sp_ProjectEvent_DM InsertEventContext(ref sp_ProjectEvent_DM _cEvent)
        {
            throw new NotImplementedException();
        }

        public void UpdateEventContext(sp_ProjectEvent_DM _cEvent)
        {
            throw new NotImplementedException();
        }

        public void DeleteEventContext(sp_ProjectEvent_DM _cEvent)
        {
            throw new NotImplementedException();
        }
    }
}
