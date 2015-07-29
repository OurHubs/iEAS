using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public class WorklistItem
    {
        public Guid Id { get; set; }
        public Guid ProcessInstanceId { get; set; }
        public Guid ActivityInstanceId { get; set; }
        /// <summary>
        /// 状态:0,未处理，1,处理完成
        /// </summary>
        public int State { get; set; }
        public virtual ProcessInstance ProcessInstance { get; set; }
        public virtual ActivityInstance ActivityInstance { get; set; }
    }
}
