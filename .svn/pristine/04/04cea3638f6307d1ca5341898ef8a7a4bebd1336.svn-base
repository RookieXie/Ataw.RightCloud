
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.DB
{
    // bd_User
    public class Ataw_RolesMap : EntityTypeConfiguration<Ataw_Roles>
    {
        public Ataw_RolesMap(string schema = "dbo")
        {
            ToTable(schema + ".Ataw_Roles");
            HasKey(x => x.RoleID);

            Property(x => x.RoleID).HasColumnName("RoleID").IsRequired().HasMaxLength(50);

            Property(x => x.RoleSign).HasColumnName("RoleSign").IsOptional();

            Property(x => x.RoleName).HasColumnName("RoleName").IsOptional();

            Property(x => x.FControlUnitID).HasColumnName("FControlUnitID").IsOptional();

            Property(x => x.IsPublic).HasColumnName("IsPublic").IsOptional();

            Property(x => x.Description).HasColumnName("Description").IsOptional();

            Property(x => x.AutoAssignment).HasColumnName("AutoAssignment").IsOptional();

            Property(x => x.IconFile).HasColumnName("IconFile").IsOptional();

           // Property(x => x.ICON_PIC).HasColumnName("ICON_PIC").IsOptional();

            Property(x => x.CreatedOn).HasColumnName("CreatedOn").IsOptional();

            Property(x => x.UnitID).HasColumnName("UnitID").IsOptional();

            Ignore(x => x.FID);

            Ignore(x => x.ICON_PIC);
        }
    }

}

