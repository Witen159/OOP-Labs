using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using Backups.Entities;
using Backups.Interfaces;
using BackupsExtra.Logger;
using BackupsExtra.Merge;
using BackupsExtra.Recovery;
using Newtonsoft.Json;
using Single = Backups.Entities.Single;

namespace BackupsExtra
{
    public class BackupJobExtra
    {
        private List<FileInfo> _jobObjects;
        private FileSystem _fileSystem;
        private List<RestorePoint> _restorePoints;
        private IMethod _method;
        private ISaver _saver;
        private IBackupLogger _logger;

        public BackupJobExtra(IMethod method, ISaver saver, FileSystem fileSystem, IBackupLogger logger, bool activeTimeCode)
        {
            _method = method ?? throw new Exception("Method cant be null");
            _saver = saver ?? throw new Exception("Saver cant be null");
            _fileSystem = fileSystem ?? throw new Exception("File system cant be null");
            _logger = logger ?? throw new Exception("Logger cant be null");
            _jobObjects = new List<FileInfo>();
            _restorePoints = new List<RestorePoint>();
            ActiveTimeCode = activeTimeCode;
        }

        public bool ActiveTimeCode { get; set; }
        public IReadOnlyList<RestorePoint> RestorePoints => _restorePoints;

        public FileInfo AddObject(string filePath)
        {
            var file = new FileInfo(filePath);
            if (!file.Exists)
                throw new Exception("File doesn't exist");
            _jobObjects.Add(file);
            _logger.CreateLog($"Add object {file.Name}", ActiveTimeCode);
            return file;
        }

        public void DeleteObject(FileInfo file)
        {
            if (!file.Exists)
                throw new Exception("No such object");
            _jobObjects.Remove(file);
            _logger.CreateLog($"Delete object {file.Name}", ActiveTimeCode);
        }

        public RestorePoint CreateRestorePoint(string restorePointName, string restorePointDirectoryPath)
        {
            var restorePoint = new RestorePoint(restorePointName, restorePointDirectoryPath);
            _restorePoints.Add(restorePoint);
            _method.Save(_saver, _jobObjects, restorePoint, _fileSystem);
            _logger.CreateLog($"Create Restore Point {restorePoint.Name} {restorePoint.Id}", ActiveTimeCode);
            return restorePoint;
        }

        public void Merge(RestorePoint oldRestorePoint, RestorePoint newRestorePoint)
        {
            IMerge merge = null;
            if (_saver is Local)
                merge = new LocalMerge();
            if (_saver is Virtual)
                merge = new VirtualMerge();

            merge.Merge(oldRestorePoint, newRestorePoint, _method);
            _logger.CreateLog($"Restore points {oldRestorePoint.Name} {oldRestorePoint.Id} and {newRestorePoint.Name} {newRestorePoint.Id} Merged", ActiveTimeCode);
            _restorePoints.Remove(oldRestorePoint);
        }

        public void Recovery(RestorePoint restorePoint, IRecovery recovery)
        {
            recovery.Recovery(restorePoint);
            _logger.CreateLog($"Restore Point {restorePoint.Name} {restorePoint.Id} recovered", ActiveTimeCode);
        }
    }
}