using iEAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS.Log
{
    public class DBLogger:BaseLogger,ILogger
    {
        public override bool IsDebugEnabled
        {
            get { return true; }
        }

        public override bool IsErrorEnabled
        {
            get { return true; }
        }

        public override bool IsFatalEnabled
        {
            get { return true; }
        }

        public override bool IsInfoEnabled
        {
            get { return true; }
        }

        public override bool IsWarnEnabled
        {
            get { return true; }
        }

        internal override void Message(LogType type, object message)
        {
            string str = (message ?? "").ToString();

            var log = new LogInfo
            {
                Type = type.ToString(),
                //ModuleCode = AppContext.Current.Module.Code,
                //ModuleName = AppContext.Current.Module.Name,
                Message = str,
                Creator = AppContext.Current.User.Name,
                CreateTime = DateTime.Now
            };
            try
            {
                ObjectContainer.GetService<IDomainService>()
                    .Execute<FrameworkRepository>(rep => rep.Create(log));
            }
            catch(Exception ex)
            {
                ILogger fileLogger = ObjectContainer.GetService<ILogger>("filelog");
                fileLogger.Error("DBLogger Error", ex);
                switch (type)
                {
                    case LogType.INFO:
                        fileLogger.Info(message);
                        break;
                    case LogType.WARN:
                        fileLogger.Warn(message);
                        break;
                    case LogType.DEBUG:
                        fileLogger.Debug(message);
                        break;
                    case LogType.FATAL:
                        fileLogger.Fatal(message);
                        break;
                    case LogType.ERROR:
                        fileLogger.Error(message);
                        break;
                }
            }
        }
    }
}
