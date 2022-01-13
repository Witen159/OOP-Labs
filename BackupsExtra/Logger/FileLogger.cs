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
            Logger = new LoggerConfiguration();
        }

        public string Path { get; }
        public LoggerConfiguration Logger { get; }

        public void CreateLog(string message, bool activeTimeCode)
        {
            string template = activeTimeCode ? "{Timestamp:yyyy-MM-dd HH:mm:ss} {Message}{NewLine}{Exception}" : "{Message}{NewLine}{Exception}";

            using Serilog.Core.Logger logger = Logger.WriteTo.File(Path, outputTemplate: template)
                .CreateLogger();
            logger.Information(message);
        }
    }
}