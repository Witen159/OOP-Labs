using Serilog;
using Serilog.Sinks.SystemConsole;

namespace BackupsExtra.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void CreateLog(string message, bool activeTimeCode)
        {
        }
    }
}