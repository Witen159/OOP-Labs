using System.Collections.Generic;
using Backups.Entities;

namespace BackupsExtra.Cleaner
{
    public interface ICleaner
    {
        void Clean(List<RestorePoint> restorePoints, BackupJobExtra backupJob);
    }
}