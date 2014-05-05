using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;

namespace VolTeer.DataAccessLayer.VT.Vend
{
    class sp_ContactEmail_DAL
    {
        #region Select Statements
        public List<sp_ContactEmail_DM> ListContacts()
        {
            List<sp_ContactEmail_DM> list = new List<sp_ContactEmail_DM>();
            try
            {
                using (VolTeerEntities context = new VolTeerEntities())
                {
                    list = (from result in context.sp_ContactEmail_Select(null, null)
                            select new sp_ContactEmail_DM
                            {
                                ContactID = result.ContactID,
                                EmailID = result.EmailID,
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return list;
        }
        #endregion
    }
}
