using System;
using System.Collections.Generic;
using System.IO;
using Backups.Interfaces;

namespace Backups.Entities
{
    public class BackupJob
    {
        private List<FileInfo> _jobObjects;
        private FileSystem _fileSystem;
        private List<RestorePoint> _restorePoints;
        private IMethod _method;
        public BackupJob(IMethod method, FileSystem fileSystem)
        {
            _method = method ?? throw new Exception("Method is null");
            _fileSystem = fileSystem ?? throw new Exception("File system is null");
            _jobObjects = new List<FileInfo>();
            _restorePoints = new List<RestorePoint>();
        }

        public IReadOnlyList<RestorePoint> RestorePoints => _restorePoints;

        public RestorePoint CreateRestorePoint(ISaver saver, string restorePointName, string restorePointDirectoryPath)
        {
            var restorePoint = new RestorePoint(restorePointName, restorePointDirectoryPath, DateTime.Now);
            _restorePoints.Add(restorePoint);
            _method.Save(saver, _jobObjects, restorePoint, _fileSystem);
            return restorePoint;
        }

        public FileInfo AddObject(string filePath)
        {
            var file = new FileInfo(filePath);
            if (!file.Exists)
                throw new Exception("File doesn't exist");
            _jobObjects.Add(file);
            return file;
        }

        public void DeleteObject(FileInfo file)
        {
            if (!file.Exists)
                throw new Exception("No such object");
            _jobObjects.Remove(file);
        }
    }
}