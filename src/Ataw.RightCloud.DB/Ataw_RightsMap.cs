
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.DB
{
    // bd_User
    public class Ataw_RightsMap : EntityTypeConfiguration<Ataw_Rights>
    {
        public Ataw_RightsMap(string schema = "dbo")
        {
            ToTable(schema + ".Ataw_Rights");
            HasKey(x => x.FID);
            
             Property(x => x.RightID).HasColumnName("RightID").IsOptional();

             Property(x => x.ParentID).HasColumnName("ParentID").IsOptional();

             Property(x => x.RightKey).HasColumnName("RightKey").IsOptional();

             Property(x => x.RightValue).HasColumnName("RightValue").IsOptional();

             Property(x => x.RightDesc).HasColumnName("RightDesc").IsOptional();

             Property(x => x.RightType).HasColumnName("RightType").IsOptional();

             Property(x => x.Icon).HasColumnName("Icon").IsOptional();

             Property(x => x.OrderId).HasColumnName("OrderId").IsOptional();

             Property(x => x.KeyType).HasColumnName("KeyType").IsOptional();

             Property(x => x.FControlUnitID).HasColumnName("FControlUnitID").IsOptional();


        }
    }

}

