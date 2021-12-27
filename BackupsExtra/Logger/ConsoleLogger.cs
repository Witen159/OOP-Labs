using Serilog;
using Serilog.Sinks.SystemConsole;

namespace BackupsExtra.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void CreateLog(string message, bool activeTimeCode)
        {
            using var logger = new LoggerConfiguration()
                .WriteTo.Console(outputTemplate: "{Message}{NewLine}{Exception}")
                .CreateLogger();
            logger.Information(message);
        }
    }
}