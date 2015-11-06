using System;
using System.Diagnostics;
using System.IO;
using log4net;
using log4net.Config;

namespace PvaLibrary
{
    public class Logger
    {
        private volatile static ILog _logger;
        private static readonly bool LogMethodNames;

        static Logger()
        {
            GlobalContext.Properties["date"] = DateTime.Now.ToString("yyyy_MM");//_dd__hh_mm");
            GlobalContext.Properties["pid"] = Process.GetCurrentProcess().Id;
            GlobalContext.Properties["fname"] = new FileInfo(Process.GetCurrentProcess().MainModule.FileName).Name;

            XmlConfigurator.Configure();
            _logger = LogManager.GetLogger(new FileInfo(Process.GetCurrentProcess().MainModule.FileName).Name);

            LogMethodNames = true;
        }

        private static string GetSourceClassAndMethodName()
        {
            if (!LogMethodNames)
                return "";
            var stackTrace = new StackTrace();
            var stackFrame = stackTrace.GetFrame(2);
            var methodBase = stackFrame.GetMethod();
            var sourceFunctionName = methodBase.Name;
            if (methodBase.DeclaringType != null)
            {
                var sourceClassName = methodBase.DeclaringType.Name;
                return sourceClassName + "->" + sourceFunctionName + "()->";
            }
            return "";
        }

        public static void Info(string msg)
        {
            _logger.Info(GetSourceClassAndMethodName() + msg);
        }

        public static void Warning(string msg)
        {
            _logger.Warn(msg);
        }

        public static void Error(string msg)
        {
            _logger.Error(GetSourceClassAndMethodName() + msg, null);
        }

        public static void Error(Exception ex)
        {
            _logger.Error(ex.ToString());
        }

        public static void Error(string msg, Exception ex)
        {
            _logger.Error(GetSourceClassAndMethodName() + msg, ex);
        }

        public static void Debug(string msg)
        {
            _logger.Debug(GetSourceClassAndMethodName() + msg);
        }

        public static void Fatal(string msg)
        {
            _logger.Fatal(GetSourceClassAndMethodName() + msg);
            throw new ApplicationException(msg);
        }

        public static void Fatal(string msg, Exception ex)
        {
            _logger.Fatal(GetSourceClassAndMethodName() + msg, ex);
            throw new ApplicationException(msg);
        }
    }
}
