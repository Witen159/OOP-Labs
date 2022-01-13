using Serilog;
using Serilog.Sinks.SystemConsole;

namespace BackupsExtra.Logger
{
    public class ConsoleLogger : IBackupLogger
    {
        public ConsoleLogger()
        {
            Logger = new LoggerConfiguration();
        }

        public LoggerConfiguration Logger { get; }
        public void CreateLog(string message, bool activeTimeCode)
        {
            string template = activeTimeCode ? "{Timestamp:yyyy-MM-dd HH:mm:ss} {Message}{NewLine}{Exception}" : "{Message}{NewLine}{Exception}";

            using Serilog.Core.Logger logger = new LoggerConfiguration()
                .WriteTo.Console(outputTemplate: template)
                .CreateLogger();
            logger.Information(message);
        }
    }
}