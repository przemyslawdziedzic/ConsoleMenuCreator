using System;

namespace ConsoleMenuCreator.ConsoleLogManager
{
    public static class ConsoleLogger
    {
        private static IEventLogManager _logger;

        private static IEventLogManager Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new DefaultEventLogger4Console();
                }
                return _logger;
            }
        }

        public static void Initialize(IEventLogManager logManager) => _logger = logManager;
        public static void Clear() => Logger.Clear();
        public static void Log(String logText, ConsoleLogLevel logLevel = ConsoleLogLevel.Information) => Logger.Log(logText, logLevel);
        public static void Log(String format, ConsoleLogLevel logLevel, params object[] arg) => Logger.Log(format, logLevel, arg);
    }
}