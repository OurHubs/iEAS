using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS.Domain
{
    public class BaseEntity
    {
        private Guid _Guid = Guid.Empty;

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
    }
}
