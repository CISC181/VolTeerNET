using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.Contracts.VT.Vol
{
    public interface sp_Group_Con
    {
        List<sp_Group_DM> ListGroups();
        sp_Group_DM ListGroups(int? groupID);
        sp_Group_DM InsertGroupContext(ref sp_Group_DM _cGroup);
        void UpdateGroupContext(sp_Group_DM _cGroup);
        void DeleteGroupContext(sp_Group_DM _cGroup);
    }
}
