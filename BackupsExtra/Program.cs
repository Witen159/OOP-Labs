using System;
using System.IO;
using Backups.Entities;
using Backups.Interfaces;
using BackupsExtra.Logger;
using BackupsExtra.Recovery;
using Single = Backups.Entities.Single;

namespace BackupsExtra
{
    internal class Program
    {
        private static void Main()
        {
            var fileSystem = new FileSystem();
            IMethod single = new Single();
            IMethod split = new Split();
            ISaver local = new Local();
            ISaver virtualSaver = new Virtual();
            IBackupLogger logger = new ConsoleLogger();
            string dir = @"C:\Users\User\source\repos\backupTests";

            var backupJop = new BackupJobExtra(single, local, fileSystem, logger, true);

            // FileInfo file1 = splitBackupJop.AddObject(@"C:\Users\User\source\repos\FilesToAdd\test1.txt");
            // FileInfo file2 = splitBackupJop.AddObject(@"C:\Users\User\source\repos\FilesToAdd\test2.txt");
            //
            // RestorePoint restorePoint1 = splitBackupJop.CreateRestorePoint("Restore Point", dir);
            // splitBackupJop.DeleteObject(file2);
            // RestorePoint restorePoint2 = splitBackupJop.CreateRestorePoint("Restore Point", dir);
            //
            // splitBackupJop.Merge(restorePoint1, restorePoint2);
            FileInfo file1 = backupJop.AddObject(@"C:\Users\User\source\repos\FilesToAdd\test1.txt");
            RestorePoint restorePoint1 = backupJop.CreateRestorePoint("Restore Point", dir);
            backupJop.Recovery(restorePoint1, new DifferentLocationRecovery(@"C:\Users\User\source\repos\backupTests\Recovery"));
        }
    }
}
