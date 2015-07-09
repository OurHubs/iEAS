using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS
{
    public class BaseEntity
    {
        private Guid _ID = Guid.Empty;

        public BaseEntity()
        {
        }

        /// <summary>
        /// 主键ID
        /// </summary>
        public Guid ID
        {
            get 
            {
                if(_ID==Guid.Empty)
                {
                    _ID = Guid.NewGuid();
                }
                return _ID;
            }
            set { _ID = value; }
        }

        /// <summary>
        /// 实体的Guid
        /// </summary>
        public int SN { get; set; }

        public int Version { get; set; }
    }
}
