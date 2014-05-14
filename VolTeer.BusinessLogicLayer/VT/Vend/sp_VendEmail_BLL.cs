using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.DataAccessLayer.VT.Vend;
using VolTeer.Contracts.VT.Vend;

namespace VolTeer.BusinessLogicLayer.VT.Vend
{
    public class sp_VendEmail_BLL : sp_VendEmail_CON
    {
        sp_VendEmail_DAL DAL = new sp_VendEmail_DAL();

        public List<sp_VendEmail_DM> ListEmails()
        {
            return DAL.ListEmails();
        }

        public sp_VendEmail_DM ListEmails(int? EmailID)
        {
            return DAL.ListEmails(EmailID).Single();
        }

        public int InsertEmailContext(sp_VendEmail_DM InputEmail)
        {
            return DAL.InsertEmailContext(InputEmail);
        }

        public void UpdateEmailContext(sp_VendEmail_DM InputEmail)
        {
            DAL.UpdateEmailContext(InputEmail);
        }

        public void DeleteEmailContext(sp_VendEmail_DM InputEmail)
        {
            DAL.DeleteEmailContext(InputEmail);
        }
    }
}
