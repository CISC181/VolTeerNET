using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.DataAccessLayer.VT.Vend;
using VolTeer.Contracts.VT.Vend;

namespace VolTeer.BusinessLogicLayer.VT.Vend
{
    public class sp_Contact_BLL
    {
        sp_Contact_DAL dal = new sp_Contact_DAL();

        public List<sp_Contact_DM> ListContacts()
        {
            return dal.ListContacts();
        }

        public List<sp_Contact_DM> listContacts(Guid? contactid)
        {
            return dal.ListContacts(contactid);
        }

        public void InsertContactContext(sp_Contact_DM contact)
        {
            dal.insert(contact);
        }

        public void UpdateContactContext(sp_Contact_DM contact)
        {
            dal.update(contact);
        }

        public void DeleteContactContext(Guid? contactid)
        {
            dal.delete(contactid);
        }
    }
}
