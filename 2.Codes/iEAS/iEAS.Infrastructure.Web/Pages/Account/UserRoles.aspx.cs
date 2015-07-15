﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iEAS.Infrastructure.UI;
using iEAS.Utility;
using iEAS.Account;
using System.Linq.Expressions;

namespace iEAS.Infrastructure.Web.Pages.Account
{
    public partial class UserRoles : System.Web.UI.Page
    {
        public IUserService UserService { get; set; }
        public IRoleService RoleService { get; set; }
       // public IUserRoleRelService UserRoleRelService { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            Role role = RoleService.GetByID(RoleId.ToGuid(),true);

            // var roleQuery=RoleService.Query().Where(m=>m.Status==1);
            //  var userQuery = UserService.Query().Where(m => m.Status == 1);
            // var relQuey=UserRoleRelService.Query();

            //var result = from user in userQuery
            //             join rel in relQuey on user.ID equals rel.UserID
            //             where rel.RoleID == RoleId.ToGuid()
            //             select user;


            var query = role.Users.Where(m => m.Status == 1);
            string name = txtName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => m.Name.Contains(name));
            }

            var reault = PagedQuery<User>(query, null, o => o.Desc(m => m.SN), aspnetpage.CurrentPageIndex, aspnetpage.PageSize);

            //var result = UserService.PagedQuery(o => o.Desc(m => m.SN), aspnetpage.CurrentPageIndex, aspnetpage.PageSize);
            //PagedResult<User> page = new PagedResult<iEAS.Account.User>(



            gvList.DataSource = reault;
            gvList.DataBind();
            aspnetpage.RecordCount = reault.RecordCount;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserEdit.aspx");
        }

        protected void btnDeleteAll_Click(object sender, EventArgs e)
        {
            Guid[] ids = HttpHelper.GetRequestIds("ids");
            UserService.Delete(m => ids.Contains(m.ID));
            BindData();
            ScriptHelper.Alert("操作成功！");
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                Guid rid = e.CommandArgument.ToGuid();
                UserService.DeleteByID(rid);
                BindData();
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Pager_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            aspnetpage.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleId
        {
            get
            {
                return Request["roleid"];
            }
        }

        public PagedResult<TEntity> PagedQuery<TEntity>(IEnumerable<TEntity> query, Expression<Func<TEntity, bool>> predicate, Action<Orderable<TEntity>> orderby, int pageIndex, int pageSize)
           where TEntity : class
        {
            var startRow = (pageIndex - 1) * pageSize;
           // var query = Query<TEntity>(predicate, orderby);

            return new PagedResult<TEntity>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                RecordCount = query.Count(),
                Items = query.Skip(startRow).Take(pageSize).ToList()
            };
        }
    }
}