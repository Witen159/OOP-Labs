using System.Collections.Generic;
using System.IO;
using Backups.Entities;

namespace BackupsExtra.Cleaner
{
    public class LocalCleaner : ICleaner
    {
        public void Clean(List<RestorePoint> restorePoints, BackupJobExtra backupJob)
        {
            foreach (RestorePoint restorePoint in restorePoints)
            {
                var restorePointDirectory = new DirectoryInfo(restorePoint.PointDirectoryPath);
                restorePointDirectory.Delete(true);
                backupJob.RemoveRestorePoint(restorePoint);
            }
        }
    }
}