
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.DB
{
    // bd_User
    public class RC_Menu_treeMap : EntityTypeConfiguration<RC_Menu_tree>
    {
        public RC_Menu_treeMap(string schema = "dbo")
        {
            ToTable(schema + ".RC_Menu_tree");
            HasKey(x => x.FID);
            
             Property(x => x.FID).HasColumnName("FID").IsRequired().HasMaxLength(50);

             Property(x => x.RCM_Dir).HasColumnName("RCM_Dir").IsOptional();

             Property(x => x.PID).HasColumnName("PID").IsOptional();

             Property(x => x.RCM_Name).HasColumnName("RCM_Name").IsOptional();

             Property(x => x.RCM_ButtonList).HasColumnName("RCM_ButtonList").IsOptional();

             Property(x => x.RCM_ProductList).HasColumnName("RCM_ProductList").IsOptional();

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

