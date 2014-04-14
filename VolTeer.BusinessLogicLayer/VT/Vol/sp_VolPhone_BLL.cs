using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DataAccessLayer.VT.Vol;


namespace VolTeer.BusinessLogicLayer.VT.Vol
{
    public class sp_VolPhone_BLL
    {
        sp_VolPhone_DAL DAL = new sp_VolPhone_DAL();

        public List<sp_Phone_DM> ListPhones()
        {
            return DAL.ListPhones();
        }

        public sp_Phone_DM ListPhones(int PhoneIds)
        {
            return DAL.ListPhones(PhoneIds).Single();
        }

        public void InsertPhoneContext(sp_Phone_DM _cPhone)
        {
            DAL.InsertPhoneContext(_cPhone);
        }

        public void UpdatePhoneNbr(sp_Phone_DM _cPhone)
        {
            DAL.UpdatePhoneNbr(_cPhone);
        }

        public void DeletePhonesContext(sp_Phone_DM _cPhone)
        {
            DAL.DeletePhonesContext(_cPhone);
        }

    }
}
