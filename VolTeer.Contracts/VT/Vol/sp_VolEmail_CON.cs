using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.Contracts.VT.Vol
{
    public interface sp_VolEmail_CON
    {
        List<sp_Email_DM> ListEmails(sp_Email_DM cVolEmail);
        sp_Email_DM ListPrimaryEmail(sp_Email_DM cVolEmail);
        void InsertEmailContext(ref sp_Email_DM _cEmail);
        void UpdateEmailAddr(sp_Email_DM _cEmail);
        void DeleteEmailsContext(sp_Email_DM _cEmail);
    }
}
