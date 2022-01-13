using System.Collections.Generic;
using Backups.Entities;

namespace BackupsExtra.Cleaner
{
    public class VirtualCleaner : ICleaner
    {
        public void Clean(List<RestorePoint> restorePoints, BackupJobExtra backupJob)
        {
            foreach (RestorePoint restorePoint in restorePoints)
            {
                backupJob.RemoveRestorePoint(restorePoint);
            }
        }
    }
}