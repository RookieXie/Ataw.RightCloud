using Ataw.RightCloud.Data;
using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DB
{
    public class Ataw_PageLockMap: EntityTypeConfiguration<Ataw_PageLock>
    {
        public Ataw_PageLockMap(string schema = "dbo")
        {
            ToTable(schema + ".PL_PageLock");
            HasKey(x => x.FID);
            Property(x => x.PL_IsLock).HasColumnName("PL_IsLock").IsOptional();       
            Property(x => x.PL_Pwd).HasColumnName("PL_Pwd").IsOptional();
            Property(x => x.PL_UserName).HasColumnName("PL_UserName").IsOptional();

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
