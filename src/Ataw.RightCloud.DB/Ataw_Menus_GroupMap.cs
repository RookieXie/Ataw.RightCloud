
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Ataw.RightCloud.Data;

namespace Ataw.RightCloud.DB
{
    // bd_User
    public class Ataw_Menus_GroupMap : EntityTypeConfiguration<Ataw_Menus_Group>
    {
        public Ataw_Menus_GroupMap(string schema = "dbo")
        {
            ToTable(schema + ".Ataw_Menus_Group");
            HasKey(x => x.FID);
            
             Property(x => x.FID).HasColumnName("FID").IsRequired().HasMaxLength(50);

             Property(x => x.FControlUnitID).HasColumnName("FControlUnitID").IsOptional();

             Property(x => x.MenuID).HasColumnName("MenuID").IsOptional();

             Property(x => x.FunctionRight).HasColumnName("FunctionRight").IsOptional();

             Property(x => x.FMyIcon).HasColumnName("FMyIcon").IsOptional();

             Property(x => x.FMyRightKey).HasColumnName("FMyRightKey").IsOptional();

             Property(x => x.Remark).HasColumnName("Remark").IsOptional();

             Property(x => x.TIMESSTAMP).HasColumnName("TIMESSTAMP").IsOptional();

             //Property(x => x.CREATE_ID).HasColumnName("CREATE_ID").IsOptional();

             //Property(x => x.CREATE_TIME).HasColumnName("CREATE_TIME").IsOptional();

             //Property(x => x.UPDATE_ID).HasColumnName("UPDATE_ID").IsOptional();

             //Property(x => x.UPDATE_TIME).HasColumnName("UPDATE_TIME").IsOptional();

             //Property(x => x.ISDELETE).HasColumnName("ISDELETE").IsOptional();

             //Property(x => x.UDDATETIME).HasColumnName("UDDATETIME").IsOptional();

             //Property(x => x.UDINT1).HasColumnName("UDINT1").IsOptional();

             //Property(x => x.UDVARCHAR1).HasColumnName("UDVARCHAR1").IsOptional();

             //Property(x => x.UDVARCHAR2).HasColumnName("UDVARCHAR2").IsOptional();


        }
    }

}

