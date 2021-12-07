using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Backups.Interfaces;

namespace Backups.Entities
{
    public class Local : ISaver
    {
        public void Save(List<Repository> repositories, RestorePoint restorePoint, FileSystem fileSystem)
        {
            DirectoryInfo pointDir =
                fileSystem.AddRestorePointDirectory(restorePoint.PointDirectoryPath);
            int count = 1;
            foreach (Repository repository in repositories)
            {
                var tempDir = new DirectoryInfo(@$"{restorePoint.DirectoryPath}\TempDir");
                tempDir.Create();

                foreach (FileInfo file in repository.Storages)
                {
                    file.CopyTo(@$"{tempDir.FullName}\{file.Name}", true);
                }

                ZipFile.CreateFromDirectory(tempDir.FullName, @$"{pointDir.FullName}/Files_{count}.zip");
                count++;

                tempDir.Delete(true);
                restorePoint.AddRepository(repository);
            }
        }
    }
}