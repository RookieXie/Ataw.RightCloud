
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.DB
{
    // bd_User
    public class RC_Group_ProductMap : EntityTypeConfiguration<RC_Group_Product>
    {
        public RC_Group_ProductMap(string schema = "dbo")
        {
            ToTable(schema + ".RC_Group_Product");
            HasKey(x => x.FID);
            
             Property(x => x.FID).HasColumnName("FID").IsRequired().HasMaxLength(50);

             Property(x => x.RCGP_ProductFID).HasColumnName("RCGP_ProductFID").IsOptional();

             Property(x => x.RCGP_FControlUnitID).HasColumnName("RCGP_FControlUnitID").IsOptional();

             Property(x => x.CREATE_ID).HasColumnName("CREATE_ID").IsOptional();

             Property(x => x.CREATE_TIME).HasColumnName("CREATE_TIME").IsOptional();

             Property(x => x.UPDATE_ID).HasColumnName("UPDATE_ID").IsOptional();

             Property(x => x.UPDATE_TIME).HasColumnName("UPDATE_TIME").IsOptional();

             Property(x => x.ISDELETE).HasColumnName("ISDELETE").IsOptional();

             Property(x => x.FControlUnitID).HasColumnName("FControlUnitID").IsOptional();

             Property(x => x.TIMESSTAMP).HasColumnName("TIMESSTAMP").IsOptional();

             Property(x => x.UDDATETIME).HasColumnName("UDDATETIME").IsOptional();

             Property(x => x.UDINT1).HasColumnName("UDINT1").IsOptional();

             Property(x => x.UDVARCHAR1).HasColumnName("UDVARCHAR1").IsOptional();

             Property(x => x.UDVARCHAR2).HasColumnName("UDVARCHAR2").IsOptional();


        }
    }

}

