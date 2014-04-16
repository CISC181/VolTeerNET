using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DataAccessLayer.VT.Vol;


namespace VolTeer.BusinessLogicLayer.VT.Vol
{
    public class sp_VolEmail_BLL
    {
        sp_VolEmail_DAL DAL = new sp_VolEmail_DAL();

        public List<sp_Email_DM> ListEmails()
        {
            return DAL.ListEmails();
        }

        public sp_Email_DM ListEmails(Guid? Volunteer)
        {
            return DAL.ListEmails(Volunteer);
        }

        public sp_Email_DM ListEmails(int EmailIds)
        {
            return DAL.ListEmails(EmailIds).Single();
        }

        public sp_Email_DM ListPrimaryEmail(int EmailIds)
        {
            return DAL.ListPrimaryEmail(EmailIds);
        }

        public void InsertEmailContext(sp_Email_DM _cEmail)
        {
            DAL.InsertEmailContext(_cEmail);
        }

        public void UpdateEmailAddr(sp_Email_DM _cEmail)
        {
            DAL.UpdateEmailAddr(_cEmail);
        }

        public void DeleteEmailsContext(sp_Email_DM _cEmail)
        {
            DAL.DeleteEmailsContext(_cEmail);
        }

    }
}
