using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DB.RC.Collection
{
    public class XP_Folder_TreeMap: EntityTypeConfiguration<XP_Folder_Tree>
    {
        public XP_Folder_TreeMap(string schema = "dbo")
        {
            ToTable(schema + ".XP_Folder_Tree");
            HasKey(x => x.FID);

            Property(x => x.FID).HasColumnName("FID").IsRequired().HasMaxLength(50);

            Property(x => x.F_Name).HasColumnName("F_Name").IsOptional();

            Property(x => x.PID).HasColumnName("PID").IsOptional();

            Property(x => x.F_UserID).HasColumnName("F_UserID").IsOptional();

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
