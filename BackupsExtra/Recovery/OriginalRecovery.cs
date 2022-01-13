using System;
using System.IO;
using Backups.Entities;

namespace BackupsExtra.Recovery
{
    public class OriginalRecovery : IRecovery
    {
        public void Recovery(RestorePoint restorePoint)
        {
            foreach (Repository repository in restorePoint.Repositories)
            {
                foreach (FileInfo storage in repository.Storages)
                {
                    storage.Create();
                }
            }
        }
    }
}