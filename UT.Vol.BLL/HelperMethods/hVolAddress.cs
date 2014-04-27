using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;


namespace UT.Vol.BLL.HelperMethods
{
    public class hVolAddress
    {
        public sp_Vol_Address_DM hCreateVolAddress(string AddrLine1,string AddrLine2,string AddrLine3,string City,string State,Nullable<int> Zip,Nullable<int> Zip4,bool PrimaryAddr,Guid VolID)
        {
            sp_Vol_Address_DM VolAddress = new sp_Vol_Address_DM();
            sp_Vol_Addr_DM VolAddr = new sp_Vol_Addr_DM();
            sp_Vol_Address_BLL VolAddressBll = new sp_Vol_Address_BLL();

            VolAddress.AddrLine1 = AddrLine1;
            VolAddress.AddrLine2 = AddrLine2;
            VolAddress.AddrLine3 = AddrLine3;
            VolAddress.City = City;
            VolAddress.St = State;
            VolAddress.Zip = Zip;
            VolAddress.Zip4 = Zip4;

            VolAddr.VolID = VolID;
            VolAddr.PrimaryAddr = PrimaryAddr;

            VolAddressBll.InsertAddressContext(ref VolAddress,ref VolAddr);

            return VolAddress;

        }

       /* public sp_Email_DM hSelectVolAddress(int emailID)
        {
            sp_Email_DM Email = new sp_Email_DM();
            sp_VolEmail_BLL VolEmailBll = new sp_VolEmail_BLL();
            Email = VolEmailBll.ListEmails(emailID);
            return Email;
        }*/

        public void hUpdateVolEmail(sp_Email_DM Email, string emailAddress)
        {
            sp_VolEmail_BLL VolEmailBll = new sp_VolEmail_BLL();

            Email.EmailAddr = emailAddress;

            VolEmailBll.UpdateEmailAddr(Email);
        }

        public void hDeleteVolEmail(sp_Email_DM Email)
        {
            sp_VolEmail_BLL VolEmailBll = new sp_VolEmail_BLL();

            VolEmailBll.DeleteEmailsContext(Email);
        }

    }

}
