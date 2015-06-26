using iEAS.Account;
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
    public class SessionContext
    {
        private User _User;
        private PortalInfo _Portal;
        private IEnumerable<Role> _Roles;
        private IEnumerable<ModuleInfo> _Modules;
        private IEnumerable<Menu> _Menus;
        private IEnumerable<Permission> _Permissions;

        public static SessionContext Current
        {
            get
            {
                SessionContext ctx = HttpContext.Current.Session[typeof(SessionContext).FullName] as SessionContext;
                if(ctx==null)
                {
                    ctx = new SessionContext();
                    HttpContext.Current.Session[typeof(SessionContext).FullName] = ctx;
                }
                return ctx;
            }
        }

        public PortalInfo Portal
        {
            get
            {
                if (_Portal == null)
                {
                    RegisterPortal("Default");
                    //throw new BusinessException("当前Portal不存在！");
                }
                return _Portal;
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

        public IEnumerable<Menu> Menus
        {
            get
            {
                if (_Menus == null)
                {
                    _Menus = ObjectContainer.GetService<IMenuService>().Query(m => m.Status == 1 && m.PortalID==Portal.ID)
                        .Where(m => Permissions.Any(p => p.ResourceType == ResourceType.Menu))
                        .ToList();
                }
                return _Menus;
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

        public void Init(Guid userID, string portalCode)
        {
            ClearAccount();
            RegisterUserID(userID);
            RegisterPortal(portalCode);
        }

        public void RegisterUserID(Guid userID)
        {
           FormsAuthentication.SetAuthCookie(userID.ToString(),true);
        }

        public void RegisterPortal(string portalCode)
        {
            ClearResources();
            _Portal = ObjectContainer.GetService<IPortalService>().GetPortalByCode(portalCode);
        }

        private void ClearAccount()
        {
            _User = null;
            _Roles = null;
            _Permissions = null;
        }

        private void ClearResources()
        {
            _Portal = null;
            _Menus = null;
            _Modules = null;
        }
    }
}
