using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure;
using VolTeer.DomainModels;
using VolTeer.DomainModels.AspNet;

namespace VolTeer.DataAccessLayer.AspNet
{
    public class AspNetRolesDAL
    {

        public List<aspnet_Roles_DM> ListAspNetRoles()
        {
            List<aspnet_Roles_DM> list = new List<aspnet_Roles_DM>();
            using (AspNetProviderEntities context = new AspNetProviderEntities())
            {
                list = (from result in context.aspnet_Roles
                        select new aspnet_Roles_DM
                        {
                            ApplicationId = result.ApplicationId,
                            Description = result.Description,
                            LoweredRoleName = result.LoweredRoleName,
                            RoleId = result.RoleId,
                            RoleName = result.RoleName
                        }).ToList();
            } // Guaranteed to close the Connection

            return list;

        }

        public void AddRole(String ApplicationName, String RoleName)
        {

            using (AspNetProviderEntities context = new AspNetProviderEntities())
            {
                var errorCode = context.aspnet_Roles_CreateRole(ApplicationName, RoleName);
            }

        }

        public int DeleteRole(String ApplicationName, String RoleName, Boolean bDeleteOnlyIfEmpty)
        {
            int iErrorCode = 0;
            using (AspNetProviderEntities context = new AspNetProviderEntities())
            {
                iErrorCode = context.aspnet_Roles_DeleteRole(ApplicationName, RoleName, bDeleteOnlyIfEmpty);
            }
            return iErrorCode;
        }

    }


}