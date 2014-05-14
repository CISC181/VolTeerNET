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
        public sp_Phone_DM hCreateVolPhone(string PhoneNbr,Guid VolID,bool primaryPhone,ref int numberPhones)
        {
            sp_Phone_DM Phone = new sp_Phone_DM();
            sp_VolPhone_BLL VolPhoneBll = new sp_VolPhone_BLL();

            numberPhones = numberPhones + 1;
            Phone.PhoneID = numberPhones;
            Phone.ActiveFlg = true;
            Phone.PhoneNbr = PhoneNbr;
            Phone.VolID = VolID;
            Phone.PrimaryFlg = primaryPhone;

            VolPhoneBll.InsertPhoneContext(Phone);

            return Phone;

        }

        public List<sp_Phone_DM> hSelectVolPhone(sp_Phone_DM givenPhone)
        {
            List<sp_Phone_DM> PhoneList = new List<sp_Phone_DM>();
            sp_VolPhone_BLL VolPhoneBll = new sp_VolPhone_BLL();

            PhoneList = VolPhoneBll.ListPhones(givenPhone);
            return PhoneList;
        }

        public sp_Phone_DM hSelectPrimaryVolPhone(sp_Phone_DM givenPhone)
        {
            sp_Phone_DM Phone = new sp_Phone_DM();
            sp_VolPhone_BLL VolPhoneBll = new sp_VolPhone_BLL();

            Phone = VolPhoneBll.ListPrimaryPhone(givenPhone);
            return Phone;

        }

        public void hUpdateVolPhone(sp_Phone_DM Phone, string phoneNumber,bool primaryNumber)
        {
            sp_VolPhone_BLL VolPhoneBll = new sp_VolPhone_BLL();

            Phone.PhoneNbr = phoneNumber;
            Phone.PrimaryFlg = primaryNumber;

            VolPhoneBll.UpdatePhoneNbr(Phone);
        }

        public void hDeleteVolPhone(sp_Phone_DM Phone)
        {
            sp_VolPhone_BLL VolPhoneBll = new sp_VolPhone_BLL();

            VolPhoneBll.DeletePhonesContext(Phone);
        }

    }

}
