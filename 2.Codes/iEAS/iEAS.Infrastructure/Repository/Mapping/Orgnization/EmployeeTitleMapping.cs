using iEAS.Orgnization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Orgnization
{
    public class EmployeeTitleMapping : IdentityEntityMapping<EmployeeTitle>
    {
        public EmployeeTitleMapping()
        {
            this.ToTable("EMPLOYEE_TITLE");

            this.Property(m => m.EmployeeID, "EMPLOYEE_ID");
            this.Property(m => m.EmployeeNumber, "EMPLOYEE_NUMBER", 50);
            this.Property(m => m.TitleID, "TITLE_ID");
            this.Property(m => m.TitleCode, "TITLE_CODE", 50);

            this.HasRequired(m => m.Employee).WithMany().HasForeignKey(m => m.EmployeeID).WillCascadeOnDelete(false);
            this.HasRequired(m => m.Title).WithMany().HasForeignKey(m => m.TitleID).WillCascadeOnDelete(false);
        }
    }
}
