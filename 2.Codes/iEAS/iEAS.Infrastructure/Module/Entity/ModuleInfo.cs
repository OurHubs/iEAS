﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Module
{
    /// <summary>
    /// 模块信息
    /// </summary>
    public class ModuleInfo:IdentityEntity
    {
        private List<Feature> _Features = new List<Feature>();
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 功能列表
        /// </summary>
        public virtual List<Feature> Features
        {
            get { return _Features; }
            set { _Features = value; }
        }
    }
}
