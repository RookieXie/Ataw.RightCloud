
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.DB
{
    // bd_User
    public class RC_Group_treeMap : EntityTypeConfiguration<RC_Group_tree>
    {
        public RC_Group_treeMap(string schema = "dbo")
        {
            ToTable(schema + ".RC_Group_tree");
            HasKey(x => x.FID);
            
             Property(x => x.FID).HasColumnName("FID").IsRequired().HasMaxLength(50);

             Property(x => x.RCG_Code).HasColumnName("RCG_Code").IsOptional();

             Property(x => x.PID).HasColumnName("PID").IsOptional();

             Property(x => x.RCG_Name).HasColumnName("RCG_Name").IsOptional();

             Property(x => x.RCG_ProductList).HasColumnName("RCG_ProductList").IsOptional();

             Property(x => x.IS_PARENT).HasColumnName("IS_PARENT").IsOptional();

             Property(x => x.ISLEAF).HasColumnName("ISLEAF").IsOptional();

             Property(x => x.ARRANGE).HasColumnName("ARRANGE").IsOptional();

             Property(x => x.TREEORDER).HasColumnName("TREEORDER").IsOptional();

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

