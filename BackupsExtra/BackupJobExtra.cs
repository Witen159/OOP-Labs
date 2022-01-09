using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Backups.Entities;
using Backups.Interfaces;
using BackupsExtra.Cleaner;
using BackupsExtra.Clearing;
using BackupsExtra.Logger;
using BackupsExtra.Merge;
using BackupsExtra.Recovery;
using BackupsExtra.Tools;
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
        private IClearing _clearing;
        private IMerge _merge;
        private ICleaner _cleaner;

        public BackupJobExtra(IMethod method, Save.Save save, FileSystem fileSystem, IBackupLogger logger, IClearing clearing, bool activeTimeCode)
        {
            _method = method ?? throw new BackupExtraException("Method cant be null");
            _saver = save.Saver ?? throw new BackupExtraException("Saver cant be null");
            _cleaner = save.Cleaner ?? throw new BackupExtraException("Cleaner cant be null");
            _merge = save.Merge ?? throw new BackupExtraException("Merge cant be null");
            _fileSystem = fileSystem ?? throw new BackupExtraException("File system cant be null");
            _logger = logger ?? throw new BackupExtraException("Logger cant be null");
            _clearing = clearing ?? throw new BackupExtraException("Clearing method cant be null");
            _jobObjects = new List<FileInfo>();
            _restorePoints = new List<RestorePoint>();
            ActiveTimeCode = activeTimeCode;
        }

        public bool ActiveTimeCode { get; set; }
        public IReadOnlyList<RestorePoint> RestorePoints => _restorePoints;

        public FileInfo AddObject(string filePath)
        {
            var file = new FileInfo(filePath);
            _jobObjects.Add(file);
            _logger.CreateLog($"Add object {file.Name}", ActiveTimeCode);
            return file;
        }

        public void DeleteObject(FileInfo file)
        {
            if (!_jobObjects.Contains(file))
                throw new BackupExtraException("No such object");
            _jobObjects.Remove(file);
            _logger.CreateLog($"Delete object {file.Name}", ActiveTimeCode);
        }

        public RestorePoint CreateRestorePoint(string restorePointName, string restorePointDirectoryPath)
        {
            var restorePoint = new RestorePoint(restorePointName, restorePointDirectoryPath);
            _restorePoints.Add(restorePoint);
            _method.Save(_saver, _jobObjects, restorePoint, _fileSystem);
            _logger.CreateLog($"Create Restore Point ({restorePoint.Name} {restorePoint.Id})", ActiveTimeCode);
            CleanRestorePoints();
            return restorePoint;
        }

        public void Merge(RestorePoint oldRestorePoint, RestorePoint newRestorePoint)
        {
            if (_method is Single)
            {
                _cleaner.Clean(new List<RestorePoint>() { oldRestorePoint }, this);
                return;
            }

            _merge.Merge(oldRestorePoint, newRestorePoint, _method);
            _logger.CreateLog($"Restore points ({oldRestorePoint.Name} {oldRestorePoint.Id}) and ({newRestorePoint.Name} {newRestorePoint.Id}) Merged", ActiveTimeCode);
            _restorePoints.Remove(oldRestorePoint);
        }

        public void Recovery(RestorePoint restorePoint, IRecovery recovery)
        {
            recovery.Recovery(restorePoint);
            _logger.CreateLog($"Restore Point ({restorePoint.Name} {restorePoint.Id}) recovered", ActiveTimeCode);
        }

        public void CleanRestorePoints()
        {
            List<RestorePoint> pointsToClean = _clearing.Clearing(RestorePoints.ToList());
            if (pointsToClean.Count == 0)
                return;
            if (pointsToClean == _restorePoints)
                throw new BackupExtraException("Cleaning all points");

            _cleaner.Clean(pointsToClean, this);
            _logger.CreateLog($"Restore points cleaned", ActiveTimeCode);
        }

        public void ChangeCleaningMethod(IClearing clearing)
        {
            _clearing = clearing ?? throw new BackupExtraException("Clearing method cant be null");
            _logger.CreateLog($"Cleaning method changed", ActiveTimeCode);
        }

        public void RemoveRestorePoint(RestorePoint restorePoint)
        {
            _restorePoints.Remove(restorePoint);
            _logger.CreateLog($"Restore point ({restorePoint.Name} {restorePoint.Id}) removed", ActiveTimeCode);
        }
    }
}