﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DataAccessLayer.VT.Vol;
using VolTeer.Contracts.VT.Vol;


namespace VolTeer.BusinessLogicLayer.VT.Vol
{
    public class sp_VolEmail_BLL : sp_VolEmail_CON
    {
        sp_VolEmail_DAL DAL = new sp_VolEmail_DAL();

        public List<sp_Email_DM> ListEmails(sp_Email_DM cVolEmail)
        {
            return DAL.ListEmails(cVolEmail);
        }


        public sp_Email_DM ListPrimaryEmail(sp_Email_DM cVolEmail)
        {
            return DAL.ListPrimaryEmail(cVolEmail);
        }

        public void InsertEmailContext(ref sp_Email_DM _cEmail)
        {
            DAL.InsertEmailContext(ref _cEmail);
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
