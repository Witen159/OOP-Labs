using System.IO;
using Backups.Entities;
using Backups.Interfaces;
using NUnit.Framework;

namespace Backups.Tests
{
    public class BackupsTests
    {
        private ISaver localSaver = new Local();
        private ISaver virtualSaver = new Virtual();
        private FileSystem fileSystem = new FileSystem();
        private IMethod single = new Single();
        private IMethod split = new Split();
        private string dir = @"C:\Users\User\source\repos\backupTests";

        // Так как AddObject требует сущестования файла, который пытаются добавить, тесты на гитхабе невозможны, даже
        // для виртуального хранения
        
        // [Test]
        // public void SingleVirtualTest()
        // {
        //     var singleBackupJop = new BackupJob(single, fileSystem);
        //
        //     FileInfo file1 = singleBackupJop.AddObject(@"C:\Users\User\source\repos\FilesToAdd\test1.txt");
        //     FileInfo file2 = singleBackupJop.AddObject(@"C:\Users\User\source\repos\FilesToAdd\test2.txt");
        //
        //     RestorePoint restorePoint1 = singleBackupJop.CreateRestorePoint(virtualSaver, "Restore Point", dir);
        //     singleBackupJop.DeleteObject(file2);
        //     RestorePoint restorePoint2 = singleBackupJop.CreateRestorePoint(virtualSaver, "Restore Point", dir);
        //     
        //     Assert.AreEqual(restorePoint1.Repositories.Count, 1);
        //     Assert.AreEqual(restorePoint2.Repositories.Count, 1);
        //     
        //     Assert.AreEqual(restorePoint1.Repositories[0].Storages.Count, 2);
        //     Assert.AreEqual(restorePoint2.Repositories[0].Storages.Count, 1);
        // }
        //
        // [Test]
        // public void SplitVirtualTest()
        // {
        //     var splitBackupJop = new BackupJob(split, fileSystem);
        //
        //     FileInfo file1 = splitBackupJop.AddObject(@"C:\Users\User\source\repos\FilesToAdd\test1.txt");
        //     FileInfo file2 = splitBackupJop.AddObject(@"C:\Users\User\source\repos\FilesToAdd\test2.txt");
        //
        //     RestorePoint restorePoint1 = splitBackupJop.CreateRestorePoint(virtualSaver, "Restore Point", dir);
        //     splitBackupJop.DeleteObject(file2);
        //     RestorePoint restorePoint2 = splitBackupJop.CreateRestorePoint(virtualSaver, "Restore Point", dir);
        //     
        //     Assert.AreEqual(restorePoint1.Repositories.Count, 2);
        //     Assert.AreEqual(restorePoint2.Repositories.Count, 1);
        //     
        //     Assert.AreEqual(restorePoint1.Repositories[0].Storages.Count, 1);
        //     Assert.AreEqual(restorePoint1.Repositories[1].Storages.Count, 1);
        //     Assert.AreEqual(restorePoint2.Repositories[0].Storages.Count, 1);
        // }
    }
}