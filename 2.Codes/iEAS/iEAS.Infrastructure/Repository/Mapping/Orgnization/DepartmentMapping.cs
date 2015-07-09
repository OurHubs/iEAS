using iEAS.Orgnization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Orgnization
{
    public class DepartmentMapping : IdentityEntityMapping<Department>
    {
        public DepartmentMapping()
        {
            this.ToTable("DEPARTMENT");

            this.Property(m => m.Name, "NAME", 50);
            this.Property(m => m.Code, "CODE", 50);
            this.Property(m => m.Desc, "DESC", 200);
            this.Property(m => m.PrincipalID, "PRINCIPAL_ID");
            this.Property(m => m.PrincipalNumber, "PRINCIPAL_NUMBER", 200);
            this.Property(m => m.DeputyID, "DEPUTY_ID");
            this.Property(m => m.DeputyNumber, "DEPUTY_NUMBER", 200);
            this.Property(m => m.ParentID, "PARENT_ID");
            this.Property(m => m.CompanyID, "COMPANY_ID");

            this.HasRequired(m => m.Company).WithMany().HasForeignKey(m => m.CompanyID).WillCascadeOnDelete(false);
            this.HasOptional(m => m.Parent).WithMany(m => m.Children).HasForeignKey(m => m.ParentID).WillCascadeOnDelete(false);
        }
    }
}
