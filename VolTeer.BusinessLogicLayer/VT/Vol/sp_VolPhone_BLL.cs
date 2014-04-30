using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DataAccessLayer.VT.Vol;
using VolTeer.Contracts.VT.Vol;


namespace VolTeer.BusinessLogicLayer.VT.Vol
{
    public class sp_VolPhone_BLL : sp_VolPhone_CON
    {
        sp_VolPhone_DAL DAL = new sp_VolPhone_DAL();

        public List<sp_Phone_DM> ListPhones(sp_Phone_DM cVolPhone)
        {
            return DAL.ListPhones(cVolPhone);
        }

        public sp_Phone_DM ListPrimaryPhone(sp_Phone_DM cVolPhone)
        {
            return DAL.ListPrimaryPhone(cVolPhone);
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
