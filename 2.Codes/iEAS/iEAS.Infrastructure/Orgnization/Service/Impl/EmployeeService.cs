using iEAS.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Orgnization
{
    public class EmployeeService : IdentityDomainService<Employee, iEAS.Repository.iEASRepository>, IEmployeeService
    {
        public override void Create(Employee employee)
        {
            IEmployeeService employeeService = ObjectContainer.GetService<IEmployeeService>();
            using (var ctx = employeeService.BeginContext())
            {
                employee.BindCreator();

                User user = new User();
                BindUser(employee, user);
                employee.User = user;

                ctx.Create(employee);
                ctx.Commit();
            }
        }

        public override void Delete(Employee entity)
        {
            IEmployeeService employeeService = ObjectContainer.GetService<IEmployeeService>();
            using (var ctx = employeeService.BeginContext())
            {
                IUserService userService = ctx.Get<IUserService>();
                base.Delete(entity);
                userService.Delete(m => m.ID == entity.ID);
                ctx.Commit();
            }
        }

        public override void Update(Expression<Func<Employee, bool>> predicate, Action<Employee> handler)
        {
            base.Update(predicate, m =>
            {
                handler(m);
                this.BindUser(m, m.User);
            });
        }

        public override void Update(Employee entity)
        {
            IEmployeeService employeeService = ObjectContainer.GetService<IEmployeeService>();
            using (var ctx = employeeService.BeginContext())
            {
                IUserService userService = ctx.GetService<IUserService>();

                User user = userService.GetByID(entity.ID);
                BindUser(entity, user);

                base.Update(entity);
                userService.Update(user);
            }
        }

        private void BindUser(Employee employee, User user)
        {
            user.Name = employee.ChineseName;
            user.Birthday = employee.Birthday;
            user.Email = employee.Email;
            user.Gender = employee.Gender;
            user.HomeAddress = employee.HomeAddress;
            user.WorkAddress = employee.WorkAddress;
            user.WorkZip = employee.WorkZipCode;
            user.Telephone = employee.MobilePhone;

            user.Status = employee.Status;
            user.UpdateTime = employee.UpdateTime;
            user.Updator = employee.Updator;
            user.CreateTime = employee.CreateTime;
            user.Creator = employee.Creator;
        }
    }
}
