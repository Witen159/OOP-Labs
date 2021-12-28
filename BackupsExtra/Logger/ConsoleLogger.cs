using Serilog;
using Serilog.Sinks.SystemConsole;

namespace BackupsExtra.Logger
{
    public class ConsoleLogger : IBackupLogger
    {
        public void CreateLog(string message, bool activeTimeCode)
        {
            if (activeTimeCode)
            {
                using var logger = new LoggerConfiguration()
                    .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} {Message}{NewLine}{Exception}")
                    .CreateLogger();
                logger.Information(message);
            }
            else
            {
                using var logger = new LoggerConfiguration()
                    .WriteTo.Console(outputTemplate: "{Message}{NewLine}{Exception}")
                    .CreateLogger();
                logger.Information(message);
            }
        }
    }
}