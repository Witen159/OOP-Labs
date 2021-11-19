using System.IO;

namespace Backups
{
    public class BackupJob
    {
        // private int _counter = 1;
        private DirectoryInfo _directory;
        private StorageMethod _storageMethod;
        public BackupJob(string rootPath, string repositoryName, StorageMethod storageMethod)
        {
            _directory = new DirectoryInfo($@"{rootPath}\{repositoryName}");
            if (!_directory.Exists)
                _directory.Create();
            var subDirectory = new DirectoryInfo($@"{_directory.FullName}\Job objects");
            if (!subDirectory.Exists)
                _directory.CreateSubdirectory(subDirectory.FullName);
            _storageMethod = storageMethod;
        }

        public void CreateRestorePoint()
        {
            if (_storageMethod == StorageMethod.Single)
            {
            }
            else if (_storageMethod == StorageMethod.Split)
            {
            }
        }
    }
}