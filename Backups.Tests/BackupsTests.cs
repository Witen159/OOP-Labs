using System.IO;
using NUnit.Framework;

namespace Backups.Tests
{
    public class BackupsTests
    {
        // [Test]
        // public void Split()
        // {
        //     const string rootPath = @"C:\Users\User\source\repos\Programming_1\Witen159\Backups";
        //     const string directoryName = "TestDir";
        //     var backupJob = new BackupJob(rootPath, directoryName, StorageMethod.Split);
        //     
        //     const string addPath = @"C:\Users\User\source\repos\Programming_1\Witen159\Backups\FilesToAdd";
        //     backupJob.AddObject($@"{addPath}\test1.txt");
        //     backupJob.AddObject($@"{addPath}\test2.txt");
        //     
        //     backupJob.CreateRestorePoint();
        //     backupJob.DeleteObject("test2.txt");
        //     backupJob.CreateRestorePoint();
        //
        //     string directoryPath = $@"{rootPath}\{directoryName}";
        //     
        //     // Checking the existence of Restore Points.
        //     Assert.IsTrue(new DirectoryInfo($@"{directoryPath}\Restore Point 1").Exists);
        //     Assert.IsTrue(new DirectoryInfo($@"{directoryPath}\Restore Point 2").Exists);
        //     
        //     // Checking the existence of first and second storage.
        //     Assert.IsTrue(new FileInfo($@"{directoryPath}\Restore Point 1\File_test1_1.zip").Exists);
        //     Assert.IsTrue(new FileInfo($@"{directoryPath}\Restore Point 1\File_test2_1.zip").Exists);
        //     
        //     // Checking the existence of third and absence of fourth storage.
        //     Assert.IsTrue(new FileInfo($@"{directoryPath}\Restore Point 2\File_test1_2.zip").Exists);
        //     Assert.IsFalse(new FileInfo($@"{directoryPath}\Restore Point 2\File_test2_2.zip").Exists);
        //     
        //     Directory.Delete(directoryPath, true);
        // }

        // [Test]
        // public void Single()
        // {
        //     const string rootPath = @"C:\Users\User\source\repos\Programming_1\Witen159\Backups";
        //     const string directoryName = "TestDir";
        //     var backupJob = new BackupJob(rootPath, directoryName, StorageMethod.Single);
        //     
        //     const string addPath = @"C:\Users\User\source\repos\Programming_1\Witen159\Backups\FilesToAdd";
        //     backupJob.AddObject($@"{addPath}\test1.txt");
        //     backupJob.AddObject($@"{addPath}\test2.txt");
        //     
        //     backupJob.CreateRestorePoint();
        //     
        //     string directoryPath = $@"{rootPath}\{directoryName}";
        //     
        //     // Checking the existence of Restore Point.
        //     Assert.IsTrue(new DirectoryInfo($@"{directoryPath}\Restore Point 1").Exists);
        //     
        //     // Checking the existence of storage.
        //     Assert.IsTrue(new FileInfo($@"{directoryPath}\Restore Point 1\Files_1.zip").Exists);
        //     
        //     Directory.Delete(directoryPath, true);
        // }
    }
}