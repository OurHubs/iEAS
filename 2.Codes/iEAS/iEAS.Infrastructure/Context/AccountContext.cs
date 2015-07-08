﻿using iEAS.Account;
using iEAS.Context;
using iEAS.Module;
using iEAS.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace iEAS
{
    public class AccountContext
    {
        private User _User;
        private IEnumerable<Role> _Roles;
        private IEnumerable<ModuleInfo> _Modules;
        private IEnumerable<Permission> _Permissions;
        private Dictionary<string, IEnumerable<Menu>> _PortalMenus = new Dictionary<string, IEnumerable<Menu>>();

        public static AccountContext Current
        {
            get
            {
                AccountContext ctx = HttpContext.Current.Session[typeof(AccountContext).FullName] as AccountContext;
                if(ctx==null)
                {
                    ctx = new AccountContext();
                    HttpContext.Current.Session[typeof(AccountContext).FullName] = ctx;
                }
                return ctx;
            }
        }

        public User User
        {
            get
            {
                if(_User==null)
                {
                    string userID = HttpContext.Current.User.Identity.Name;
                    Guid? guid = userID.ToNGuid();
                    if(guid==null)
                    {
                        throw new SystemException("无效的用户ID");
                    }
                    _User=ObjectContainer.GetService<IUserService>().GetByGuid(userID.ToGuid());
                    if (_User == null)
                    {
                        throw new BusinessException("当前用户不存在！");
                    }
                }
                return _User;
            }
        }

        public IEnumerable<Role> Roles
        {
            get
            {
                if(_Roles==null)
                {
                    _Roles = ObjectContainer.GetService<IUserService>().GetUserRoles(User.ID);
                }
                return _Roles;
            }
        }

        public IEnumerable<ModuleInfo> Modules
        {
            get
            {
                if(_Modules==null)
                {
                    _Modules = ObjectContainer.GetService<IModuleService>().Query(m => m.Status == 1)
                        .Where(m => Permissions.Any(p => p.ResourceType == ResourceType.Module))
                        .ToList();

                }
                return _Modules;
            }
        }

        public IEnumerable<Permission> Permissions
        {
            get
            {
                if(_Permissions==null)
                {
                    _Permissions = ObjectContainer.GetService<IPermissionService>().GetUserPermissions(User.ID);
                }
                return _Permissions;
            }
        }

        public void RegisterUserID(Guid userID)
        {
           ClearAccount();
           FormsAuthentication.SetAuthCookie(userID.ToString(),true);
        }

        public IEnumerable<Menu> GetPortalMenus(string portalCode)
        {
            if(!_PortalMenus.ContainsKey(portalCode))
            {
                var portal=PortalContext.Current.GetPortal(portalCode);
                var menus = portal.Menus
                    .Where(m => Permissions.Any(p => p.ResouceID == m.Guid.ToString()))
                    .ToList();

                _PortalMenus.Add(portalCode, menus);
            }
            return _PortalMenus[portalCode];
        }

        private void ClearAccount()
        {
            _User = null;
            _Roles = null;
            _Permissions = null;
            _Modules = null;

            _PortalMenus.Clear();
        }

        private void ClearResources()
        {
            _Modules = null;
        }
    }
}