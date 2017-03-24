using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DB
{
    public class Ataw_CommentMap : EntityTypeConfiguration<Sns_Comment>
    {
        public Ataw_CommentMap(string schema = "dbo")
        {
            ToTable(schema + ".Sns_Comment");
            HasKey(x => x.FID);

            Property(x => x.SnsC_ResouceID).HasColumnName("SnsC_ResouceID").IsOptional();
            Property(x => x.SnsC_ResouceType).HasColumnName("SnsC_ResouceType").IsOptional();
            Property(x => x.SnsC_Content).HasColumnName("SnsC_Content").IsOptional();
            Property(x => x.SnsC_User).HasColumnName("SnsC_User").IsOptional();
            Property(x => x.SnsC_ToUser).HasColumnName("SnsC_ToUser").IsOptional();
            Property(x => x.IsAuditing).HasColumnName("IsAuditing").IsOptional();

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
