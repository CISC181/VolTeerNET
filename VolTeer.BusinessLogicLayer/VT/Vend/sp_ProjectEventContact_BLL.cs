using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.Contracts.VT.Vend;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.DataAccessLayer.VT.Vend;

namespace VolTeer.BusinessLogicLayer.VT.Vend 
{
    public class sp_ProjectEventContact_BLL : sp_ProjectEventContact_CON
    {
        sp_ProjectEventContact_DAL dal = new sp_ProjectEventContact_DAL();

        public List<DomainModels.VT.Vend.sp_ProjectEventContact_DM> ListEventsContacts(Guid? EventID, Guid? ContactID)
        {
            return dal.ListEventsContacts(EventID, ContactID);
        }

        public List<DomainModels.VT.Vend.sp_ProjectEventContact_DM> ListEventsContacts()
        {
            return dal.ListEventsContacts();
        }

        public Guid InsertProjectEventContactContext(DomainModels.VT.Vend.sp_ProjectEventContact_DM InputProjectEventContact)
        {
            return dal.InsertProjectEventContactContext(InputProjectEventContact);
        }

        public void UpdateProjectEventContactContext(DomainModels.VT.Vend.sp_ProjectEventContact_DM InputProjectEventContact)
        {
            dal.UpdateProjectEventContactContext(InputProjectEventContact);
        }

        public void DeleteProjectEventContactContext(DomainModels.VT.Vend.sp_ProjectEventContact_DM InputProjectEventContact)
        {
            dal.DeleteProjectEventContactContext(InputProjectEventContact);
        }
    }
}
