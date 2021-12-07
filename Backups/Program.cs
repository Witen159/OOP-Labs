using System.IO;
using Backups.Entities;
using Backups.Interfaces;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            // Local tests
            ISaver localSaver = new Local();
            var fileSystem = new FileSystem();
            IMethod single = new Single();
            IMethod split = new Split();
            string dir = @"C:\Users\User\source\repos\backupTests";

            var singleBackupJop = new BackupJob(single, fileSystem);

            FileInfo file1 = singleBackupJop.AddObject(@"C:\Users\User\source\repos\FilesToAdd\test1.txt");
            FileInfo file2 = singleBackupJop.AddObject(@"C:\Users\User\source\repos\FilesToAdd\test2.txt");

            RestorePoint restorePoint1 = singleBackupJop.CreateRestorePoint(localSaver, "Restore Point", dir);
            singleBackupJop.DeleteObject(file2);
            RestorePoint restorePoint2 = singleBackupJop.CreateRestorePoint(localSaver, "Restore Point", dir);
        }
    }
}
