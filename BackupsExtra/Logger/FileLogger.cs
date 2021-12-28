using System;
using System.IO;
using Serilog;
using Serilog.Sinks.File;

namespace BackupsExtra.Logger
{
    public class FileLogger : IBackupLogger
    {
        public FileLogger(string path)
        {
            Path = path ?? throw new Exception("Path can't be null");
        }

        public string Path { get; }

        public void CreateLog(string message, bool activeTimeCode)
        {
            if (activeTimeCode)
            {
                var logger = new LoggerConfiguration()
                    .WriteTo.File(Path, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} {Message}{NewLine}{Exception}")
                    .CreateLogger();
                logger.Information(message);
            }
            else
            {
                var logger = new LoggerConfiguration()
                    .WriteTo.File(Path, outputTemplate: "{Message}{NewLine}{Exception}")
                    .CreateLogger();
                logger.Information(message);
            }
        }
    }
}