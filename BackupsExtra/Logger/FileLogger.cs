using Serilog;
using Serilog.Sinks.File;

namespace BackupsExtra.Logger
{
    public class FileLogger : ILogger
    {
        public void CreateLog(string message, bool activeTimeCode)
        {
        }
    }
}