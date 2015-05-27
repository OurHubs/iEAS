using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS.Log
{
    public abstract class BaseLogger:ILogger    
    {
        public abstract bool IsDebugEnabled { get; }

        public abstract bool IsErrorEnabled { get; }

        public abstract bool IsFatalEnabled { get; }

        public abstract bool IsInfoEnabled { get; }

        public abstract bool IsWarnEnabled { get; }
        public virtual void Debug(object message)
        {
            this.Message(LogType.DEBUG, message);
        }

        public virtual void Debug(object message, Exception exception)
        {
            this.Message(LogType.DEBUG, exception);
        }

        public virtual void DebugFormat(string format, params object[] args)
        {
            this.Message(LogType.DEBUG, format, args);
        }

        public virtual void Error(object message)
        {
            this.Message(LogType.ERROR, message);
        }

        public virtual void Error(object message, Exception exception)
        {
            this.Message(LogType.ERROR, exception);
        }

        public virtual void ErrorFormat(string format, params object[] args)
        {
            this.Message(LogType.ERROR, format, args);
        }

        public virtual void Fatal(object message)
        {
            this.Message(LogType.FATAL, message);
        }

        public virtual void Fatal(object message, Exception exception)
        {
            this.Message(LogType.FATAL, exception);
        }

        public virtual void FatalFormat(string format, params object[] args)
        {
            this.Message(LogType.FATAL, format, args);
        }

        public virtual void Info(object message)
        {
            this.Message(LogType.FATAL, message);
        }

        public virtual void Info(object message, Exception exception)
        {
            this.Message(LogType.INFO, exception);
        }

        public virtual void InfoFormat(string format, params object[] args)
        {
            this.Message(LogType.INFO, format, args);
        }

        public virtual void Warn(object message)
        {
            this.Message(LogType.WARN, message);
        }

        public virtual void Warn(object message, Exception exception)
        {
            this.Message(LogType.WARN, exception);
        }

        public virtual void WarnFormat(string format, params object[] args)
        {
            this.Message(LogType.WARN, format, args);
        }

        internal void Message(LogType type, string format, params object[] args)
        {
            string msg = String.Format(format, args);
            this.Message(type, msg);
        }

        internal void Message(LogType type, object message, Exception exception)
        {
            StringBuilder sbMsg = new StringBuilder(message + "");
            if (exception != null)
            {
                sbMsg.AppendLine();
                sbMsg.AppendFormat("Exception-Source:{0}", exception.Source);
                sbMsg.AppendLine();
                sbMsg.AppendFormat("Exception-Exception-Type:{0}", exception.GetType().FullName);
                sbMsg.AppendLine();
                sbMsg.AppendFormat("Exception-Message:{0}", exception.Message);
                sbMsg.AppendLine();
                sbMsg.AppendFormat("Exception-StackTrace:{0}", exception.StackTrace);
            }
            this.Message(type, sbMsg);
        }
        internal abstract void Message(LogType type, object message);
    }
}

