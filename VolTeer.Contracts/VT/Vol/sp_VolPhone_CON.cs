using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.Contracts.VT.Vol
{
    public interface sp_VolPhone_CON
    {
        List<sp_Phone_DM> ListPhones(sp_Phone_DM cVolPhone);
        sp_Phone_DM ListPrimaryPhone(sp_Phone_DM cVolPhone);
        void InsertPhoneContext(sp_Phone_DM _cPhone);
        void UpdatePhoneNbr(sp_Phone_DM _cPhone);
        void DeletePhonesContext(sp_Phone_DM _cPhone);
    }
}
