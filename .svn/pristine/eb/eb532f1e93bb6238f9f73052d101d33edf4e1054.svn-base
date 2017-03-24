
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.DB
{
    // bd_User
    public class Ataw_Menus_ButtonMap : EntityTypeConfiguration<Ataw_Menus_Button>
    {
        public Ataw_Menus_ButtonMap(string schema = "dbo")
        {
            ToTable(schema + ".Ataw_Menus_Button");
            HasKey(x => x.FID);
            
             Property(x => x.FID).HasColumnName("FID").IsRequired().HasMaxLength(50);

             Property(x => x.ParentRightValue).HasColumnName("ParentRightValue").IsOptional();

             Property(x => x.FName).HasColumnName("FName").IsOptional();

             Property(x => x.FKey).HasColumnName("FKey").IsOptional();

             Property(x => x.FValue).HasColumnName("FValue").IsOptional();

             Property(x => x.OrderId).HasColumnName("OrderId").IsOptional();


        }
    }

}

