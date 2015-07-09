using iEAS.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iEAS.Infrastructure.Web.Pages.Account.UxControls
{
    public partial class RoleSelect : System.Web.UI.UserControl
    {
        public IRoleService RoleService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BindRoles(IEnumerable<Role> selectedRoles)
        {
            chkRoles.Items.Clear();

            var roles = RoleService.Query(m => m.Status == 1);

            foreach(var role in roles)
            {
                ListItem lstItem = new ListItem(role.Name, role.ID.ToString());

                lstItem.Selected = selectedRoles.Any(m => m.ID == role.ID);

                chkRoles.Items.Add(lstItem);
            }
        }

        public IList<Guid> GetRoleIds()
        {
            List<Guid> roleIds = new List<Guid>();

            foreach(ListItem item in chkRoles.Items)
            {
                if (item.Selected)
                {
                    roleIds.Add(item.Value.ToGuid());
                }
            }

            return roleIds;
        }
    }
}