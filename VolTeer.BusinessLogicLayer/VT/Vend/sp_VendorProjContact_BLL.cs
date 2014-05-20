using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.DataAccessLayer.VT.Vend;
using VolTeer.Contracts.VT.Vend;

namespace VolTeer.BusinessLogicLayer.VT.Vend
{
    public class sp_VendorProjContact_BLL : sp_VendorProjContact_CON
    {
        sp_VendorProjContact_DAL DAL = new sp_VendorProjContact_DAL();

        public List<sp_VendorProjContact_DM> ListContact()
        {
            return DAL.ListContact();
        }


        public List<sp_VendorProjContact_DM> ListContact(Guid VendorID)
        {
            return DAL.ListContact(VendorID);
        }

        public sp_VendorProjContact_DM ListContact(Guid VendorID, Guid ProjectID, Guid ContactID)
        {
            return DAL.ListContact(VendorID, ProjectID, ContactID);
        }

        public Guid InsertContactContext(sp_VendorProjContact_DM InputContact)
        {
            return DAL.InsertContactContext(InputContact);
        }

        public void UpdateContactContext(sp_VendorProjContact_DM InputContact)
        {
            DAL.UpdateContactContext(InputContact);
        }

        public void DeleteContactContext(sp_VendorProjContact_DM InputContact)
        {
            DAL.DeleteContactContext(InputContact);
        }
    }
}
