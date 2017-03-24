
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.DB
{
    // bd_User
    public class Ataw_User_RolesMap : EntityTypeConfiguration<Ataw_User_Roles>
    {
        public Ataw_User_RolesMap(string schema = "dbo")
        {
            ToTable(schema + ".Ataw_User_Roles");
            HasKey(x => x.UserRoleID);

            Property(x => x.UserRoleID).HasColumnName("UserRoleID").IsRequired().HasMaxLength(50);

            Property(x => x.UserID).HasColumnName("UserID").IsOptional();

            Property(x => x.RoleID).HasColumnName("RoleID").IsOptional();

            Property(x => x.FControlUnitID).HasColumnName("FControlUnitID").IsOptional();

            Ignore(x => x.FID);
        }
    }

}

