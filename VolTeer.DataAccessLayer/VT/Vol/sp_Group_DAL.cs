using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT.Vol;

namespace VolTeer.DataAccessLayer.VT.Vol
{
    public class sp_Group_DAL
    {
        public List<sp_Group_DM> ListGroups(int iGroupID)
        {
            List<sp_Group_DM> list = new List<sp_Group_DM>();
            using (VolTeerEntities context = new VolTeerEntities())
            {
                list = (from result in context.sp_Group_Select(iGroupID)
                        select new sp_Group_DM
                        {
                            GroupID = result.GroupID,
                            GroupName = result.GroupName,
                            ParticipationLevelID = result.ParticipationLevelID
                        }).ToList();
            } // Guaranteed to close the Connection

            return list;

        }


        public List<sp_Group_DM> InsertGroup(string GroupName_IN, int participationLevelID_IN)
        {
            List<sp_Group_DM> list = new List<sp_Group_DM>();

            using (VolTeerEntities context = new VolTeerEntities())
            {
                list = (from result in context.sp_Group_Insert(GroupName_IN, participationLevelID_IN)
                        select new sp_Group_DM
                        { 
                        }).ToList();
            } // Guaranteed to close the Connection

            return list;
        }

        public void UpdateGroup(int GroupID_IN, string GroupName_IN, int participationLevelID_IN)
        {

            using (VolTeerEntities context = new VolTeerEntities())
            {
                context.sp_Group_Update(GroupID_IN, GroupName_IN, participationLevelID_IN);

            }

        }

        public void DeleteGroup(int GroupID_IN, bool ActiveFlg_IN)
        {
            using (VolTeerEntities context = new VolTeerEntities())
            {
                context.sp_Group_Delete(GroupID_IN,ActiveFlg_IN);

            }

        }

    }
}
