using Ataw.RightCloud.Data.Table;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataw.RightCloud.DB.RC
{
  public  class RC_DepartmentMap : EntityTypeConfiguration<RC_Department>
    {
        public RC_DepartmentMap(string schema = "dbo")
        {
            ToTable(schema + ".MRP_Department");
            HasKey(x => x.FID);

            Property(x => x.FID).HasColumnName("FID").IsRequired().HasMaxLength(50);

            Property(x => x.FName).HasColumnName("FName").IsOptional();

            Property(x => x.FNumber).HasColumnName("FNumber").IsOptional();

            Property(x => x.FDescription).HasColumnName("FDescription").IsOptional();

            Property(x => x.FSimpleName).HasColumnName("FSimpleName").IsOptional();

            Property(x => x.FIsCompanyOrgUnit).HasColumnName("FIsCompanyOrgUnit").IsOptional();

            Property(x => x.FIsAdminOrgUnit).HasColumnName("FIsAdminOrgUnit").IsOptional();
            Property(x => x.FIsSaleOrgUnit).HasColumnName("FIsSaleOrgUnit").IsOptional();
            Property(x => x.FIsPurchaseOrgUnit).HasColumnName("FIsPurchaseOrgUnit").IsOptional();
            Property(x => x.FIsStorageOrgUnit).HasColumnName("FIsStorageOrgUnit").IsOptional();
            Property(x => x.FIsCostOrgUnit).HasColumnName("FIsCostOrgUnit").IsOptional();
            Property(x => x.FParentFID).HasColumnName("FParentFID").IsOptional();
            Property(x => x.FPhone).HasColumnName("FPhone").IsOptional();
            Property(x => x.OrderCode).HasColumnName("OrderCode").IsOptional();
            Property(x => x.IsParent).HasColumnName("IsParent").IsOptional();

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
