using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;

namespace VolTeer.Contracts.VT.Vend
{
    public interface sp_VendEmail_CON
    {
        sp_VendEmail_DM ListEmails(int EmailID);
        List<sp_VendEmail_DM> ListEmails();
        int InsertEmailContext(sp_VendEmail_DM InputEmail);
        void UpdateEmailContext(sp_VendEmail_DM InputEmail);
        void DeleteEmailContext(sp_VendEmail_DM InputEmail);
    }
}
