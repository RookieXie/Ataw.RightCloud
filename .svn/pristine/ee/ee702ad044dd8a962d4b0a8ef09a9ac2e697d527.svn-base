using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DB
{
    public class RC_UserRoleMap : EntityTypeConfiguration<RC_UserRole>
    {
        public RC_UserRoleMap(string schema = "dbo")
        {

            Ignore(x => x.FID);
            ToTable(schema + ".RC_User_Role");
            HasKey(x => x.UserRoleFID);

            Property(x => x.UserRoleFID).HasColumnName("FID").IsRequired().HasMaxLength(50);


            Property(x => x.UserID).HasColumnName("RCUR_UserFID").IsOptional();

            Property(x => x.RoleID).HasColumnName("RCUR_RoleFID").IsOptional();

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
