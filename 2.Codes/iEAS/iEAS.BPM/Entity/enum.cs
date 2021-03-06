﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    /// <summary>
    /// 审批类型
    /// </summary>
    public enum DestinationType
    {
        /// <summary>
        /// 用户
        /// </summary>
        User=0,
        /// <summary>
        /// 角色
        /// </summary>
        Role,
        /// <summary>
        /// DataField
        /// </summary>
        DateField,
        /// <summary>
        /// 汇报路径
        /// </summary>
        ReportLine
    }
}
