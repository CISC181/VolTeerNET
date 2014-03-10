using System;
using System.Linq;
using System.Text;
using VolTeer.DataAccessLayer;
using VolTeer.DataAccessLayer.AspNet;

using System.Collections.Generic;
using VolTeer.DomainModels.AspNet;


namespace VolTeer.BusinessLogicLayer.AspNet
{
    public class AspNetUsersBLL
    {
        private AspNetUsersDAL dal = new AspNetUsersDAL();

        public List<vw_aspnet_MembershipUsers_DM> vMembershipUsers_In_Role(string RoleName)
        {
            return dal.vMembershipUsers_In_Role(RoleName);
        }
    }
}
