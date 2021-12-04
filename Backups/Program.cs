using System.IO;
using Backups.Entities;
using Backups.Interfaces;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            var backupJob = new BackupJob(@"C:\Users\User\source\repos\Programming_1\Witen159\Backups", "TestDir");
            ISaveLocal saveLocal = new LocalSplit();
            ISaveVirtual saveVirtual = new VirtualSplit();
            backupJob.CreateRestorePoint(saveLocal, saveVirtual, "Restore point", StorageType.Local);
            const string addPath = @"C:\Users\User\source\repos\Programming_1\Witen159\Backups\FilesToAdd";
            backupJob.AddObject($@"{addPath}\test1.txt");
            backupJob.AddObject($@"{addPath}\test2.txt");
            backupJob.CreateRestorePoint(saveLocal, saveVirtual, "Restore point", StorageType.Local);

            // backupJob.CreateRestorePoint();
        }
    }
}
