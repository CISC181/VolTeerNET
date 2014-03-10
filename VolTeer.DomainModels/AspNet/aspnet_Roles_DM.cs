namespace VolTeer.DomainModels.AspNet
{
    using System;
    using System.Collections.Generic;

    public partial class aspnet_Roles_DM
    {
        public System.Guid ApplicationId { get; set; }
        public System.Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string LoweredRoleName { get; set; }
        public string Description { get; set; }

    }
}
