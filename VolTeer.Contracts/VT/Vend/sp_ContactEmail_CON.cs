using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;

namespace VolTeer.Contracts.VT.Vend
{
    public interface sp_ContactEmail_CON
    {
        List<sp_ContactEmail_DM> ListContactEmails();
        List<sp_ContactEmail_DM> ListContactEmails(Guid? contactid, int? emailid);
        sp_ContactEmail_DM ListContactEmails(Guid contactid, int emailid);

        void InsertContactEmailContext(ref sp_ContactEmail_DM contactemail);
        void UpdateContactEmailContext(sp_ContactEmail_DM contactemail);
        void DeleteContactEmailContext(sp_ContactEmail_DM contactemail);

    }
}
