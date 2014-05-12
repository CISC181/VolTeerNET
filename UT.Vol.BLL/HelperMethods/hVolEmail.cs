using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.BusinessLogicLayer.VT.Vol;


namespace UT.Vol.BLL.HelperMethods
{
    public class hVolEmail
    {
        public sp_Email_DM hCreateVolEmail(string EmailAddr,Guid VolID,bool primaryEmail,ref int numberEmails)
        {
            sp_Email_DM Email = new sp_Email_DM();
            sp_VolEmail_BLL VolEmailBll = new sp_VolEmail_BLL();

            numberEmails = numberEmails + 1;
            Email.EmailID = numberEmails;
            Email.EmailAddr = EmailAddr;
            Email.VolID = VolID;
            Email.PrimaryFlg = primaryEmail;
            Email.ActiveFlg = true;

            VolEmailBll.InsertEmailContext(ref Email);

            return Email;

        }

        public List<sp_Email_DM> hSelectVolEmail(sp_Email_DM givenEmail)
        {
            List<sp_Email_DM> EmailList = null;
            sp_VolEmail_BLL VolEmailBll = new sp_VolEmail_BLL();
            EmailList = VolEmailBll.ListEmails(givenEmail);
            return EmailList;
        }

        public sp_Email_DM hSelectPrimaryVolEmail(sp_Email_DM givenEmail)
        {
            sp_Email_DM Email = new sp_Email_DM();
            sp_VolEmail_BLL VolEmailBll = new sp_VolEmail_BLL();
            Email = VolEmailBll.ListPrimaryEmail(givenEmail);
            return Email;
        }

        public void hUpdateVolEmail(sp_Email_DM Email, string emailAddress, bool primaryFlg)
        {
            sp_VolEmail_BLL VolEmailBll = new sp_VolEmail_BLL();

            Email.EmailAddr = emailAddress;
            Email.PrimaryFlg = primaryFlg;

            VolEmailBll.UpdateEmailAddr(Email);
        }

        public void hDeleteVolEmail(sp_Email_DM Email)
        {
            sp_VolEmail_BLL VolEmailBll = new sp_VolEmail_BLL();

            VolEmailBll.DeleteEmailsContext(Email);
        }

    }

}
