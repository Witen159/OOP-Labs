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
        private IBackupLogger _logger;

        public BackupJobExtra(IMethod method, FileSystem fileSystem, IBackupLogger logger)
            : base(method, fileSystem)
        {
            _method = method ?? throw new Exception("Method cant be null");
            _fileSystem = fileSystem ?? throw new Exception("File system cant be null");
            _logger = logger ?? throw new Exception("Logger cant be null");
            _jobObjects = new List<FileInfo>();
            _restorePoints = new List<RestorePoint>();
        }

        public void ChangeLogger(IBackupLogger logger)
        {
            _logger = logger ?? throw new Exception("Logger is null");
        }

        public FileInfo AddObject(string filePath, bool activeTimeCode)
        {
            var file = new FileInfo(filePath);
            if (!file.Exists)
                throw new Exception("File doesn't exist");
            _jobObjects.Add(file);
            _logger.CreateLog($"Add object {file.Name}", activeTimeCode);
            return file;
        }

        public void DeleteObject(FileInfo file, bool activeTimeCode)
        {
            if (!file.Exists)
                throw new Exception("No such object");
            _jobObjects.Remove(file);
            _logger.CreateLog($"Delete object {file.Name}", activeTimeCode);
        }

        public RestorePoint CreateRestorePoint(ISaver saver, string restorePointName, string restorePointDirectoryPath, bool activeTimeCode)
        {
            var restorePoint = new RestorePoint(restorePointName, restorePointDirectoryPath);
            _restorePoints.Add(restorePoint);
            _method.Save(saver, _jobObjects, restorePoint, _fileSystem);
            _logger.CreateLog($"Create Restore Point {restorePointName}", activeTimeCode);
            return restorePoint;
        }
    }
}