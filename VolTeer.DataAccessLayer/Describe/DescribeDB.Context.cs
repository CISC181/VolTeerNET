﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VolTeer.DataAccessLayer.Describe
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
        using System;
        using System.Data.Entity;
        using System.Data.Entity.Infrastructure;
        using System.Data.Entity.Core.Objects;
        using System.Linq;
        using System.Data;
    
    public partial class DescribeEntities : DbContext
    {
        public DescribeEntities()
            : base("name=DescribeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<RegisteredControl> RegisteredControls { get; set; }
    
        public virtual ObjectResult<Describe_CheckConstraints_Result> Describe_CheckConstraints()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Describe_CheckConstraints_Result>("Describe_CheckConstraints");
        }
    
        public virtual ObjectResult<Describe_TableColumns_Result> Describe_TableColumns()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Describe_TableColumns_Result>("Describe_TableColumns");
        }
    }
}
