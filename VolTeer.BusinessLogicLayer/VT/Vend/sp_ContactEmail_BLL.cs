using System;
using System.Collections.Generic;
using System.Linq;
using VolTeer.Contracts.VT.Vend;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.DataAccessLayer.VT.Vend;

namespace VolTeer.BusinessLogicLayer.VT.Vend
{
    public class sp_ContactEmail_BLL : sp_ContactEmail_CON
    {
        sp_ContactEmail_DAL DAL = new sp_ContactEmail_DAL();
        public List<sp_ContactEmail_DM> ListContactEmails()
        {
            return DAL.ListContactEmails();
        }

        public List<sp_ContactEmail_DM> ListContactEmails(Guid? contactid, int? emailid)
        {
            return DAL.ListContactEmails(contactid, emailid);
        }

        public sp_ContactEmail_DM ListContactEmails(Guid contactid, int emailid)
        {
            return DAL.ListContactEmails(contactid, emailid);
        }

        public void InsertContactEmailContext(sp_ContactEmail_DM contactemail)
        {
            DAL.InsertContactEmailContext(contactemail);
        }

        public void UpdateContactEmailContext(sp_ContactEmail_DM contactemail)
        {
            DAL.UpdateContactEmailContext(contactemail);
        }

        public void DeleteContactEmailContext(sp_ContactEmail_DM contactemail)
        {
            DAL.DeleteContactEmailContext(contactemail);
        }
    }
}
