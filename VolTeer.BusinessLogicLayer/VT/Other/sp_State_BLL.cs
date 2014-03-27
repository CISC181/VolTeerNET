using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Other;
using VolTeer.DataAccessLayer.VT.Other;

namespace VolTeer.BusinessLogicLayer.VT.Other
{
    public class sp_State_BLL
    {

        private sp_State_DAL DAL = new sp_State_DAL();

        public List<sp_State_Select_DM> ListStates()
        {
            return DAL.ListStates();
        } 

    }
}
