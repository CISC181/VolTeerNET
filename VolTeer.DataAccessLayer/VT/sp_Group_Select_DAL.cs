using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT;
namespace VolTeer.DataAccessLayer.VT
{
    public class sp_Group_Select_DAL
    {
        public List<sp_Group_Select_DM> ListGroups(int iGroupID)
        {
            List<sp_Group_Select_DM> list = new List<sp_Group_Select_DM>();
            using (VolTeerEntities context = new VolTeerEntities())
            {
                list = (from result in context.sp_Group_Select(iGroupID)
                        select new sp_Group_Select_DM
                        {
                            GroupID = result.GroupID,
                            GroupName = result.GroupName,
                            ParticipationLevelID = result.ParticipationLevelID
                        }).ToList();
            } // Guaranteed to close the Connection

            return list;

        }
    }
}
