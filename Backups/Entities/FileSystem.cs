using System.Collections.Generic;
using System.IO;

namespace Backups.Entities
{
    public class FileSystem
    {
        private List<DirectoryInfo> _pointDirectories;

        public FileSystem()
        {
            _pointDirectories = new List<DirectoryInfo>();
        }

        public IReadOnlyList<DirectoryInfo> PointDirectories => _pointDirectories;

        public DirectoryInfo AddRestorePointDirectory(string restorePointPath)
        {
            var directory = new DirectoryInfo(restorePointPath);
            if (!directory.Exists)
                directory.Create();
            _pointDirectories.Add(directory);
            return directory;
        }
    }
}