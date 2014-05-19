using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.Contracts.VT.Vend;
using VolTeer.DomainModels.VT.Vend;
using VolTeer.DataAccessLayer.VT.Vend;

namespace VolTeer.BusinessLogicLayer.VT.Vend
{
    public class sp_Project_BLL : sp_Project_CON
    {
        sp_Project_DAL dal = new sp_Project_DAL();
        public List<sp_Project_DM> ListProjects()
        {
            return dal.ListProjects();
        }

        public sp_Project_DM ListProjects(Guid? ProjectID)
        {
            return dal.ListProjects(ProjectID);
        }

        public sp_Project_DM InsertProjectContext(ref sp_Project_DM _cProject)
        {
            return dal.InsertProjectContext(ref _cProject);
        }

        public void UpdateProjectContext(sp_Project_DM _cProject)
        {
            dal.UpdateProjectContext(_cProject);
        }

        public void DeleteProjectContext(sp_Project_DM _cProject)
        {
            dal.DeleteProjectContext(_cProject);
        }
    }
}
