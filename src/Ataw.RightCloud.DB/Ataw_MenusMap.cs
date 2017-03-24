
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.DB
{
    // bd_User
    public class Ataw_MenusMap : EntityTypeConfiguration<Ataw_Menus>
    {
        public Ataw_MenusMap(string schema = "dbo")
        {
            ToTable(schema + ".Ataw_Menus");
            HasKey(x => x.MenuID);

            Property(x => x.MenuID).HasColumnName("MenuID").IsRequired().HasMaxLength(50);

             Property(x => x.ParentID).HasColumnName("ParentID").IsOptional();

             Property(x => x.IsParent).HasColumnName("IsParent").IsOptional();

             Property(x => x.RightKey).HasColumnName("RightKey").IsOptional();

             Property(x => x.RightValue).HasColumnName("RightValue").IsOptional();

             Property(x => x.RightDesc).HasColumnName("RightDesc").IsOptional();

             Property(x => x.RightType).HasColumnName("RightType").IsOptional();

             Property(x => x.Icon).HasColumnName("Icon").IsOptional();

             Property(x => x.OrderId).HasColumnName("OrderId").IsOptional();

             Property(x => x.KeyType).HasColumnName("KeyType").IsOptional();

             Ignore(x => x.FID);

             Ignore(x => x.ICON_PIC);

        }
    }

}

