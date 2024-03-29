﻿using System.IO;
using System.Linq;
using Backups.Entities;
using Backups.Interfaces;
using BackupsExtra.Clearing;
using BackupsExtra.Logger;
using BackupsExtra.Save;
using NUnit.Framework;
using Single = Backups.Entities.Single;

namespace BackupsExtra.Tests
{
    public class BackupExtraTests
    {
        private FileSystem _fileSystem = new FileSystem();
        private IMethod _single = new Single();
        private IMethod _split = new Split();
        private Save.Save _virtualSAve = new VirtualSave();
        private IBackupLogger _logger = new ConsoleLogger();
        private IClearing _clearing = new QuantityClearing(2);
        private string _dir = @"Witen159\BackupsExtra.Tests\Tests";
        
        [Test]
        public void VirtualMerge()
        {
            var backupJop = new BackupJobExtra(_split, _virtualSAve, _fileSystem, _logger, _clearing, true);
        
            FileInfo file1 = backupJop.AddObject(@"Witen159\BackupsExtra.Tests\FilesForTests\test1.txt");
            FileInfo file2 = backupJop.AddObject(@"Witen159\BackupsExtra.Tests\FilesForTests\test2.txt");
            
            RestorePoint restorePoint1 = backupJop.CreateRestorePoint("Restore Point", _dir);
            backupJop.DeleteObject(file2);
            RestorePoint restorePoint2 = backupJop.CreateRestorePoint("Restore Point", _dir);
            
            backupJop.Merge(restorePoint1, restorePoint2);
        
            Assert.AreEqual(backupJop.RestorePoints.Count, 1);
            Assert.AreEqual(restorePoint2.Repositories.Count, 2);
            Assert.Contains(restorePoint2, backupJop.RestorePoints.ToList());
        }
        
        [Test]
        public void RestorePointCleaning()
        {
            IClearing clearing = new QuantityClearing(2); // Все рестор поинты кроме 2-х последних удаляются
            
            var backupJop = new BackupJobExtra(_split, _virtualSAve, _fileSystem, _logger, clearing, true);
            
            FileInfo file1 = backupJop.AddObject(@"Witen159\BackupsExtra.Tests\FilesForTests\test1.txt");
            
            RestorePoint restorePoint1 = backupJop.CreateRestorePoint("Restore Point", _dir);
            RestorePoint restorePoint2 = backupJop.CreateRestorePoint("Restore Point", _dir);
            RestorePoint restorePoint3 = backupJop.CreateRestorePoint("Restore Point", _dir);
            RestorePoint restorePoint4 = backupJop.CreateRestorePoint("Restore Point", _dir);
            
            Assert.AreEqual(backupJop.RestorePoints.Count, 2);
            Assert.Contains(restorePoint3, backupJop.RestorePoints.ToList());
            Assert.Contains(restorePoint4, backupJop.RestorePoints.ToList());
        }
    }
}