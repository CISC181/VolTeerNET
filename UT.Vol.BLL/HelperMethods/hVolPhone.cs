using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;


namespace UT.Vol.BLL.HelperMethods
{
    public class hVolPhone
    {
        public sp_Phone_DM hCreateVolPhone(string PhoneNbr,Guid VolID)
        {
            sp_Phone_DM Phone = new sp_Phone_DM();
            sp_VolPhone_BLL VolPhoneBll = new sp_VolPhone_BLL();

            Phone.PhoneNbr = PhoneNbr;
            Phone.VolID = VolID;

            VolPhoneBll.InsertPhonesContext(Phone);

            return Phone;

        }

        public List<sp_Phone_DM> hSelectVolPhone(int phoneID)
        {
            sp_Phone_DM Phone = new sp_Phone_DM();
            List<sp_Phone_DM> PhoneList = new List<sp_Phone_DM>();
            sp_VolPhone_BLL VolPhoneBll = new sp_VolPhone_BLL();

            Phone.PhoneID = phoneID;
            PhoneList = VolPhoneBll.ListPhones(Phone);
            return PhoneList;
        }

        public void hUpdateVolPhone(sp_Phone_DM Phone, string phoneNumber)
        {
            sp_VolPhone_BLL VolPhoneBll = new sp_VolPhone_BLL();

            Phone.PhoneNbr = phoneNumber;

            VolPhoneBll.UpdatePhoneNbr(Phone);
        }

        public void hDeleteVolPhone(sp_Phone_DM Phone)
        {
            sp_VolPhone_BLL VolPhoneBll = new sp_VolPhone_BLL();

            VolPhoneBll.DeletePhonesContext(Phone);
        }

    }

}
