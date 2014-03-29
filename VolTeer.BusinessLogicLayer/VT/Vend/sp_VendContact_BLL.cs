using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.DataAccessLayer.VT.Vend;


namespace VolTeer.BusinessLogicLayer.VT.Vend
{
    public class sp_VendContact_BLL
    {
        sp_VendContact_DAL DAL = new sp_VendContact_DAL();

        public List<sp_VendContact_DM> ListContacts()
        {
            return DAL.ListContacts();
        }

        public sp_VendContact_DM ListContacts(Guid? VendContact)
        {
            return DAL.ListContacts(VendContact).Single();
        }

        public void InsertContactContext(sp_VendContact_DM _cVendContact)
        {
            DAL.InsertContactContext(_cVendContact);
        }

        public void UpdateContactContext(sp_VendContact_DM _cVendContact)
        {
            DAL.UpdateContactContext(_cVendContact);
        }

        public void DeleteContactContext(sp_VendContact_DM _cVendContact)
        {
            DAL.DeleteContactContext(_cVendContact);
        }

    }
}
