using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS
{
    /// <summary>
    /// 数据服务上下文
    /// </summary>
    public interface IContextService
    {
        /// <summary>
        /// 加入数据上下文
        /// </summary>
        /// <param name="dbContext"></param>
        void JoinContext(BaseRepository dbContext);

        /// <summary>
        /// 开始服务数据上下文
        /// </summary>
        /// <returns></returns>
        BaseRepository BeginContext();
    }
}
