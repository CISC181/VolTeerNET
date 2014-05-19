using System;
using System.Collections.Generic;
using System.Linq;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.DataAccessLayer.VT.Vend;
using VolTeer.Contracts.VT.Vend;

namespace VolTeer.BusinessLogicLayer.VT.Vend
{
    public class sp_Contact_BLL : sp_Contact_CON
    {
        sp_Contact_DAL dal = new sp_Contact_DAL();

        public List<sp_Contact_DM> ListContacts()
        {
            return dal.ListContacts();
        }

        public sp_Contact_DM ListContacts(Guid contactid)
        {
            return dal.ListContacts(contactid);
        }

        public void InsertContactContext(ref sp_Contact_DM contact)
        {
            dal.InsertContactContext(ref contact);
        }

        public void UpdateContactContext(sp_Contact_DM contact)
        {
            dal.UpdateContactContext(contact);
        }

        public void DeleteContactContext(Guid contactid)
        {
            dal.DeleteContactContext(contactid);
        }
    }
}
