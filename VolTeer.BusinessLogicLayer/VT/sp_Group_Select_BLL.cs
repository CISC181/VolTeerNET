using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT;
using VolTeer.DataAccessLayer.VT;

namespace VolTeer.BusinessLogicLayer.VT
{
    public class sp_Group_Select_BLL
    {

        private sp_Group_Select_DAL DAL = new sp_Group_Select_DAL();

        public List<sp_Group_Select_DM> ListGroups(int IGroupID)
        {
            return DAL.ListGroups(IGroupID);
        }
    }
}
