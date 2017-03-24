using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DB
{
    public class Ataw_Comment_ResouceMap : EntityTypeConfiguration<Sns_Comment_Resouce>
    {
        public Ataw_Comment_ResouceMap(string schema = "dbo")
        {
            ToTable(schema + ".Sns_Comment_Resouce");

            HasKey(x => x.FID);

            Property(x => x.SnsCR_ResouceID).HasColumnName("SnsCR_ResouceID").IsOptional();
            Property(x => x.SnsCR_Type).HasColumnName("SnsCR_Type").IsOptional();
            Property(x => x.SnsCR_RepNum).HasColumnName("SnsCR_RepNum").IsOptional();
            Property(x => x.IsAuditing).HasColumnName("IsAuditing").IsOptional();
            Property(x => x.IsProof).HasColumnName("IsProof").IsOptional();

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

            Property(x => x.SnsCR_Title).HasColumnName("SnsCR_Title").IsOptional();
        }
    }
}
