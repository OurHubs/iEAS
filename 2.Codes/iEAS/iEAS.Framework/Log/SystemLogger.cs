using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS.Log
{
    public class SystemLogger:BaseLogger,ILogger
    {

        private readonly IEnumerable<ILogger> _Loggers;

        public SystemLogger()
        {
            var loggers = new List<ILogger>();
            if(IsDBLoggerEnabled)
            {
                //loggers.Add(LogManager.GetDBLogger());
            }
            if (IsFileLoggerEnabled)
            {
                //loggers.Add(LogManager.GetFileLogger());
            }
            _Loggers = loggers;
        }

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

        public bool IsFileLoggerEnabled
        {
            get { return true; }
        }

        public bool IsDBLoggerEnabled
        {
            get { return true; }
        }

        internal override void Message(LogType type, object message)
        {
            foreach (var logger in _Loggers)
            {
                switch (type)
                {
                    case LogType.INFO:
                            logger.Info(message);
                        break;
                    case LogType.WARN:
                            logger.Warn(message);
                        break;
                    case LogType.DEBUG:
                            logger.Debug(message);
                        break;
                    case LogType.FATAL:
                            logger.Fatal(message);
                        break;
                    case LogType.ERROR:
                            logger.Error(message);
                        break;
                }
            }
        }
    }
}
