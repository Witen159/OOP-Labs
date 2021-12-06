using System.Collections.Generic;
using System.IO;

namespace Backups.Entities
{
    public class FileSystem
    {
        private List<DirectoryInfo> _restorePointDirectories;

        public FileSystem(string rootPath)
        {
            RootPath = rootPath;
            _restorePointDirectories = new List<DirectoryInfo>();
        }

        public string RootPath { get; }
        public IReadOnlyList<DirectoryInfo> RestorePointDirectories => _restorePointDirectories;

        public DirectoryInfo AddRestorePointDirectory(string restorePointPath)
        {
            var directory = new DirectoryInfo(restorePointPath);
            if (!directory.Exists)
                directory.Create();
            _restorePointDirectories.Add(directory);
            return directory;
        }
    }
}