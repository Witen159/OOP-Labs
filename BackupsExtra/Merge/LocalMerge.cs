using System.IO;
using System.IO.Compression;
using Backups.Entities;
using Backups.Interfaces;

namespace BackupsExtra.Merge
{
    public class LocalMerge : IMerge
    {
        public void Merge(RestorePoint oldRestorePoint, RestorePoint newRestorePoint, IMethod method)
        {
            int count = newRestorePoint.Repositories.Count + 1;
            foreach (Repository oldRepository in oldRestorePoint.Repositories)
            {
                bool inBoth = false;
                foreach (Repository newRepository in newRestorePoint.Repositories)
                {
                    if (newRepository.Storages[0].Name == oldRepository.Storages[0].Name)
                    {
                        inBoth = true;
                        break;
                    }
                }

                if (!inBoth)
                {
                    var tempDir = new DirectoryInfo(Path.Combine(newRestorePoint.DirectoryPath, "TempDir"));
                    tempDir.Create();

                    foreach (FileInfo file in oldRepository.Storages)
                    {
                        file.CopyTo(Path.Combine(tempDir.FullName, file.Name), true);
                    }

                    ZipFile.CreateFromDirectory(tempDir.FullName, Path.Combine(newRestorePoint.PointDirectoryPath, $"Files_{count}.zip"));
                    count++;

                    tempDir.Delete(true);
                    newRestorePoint.AddRepository(oldRepository);
                }
            }
        }
    }
}