using System;

namespace ConsoleMenuCreator.ConsoleLogManager
{
    public interface IEventLogManager
    {
        void Clear();
        void Log(String logText, ConsoleLogLevel logLevel = ConsoleLogLevel.Information);
        void Log(String format, ConsoleLogLevel logLevel, params object[] arg);
    }
}
