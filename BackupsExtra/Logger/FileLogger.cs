using System;
using System.IO;
using Serilog;
using Serilog.Sinks.File;

namespace BackupsExtra.Logger
{
    public class FileLogger : ILogger
    {
        public FileLogger(string path)
        {
            Path = path ?? throw new Exception("Path can't be null");
        }

        public string Path { get; }
        public void CreateLog(string message, bool activeTimeCode)
        {
            using var logger = new LoggerConfiguration()
                .WriteTo.File(Path, outputTemplate: "{Message}{NewLine}{Exception}")
                .CreateLogger();
            logger.Information(message);
        }
    }
}