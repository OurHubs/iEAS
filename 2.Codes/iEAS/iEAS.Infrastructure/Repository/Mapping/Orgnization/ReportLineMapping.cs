using iEAS.Orgnization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Orgnization
{
    public class ReportLineMapping : IdentityEntityMapping<ReportLine>
    {
        public ReportLineMapping()
        {
            this.ToTable("REPORT_LINE");

            this.Property(m => m.EmployeeID, "EMPLOYEE_ID");
            this.Property(m => m.EmployeeNumber, "EMPLOYEE_NUMBER", 50);
            this.Property(m => m.SuperiorID, "SUPERIOR_ID");
            this.Property(m => m.SuperiorNumber, "SUPERIOR_NUMBER", 50);

            this.HasRequired(m => m.Employee).WithMany().HasForeignKey(m => m.EmployeeID);
            this.HasRequired(m => m.Superior).WithMany().HasForeignKey(m => m.SuperiorID);
        }
    }
}
