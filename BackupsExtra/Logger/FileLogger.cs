using System;
using System.IO;
using BackupsExtra.Tools;
using Serilog;
using Serilog.Sinks.File;

namespace BackupsExtra.Logger
{
    public class FileLogger : IBackupLogger
    {
        public FileLogger(string path)
        {
            Path = path ?? throw new BackupExtraException("Path can't be null");
        }

        public string Path { get; }

        public void CreateLog(string message, bool activeTimeCode)
        {
            if (activeTimeCode)
            {
                using var logger = new LoggerConfiguration()
                    .WriteTo.File(Path, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} {Message}{NewLine}{Exception}")
                    .CreateLogger();
                logger.Information(message);
            }
            else
            {
                using var logger = new LoggerConfiguration()
                    .WriteTo.File(Path, outputTemplate: "{Message}{NewLine}{Exception}")
                    .CreateLogger();
                logger.Information(message);
            }
        }
    }
}