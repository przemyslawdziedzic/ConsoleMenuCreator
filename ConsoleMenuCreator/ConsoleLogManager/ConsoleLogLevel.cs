using System.ComponentModel;

namespace ConsoleMenuCreator.ConsoleLogManager
{
    public enum ConsoleLogLevel
    {
        [Description("Error")]
        Error,
        [Description("Warning")]
        Warning,
        [Description("Information")]
        Information,
        [Description("Highlighted")]
        Highlighted,
        [Description("Success")]
        Success
    }
}