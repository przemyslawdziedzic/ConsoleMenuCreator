using System;

namespace ConsoleMenuCreator.ConsoleLogManager
{
    internal class DefaultEventLogger4Console : IEventLogManager
    {
        public void Log(String logText, ConsoleLogLevel logLevel = ConsoleLogLevel.Information)
        {
            SetConsoleColor(logLevel);
            Console.WriteLine(logText);
            Console.ResetColor();
        }

        public void Log(String format, ConsoleLogLevel logLevel, params object[] arg)
        {
            SetConsoleColor(logLevel);
            Console.WriteLine(format, arg);
            Console.ResetColor();
        }

        private void SetConsoleColor(ConsoleLogLevel logLevel)
        {
            switch (logLevel)
            {
                case ConsoleLogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case ConsoleLogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case ConsoleLogLevel.Information:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case ConsoleLogLevel.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case ConsoleLogLevel.Highlighted:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
            }
        }

        public void Clear() => Console.Clear();
    }
}