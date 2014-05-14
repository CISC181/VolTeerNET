using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vend;

namespace VolTeer.Contracts.VT.Vend
{
    public interface sp_Project_CON
    {
        List<sp_Project_DM> ListProjects();
        sp_Project_DM ListProjects(Guid? ProjectID);
        sp_Project_DM InsertProjectContext(ref sp_Project_DM _cProject);
        void UpdateProjectContext(sp_Project_DM _cProject);
        void DeleteProjectContext(sp_Project_DM _cProject);
    }
}
