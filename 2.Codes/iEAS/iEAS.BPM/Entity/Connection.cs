using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM
{
    /// <summary>
    /// 流程连接
    /// </summary>
    public class Connection:IDisposable
    {
        private string _Impersonator;

        public Connection()
        {
        }

        /// <summary>
        /// 打开流程连接
        /// </summary>
        public void Open()
        {
        }

        /// <summary>
        /// 设置当前操作人
        /// </summary>
        /// <param name="impersonator">当前操作人</param>
        public void ImpersonateUser(string impersonator)
        {
            _Impersonator = impersonator;
        }

        public string Impersonator
        {
            get { return _Impersonator; }
        }

        /// <summary>
        /// 创建流程实例
        /// </summary>
        /// <param name="processCode"></param>
        /// <returns></returns>
        public ProcessInstance CreateProcessInstance(string processCode)
        {
            ProcessInstance instance = new ProcessInstance();
            using (var rep = new BPMRepository())
            { 
                var process = rep.Process.FirstOrDefault(m => m.Code == processCode);
                instance.Process = process;
                instance.ProcessId = process.Id;
                rep.ProcessInstance.Add(instance);
                rep.SaveChanges();
            }

            return instance;
        }

        public Worklist OpenWorklist()
        {
            return null;
        }

        /// <summary>
        /// 打开指流流程的任务列表
        /// </summary>
        /// <param name="processName">流程名称</param>
        /// <returns>任务列表</returns>
        public Worklist OpenWorklist(string processName)
        {
            return null;
        }

        /// <summary>
        /// 打开任务项
        /// </summary>
        /// <param name="sn">序号(流程实例Id+节点Id)</param>
        /// <returns></returns>
        private WorklistItem OpenWorklistItem(string sn)
        {
            return null;
        }

        public void Dispose()
        {
        }
    }
}
