using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS.Domain
{
    public class BaseEntity
    {
        private Guid _Guid = Guid.Empty;
        private int _Status = 1;

        public BaseEntity()
        {
        }

        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 实体的Guid
        /// </summary>
        public Guid Guid
        {
            get
            {
                if(_Guid==Guid.Empty)
                {
                    _Guid = Guid.NewGuid();
                }
                return _Guid;
            }
            set { _Guid = value; }
        }

        /// <summary>
        /// 状态（-1：草稿，0：删除，1：生效）
        /// </summary>
        public int Status
        {
            get { return _Status; }
            set {_Status=value;}
        }
    }
}
