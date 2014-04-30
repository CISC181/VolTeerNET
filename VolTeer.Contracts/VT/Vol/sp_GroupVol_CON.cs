using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.Contracts.VT.Vol
{
    public interface sp_GroupVol_CON
    {
        sp_Vol_GroupVol_DM InsertGroupContext(ref sp_Vol_GroupVol_DM _cGroup);
        void DeleteGroupContext(sp_Vol_GroupVol_DM _cVolID);
        void MakePrimaryVolID(sp_Vol_GroupVol_DM _cGroup);
        void MakeAdminVolID(sp_Vol_GroupVol_DM _cGroup);
    }
}
