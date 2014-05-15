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
        sp_ProjectEvent_DAL DAL = new sp_ProjectEvent_DAL();
        public List<sp_ProjectEvent_DM> ListEvents()
        {
            return DAL.ListEvents();
        }

        public sp_ProjectEvent_DM ListEvent(Guid EventID)
        {
            return DAL.ListEvent(EventID);
        }

        public Guid InsertProjectEventContext(sp_ProjectEvent_DM InputProjectEvent)
        {
            return DAL.InsertProjectEventContext(InputProjectEvent);
        }

        public void UpdateProjectEventContext(sp_ProjectEvent_DM InputProjectEvent)
        {
            DAL.UpdateProjectEventContext(InputProjectEvent);
        }

        public void DeleteProjectEventContext(sp_ProjectEvent_DM InputProjectEvent)
        {
            DAL.DeleteProjectEventContext(InputProjectEvent);
        }
    }
}
