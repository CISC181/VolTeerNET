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
        public sp_Email_DM hCreateVolEmail(string EmailAddr,Guid VolID)
        {
            sp_Email_DM Email = new sp_Email_DM();
            sp_VolEmail_BLL VolEmailBll = new sp_VolEmail_BLL();

            Email.EmailAddr = EmailAddr;
            Email.VolID = VolID;

            VolEmailBll.InsertEmailContext(ref Email);

            return Email;

        }

        public List<sp_Email_DM> hSelectVolEmail(Guid VolID, int emailID)
        {
            List<sp_Email_DM> EmailList = null;
            sp_VolEmail_BLL VolEmailBll = new sp_VolEmail_BLL();
            sp_Email_DM cVolEmail = new sp_Email_DM();
            cVolEmail.VolID = VolID;
            cVolEmail.EmailID = emailID;
            EmailList = VolEmailBll.ListEmails(cVolEmail);
            return EmailList;
        }

        public sp_Email_DM hSelectPrimaryVolEmail(Guid VolID )
        {
            sp_Email_DM Email = new sp_Email_DM();
            sp_VolEmail_BLL VolEmailBll = new sp_VolEmail_BLL();
            sp_Email_DM cVolEmail = new sp_Email_DM();
            cVolEmail.VolID = VolID;
            cVolEmail.EmailID = 0;
            Email = VolEmailBll.ListPrimaryEmail(cVolEmail);
            return Email;
        }

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
