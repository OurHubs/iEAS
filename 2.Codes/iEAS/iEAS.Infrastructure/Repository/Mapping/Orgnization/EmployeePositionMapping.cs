using iEAS.Orgnization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Orgnization
{
    public class EmployeePositionMapping : IdentityEntityMapping<EmployeePosition>
    {
        public EmployeePositionMapping()
        {
            this.ToTable("EMPLOYEE_POSITION");

            this.Property(m => m.EmployeeID, "EMPLOYEE_ID");
            this.Property(m => m.EmployeeNumber, "EMPLOYEE_NUMBER", 50);
            this.Property(m => m.DepartmentID, "DEPARTMENT_ID");
            this.Property(m => m.DepartmentCode, "DEPARTMENT_CODE", 50);
            this.Property(m => m.PositionID, "POSITION_ID");
            this.Property(m => m.PositionCode, "POSITION_CODE", 50);

            this.HasRequired(m => m.Employee).WithMany(m=>m.DepartmentPostions).HasForeignKey(m => m.EmployeeID).WillCascadeOnDelete(false);
            this.HasRequired(m => m.Department).WithMany().HasForeignKey(m => m.DepartmentID).WillCascadeOnDelete(false);
            this.HasRequired(m => m.Position).WithMany().HasForeignKey(m => m.PositionID).WillCascadeOnDelete(false);
        }
    }
}
