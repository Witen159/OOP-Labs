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
                var tempDir = new DirectoryInfo(Path.Combine(restorePoint.DirectoryPath, "TempDir"));
                tempDir.Create();

                foreach (FileInfo file in repository.Storages)
                {
                    file.CopyTo(Path.Combine(tempDir.FullName, file.Name), true);
                }

                ZipFile.CreateFromDirectory(tempDir.FullName, Path.Combine(pointDir.FullName, $"Files_{count}.zip"));
                count++;

                tempDir.Delete(true);
                restorePoint.AddRepository(repository);
            }
        }
    }
}