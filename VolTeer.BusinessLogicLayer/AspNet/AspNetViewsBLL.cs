using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolTeer.DomainModels.AspNet;
using VolTeer.DataAccessLayer.AspNet;

namespace VolTeer.BusinessLogicLayer.AspNet
{
    public class AspNetViewsBLL
    {
        AspNetViews DAL = new AspNetViews();
        public vw_aspnet_MembershipUsers_DM ListUser(string strUserName)
        {
            return DAL.ListUser(strUserName);
        }
    }
}
