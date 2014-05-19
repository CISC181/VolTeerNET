using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;
using VolTeer.DataAccessLayer.VT.Vol;
using VolTeer.Contracts.VT.Vol;

namespace VolTeer.BusinessLogicLayer.VT.Vol
{
    public class sp_Group_BLL : sp_Group_Con
    {

        sp_Group_DAL DAL = new sp_Group_DAL();

        public List<sp_Group_DM> ListGroups()
        {
            return DAL.ListGroups();
        }
       
        public sp_Group_DM ListGroups(int IGroupID)
        {            
            return DAL.ListGroups(IGroupID);
        }

        
        public sp_Group_DM InsertGroupContext(ref sp_Group_DM _cGroup)
        {
            return DAL.InsertGroupContext(ref _cGroup);
        }

        public void UpdateGroupContext(sp_Group_DM _cGroup)
        {
            DAL.UpdateGroupContext(_cGroup);
        }

        public void DeleteGroupContext(sp_Group_DM _cGroup)
        {
            DAL.DeleteGroupContext(_cGroup);
        }





        public sp_Group_DM ListGroups(int? groupID)
        {
            return DAL.ListGroups(groupID);
        }

        public List<sp_GroupSearch_DM> SearchGroups(string searchTerms)
        {
            return DAL.SearchGroups(searchTerms);
        }
    }
}
