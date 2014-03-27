using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VolTeer.BusinessLogicLayer.AspNet;
using VolTeer.DomainModels;
using System.Xml.Serialization;
using System.IO;
using VolTeer.DomainModels.AspNet;


namespace Volteer.WCF.AspNet
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AspNetRoles" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AspNetRoles.svc or AspNetRoles.svc.cs at the Solution Explorer and start debugging.
    public class AspNetRoles : IAspNetRoles
    {
        AspNetRolesBLL BLL = new AspNetRolesBLL();

        public string ListAspNetRoles()
        {
            List<aspnet_Roles_DM> RoleList = new List<aspnet_Roles_DM>();
            var ser = new XmlSerializer(typeof(List<aspnet_Roles_DM>));
            RoleList = BLL.ListAspNetRoles();
            StringWriter sw = new StringWriter();
            ser.Serialize(sw, RoleList);
            return sw.ToString();
        }
    }
}
