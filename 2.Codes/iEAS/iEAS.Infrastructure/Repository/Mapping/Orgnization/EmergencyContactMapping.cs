using iEAS.Orgnization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Orgnization
{
    public class EmergencyContactMapping : IdentityEntityMapping<EmergencyContact>
    {
        public EmergencyContactMapping()
        {
            this.ToTable("EMERGENCY_CONTACT");

            this.Property(m => m.EmployeeID, "EMPLOYEE_ID");
            this.Property(m => m.EmployeeNumber, "EMPLOYEE_NUMBER", 50);
            this.Property(m => m.Name, "NAME", 200);
            this.Property(m => m.Relation, "RELATION", 50);
            this.Property(m => m.RelationName, "RELATION_NAME", 200);
            this.Property(m => m.Telephone, "TELEPHONE", 50);
            this.Property(m => m.Email, "EMAIL", 50);
            this.Property(m => m.Address, "ADDRESS", 50);
            this.Property(m => m.Desc, "DESC",500);

            this.HasRequired(m => m.Employee).WithMany().HasForeignKey(m => m.EmployeeID).WillCascadeOnDelete(false);
        }
    }
}
