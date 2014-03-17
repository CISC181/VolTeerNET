using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.VT;
using VolTeer.DataAccessLayer.VT;

namespace VolTeer.BusinessLogicLayer.VT
{
    public class sp_Group_BLL
    {

        private sp_Group_DAL DAL = new sp_Group_DAL();

        public List<sp_Group_Select_DM> ListGroups(int IGroupID)
        {
            return DAL.ListGroups(IGroupID);
        }

        public void InsertGroup(string GroupName, int participationLevelID)
        {
            List<sp_Group_Insert_DM> list = new List<sp_Group_Insert_DM>();

            try
            {
                list = DAL.InsertGroup(GroupName, participationLevelID);
            }

            catch (Exception e)
            {
                Console.WriteLine("{0} First exception caught.", e);
            }         

        }


        public void UpdateGroup(int GroupID, string GroupName, int participationLevelID)
        {
            DAL.UpdateGroup(GroupID, GroupName, participationLevelID);

        }

        public void DeleteGroup(int GroupID)
        {
            DAL.DeleteGroup(GroupID);
        }


    }
}
