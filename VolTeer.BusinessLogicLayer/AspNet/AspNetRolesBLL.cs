using System;
using System.Linq;
using VolTeer.DataAccessLayer.AspNet;
using VolTeer.DomainModels.AspNet;
using System.Collections.Generic;
using System.Xml.Serialization;

using System.IO;


namespace VolTeer.BusinessLogicLayer.AspNet
{
    public class AspNetRolesBLL
    {
        private AspNetRolesDAL DAL = new AspNetRolesDAL();

        public List<aspnet_Roles_DM> ListAspNetRoles()
        {

            List<aspnet_Roles_DM> RoleList = new List<aspnet_Roles_DM>();
            var ser = new XmlSerializer(typeof(List<aspnet_Roles_DM>));
            RoleList = DAL.ListAspNetRoles();
            using (var sw = new System.IO.StringWriter())
            {
                ser.Serialize(sw, RoleList);
            }

            return DAL.ListAspNetRoles();

        }

        public void AddRole(String ApplicationName, String RoleName)
        {
            DAL.AddRole(ApplicationName, RoleName);

        }

        public int DeleteRole(String ApplicationName, String RoleName, Boolean bDeleteOnlyIfEmpty)
        {
            int iErrorCode = DAL.DeleteRole(ApplicationName, RoleName, bDeleteOnlyIfEmpty);
            return iErrorCode;
        }
    }
}
