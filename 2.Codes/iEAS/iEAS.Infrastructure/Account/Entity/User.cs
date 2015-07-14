using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iEAS.Security;

namespace iEAS.Account
{
    public class User : IdentityEntity,IUserInfo
    {
        private List<Role> _Roles = new List<Role>();

        /// <summary>
        /// 登陆名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 呢称
        /// </summary>
        public string Nick { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string HomeZip { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string HomeAddress { get; set; }
        /// <summary>
        /// 工作邮编
        /// </summary>
        public string WorkZip { get; set; }
        /// <summary>
        /// 工作地址
        /// </summary>
        public string WorkAddress { get; set; }
        /// <summary>
        /// 加密方式
        /// </summary>
        public EncryptionType EncryptionType { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; }
        public virtual List<Role> Roles
        {
            get { return _Roles; }
            set { _Roles = value; }
        }
    }
}
