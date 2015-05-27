using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS
{
    public interface ILogger
    {
        bool IsDebugEnabled { get; }

        bool IsErrorEnabled { get; }

        bool IsFatalEnabled { get; }

        bool IsInfoEnabled { get; }

        bool IsWarnEnabled { get; }
        /// <summary>
        /// 记录Debug信息
        /// </summary>
        /// <param name="message"></param>
        void Debug(object message);
        /// <summary>
        /// 记录Debug信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Debug(object message, Exception exception);
        /// <summary>
        /// 记录Debug信息
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void DebugFormat(string format, params object[] args);
        /// <summary>
        /// 记录Error信息
        /// </summary>
        /// <param name="message"></param>
        void Error(object message);
        /// <summary>
        /// 记录Error信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Error(object message, Exception exception);
        /// <summary>
        /// 记录Error信息
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void ErrorFormat(string format, params object[] args);
        /// <summary>
        /// 记录Fatal信息
        /// </summary>
        /// <param name="message"></param>
        void Fatal(object message);
        /// <summary>
        /// 记录Fatal信息
        /// </summary>
        /// <param name="message"></param>
        void Fatal(object message, Exception exception);
        /// <summary>
        /// 记录Fatal信息
        /// </summary>
        /// <param name="message"></param>
        void FatalFormat(string format, params object[] args);
        /// <summary>
        /// 记录Info信息
        /// </summary>
        /// <param name="message"></param>
        void Info(object message);
        /// <summary>
        /// 记录Info信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Info(object message, Exception exception);
        /// <summary>
        /// 记录Info信息
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        void InfoFormat(string format, params object[] args);
        /// <summary>
        /// 记录Warn信息
        /// </summary>
        /// <param name="message"></param>
        void Warn(object message);
        /// <summary>
        /// 记录Warn信息
        /// </summary>
        /// <param name="message"></param>
        void Warn(object message, Exception exception);
        /// <summary>
        /// 记录Warn信息
        /// </summary>
        /// <param name="message"></param>
        void WarnFormat(string format, params object[] args);
    }
}
