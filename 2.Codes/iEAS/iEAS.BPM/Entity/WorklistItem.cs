using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    public class WorklistItem
    {
        /// <summary>
        /// 状态:0,未处理，1,处理完成
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 审批人
        /// </summary>
        public string Approer { get; set; }

        public ProcessInstance ProcessInstance { get; set; }
        public ActivityInstance ActivityInstance { get; set; }
    }
}
