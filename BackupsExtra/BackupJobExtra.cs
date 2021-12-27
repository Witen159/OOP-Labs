using System;
using System.Collections.Generic;
using System.IO;
using Backups.Entities;
using Backups.Interfaces;
using BackupsExtra.Logger;

namespace BackupsExtra
{
    public class BackupJobExtra : BackupJob
    {
        private List<FileInfo> _jobObjects;
        private FileSystem _fileSystem;
        private List<RestorePoint> _restorePoints;
        private IMethod _method;
        private ILogger _logger;

        public BackupJobExtra(IMethod method, FileSystem fileSystem, ILogger logger)
            : base(method, fileSystem)
        {
            _method = method ?? throw new Exception("Method is null");
            _fileSystem = fileSystem ?? throw new Exception("File system is null");
            _logger = logger ?? throw new Exception("Logger is null");
            _jobObjects = new List<FileInfo>();
            _restorePoints = new List<RestorePoint>();
        }

        public void ChangeLogger(ILogger logger)
        {
            _logger = logger ?? throw new Exception("Logger is null");
        }
    }
}