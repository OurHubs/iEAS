using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.BPM.Client
{
    public class Connection:IDisposable
    {
        private string _ConnectionString;
        private string _Impersonator;
        private ChannelFactory<IBPMService> _ChannelFacotry;

        public Connection(string connectionString)
        {
            this._ConnectionString = connectionString;
        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return _ConnectionString; }
        }

        public void Open()
        {
            EndpointAddress address = new EndpointAddress(this._ConnectionString);
            BasicHttpBinding binding = new BasicHttpBinding();
            _ChannelFacotry = new ChannelFactory<IBPMService>(binding,address);
            var service=_ChannelFacotry.CreateChannel();
            service.DoWork();
        }

        public ProcessInstance CreateProcessInstance(string processCode)
        {
            var service = _ChannelFacotry.CreateChannel();
            var instance=service.CreateProcessInstance(processCode);
            instance.BPMService = service;
            instance.Originator = this._Impersonator;
            return instance;
        }

        public WorklistItem OpenWorklistItem(string sn)
        {
            var service = _ChannelFacotry.CreateChannel();
            var worklistItem = service.OpenWorklistItem(sn,this._Impersonator);
            if (worklistItem == null)
                throw new Exception("当前刻录不存在！");
            worklistItem.Service = service;
            return worklistItem;
        }

        public Worklist OpenWorklist()
        {
            var service = _ChannelFacotry.CreateChannel();
            var worklist=service.OpenWorklist(this._Impersonator);
            foreach(var item in worklist)
            {
                item.Service = service;
            }
            return worklist;
        }

        /// <summary>
        /// 设定当前用户
        /// </summary>
        /// <param name="impersonator"></param>
        public void ImpersonateUser(string impersonator)
        {
            this._Impersonator = impersonator;
        }



        public void Dispose()
        {
            if(_ChannelFacotry!=null)
            { 
                _ChannelFacotry.Close();
                _ChannelFacotry = null;
            }
        }
    }
}
