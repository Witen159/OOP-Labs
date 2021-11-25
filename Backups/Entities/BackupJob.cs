using System;
using System.IO;
using Backups.Interfaces;

namespace Backups.Entities
{
    public class BackupJob
    {
        private int _counter = 1;
        private DirectoryInfo _directory;
        private DirectoryInfo _jobDirectory;
        private string _directoryPath;
        public BackupJob(string rootPath, string repositoryName)
        {
            _directoryPath = $@"{rootPath}\{repositoryName}";
            _directory = new DirectoryInfo(_directoryPath);
            if (!_directory.Exists)
                _directory.Create();
            _jobDirectory = new DirectoryInfo($@"{_directoryPath}\Job objects");
            if (!_jobDirectory.Exists)
                _jobDirectory.Create();
        }

        public RestorePoint CreateRestorePoint(ISaveLocal localSave, ISaveVirtual virtualSave, string directoryPath, string pointName, StorageType type)
        {
            var restorePoint = new RestorePoint(pointName, type, _counter, directoryPath, localSave, virtualSave);
            _counter++;
            return restorePoint;
        }

        public void AddObject(string filePath)
        {
            var file = new FileInfo(filePath);
            if (file.Exists)
                file.CopyTo(@$"{_jobDirectory.FullName}\{file.Name}");
            else
                throw new Exception("File not exists");
        }

        public void DeleteObject(string objectName)
        {
            var obj = new FileInfo($@"{_jobDirectory}\{objectName}");
            if (obj.Exists)
                obj.Delete();
            else
                throw new Exception("Object not exists");
        }
    }
}