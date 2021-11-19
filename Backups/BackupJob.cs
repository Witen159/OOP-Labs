using System;
using System.IO;
using System.Linq;

namespace Backups
{
    public class BackupJob
    {
        private int _counter = 1;
        private DirectoryInfo _directory;
        private DirectoryInfo _jobDirectory;
        private StorageMethod _storageMethod;
        private string _directoryPath;
        public BackupJob(string rootPath, string repositoryName, StorageMethod storageMethod)
        {
            _directoryPath = $@"{rootPath}\{repositoryName}";
            _directory = new DirectoryInfo(_directoryPath);
            if (!_directory.Exists)
                _directory.Create();
            _jobDirectory = new DirectoryInfo($@"{_directoryPath}\Job objects");
            if (!_jobDirectory.Exists)
                _jobDirectory.Create();
            _storageMethod = storageMethod;
        }

        public RestorePoint CreateRestorePoint()
        {
            var restorePoint = new RestorePoint(_storageMethod, _counter, _directoryPath);
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