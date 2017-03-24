using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DB
{
    public class Ataw_ReplayMap: EntityTypeConfiguration<Sns_Replay>
    {
        public Ataw_ReplayMap(string schema = "dbo")
        {
            ToTable(schema + ".Ataw_Replay");

            HasKey(x => x.FID);

            Property(x => x.SnsR_ResouceID).HasColumnName("SnsR_ResouceID").IsOptional();
            Property(x => x.SnsR_CID).HasColumnName("SnsR_CID").IsOptional();
            Property(x => x.SnsR_FromUser).HasColumnName("SnsR_FromUser").IsOptional();
            Property(x => x.SnsR_ToUser).HasColumnName("SnsR_ToUser").IsOptional();
            Property(x => x.SnsR_Content).HasColumnName("SnsR_Content").IsOptional();
        }
    }
}
