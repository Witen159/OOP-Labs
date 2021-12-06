using System.Collections.Generic;
using System.IO;
using Backups.Interfaces;

namespace Backups.Entities
{
    public class Split : IMethod
    {
        public void Save(ISaver saver, List<FileInfo> files, RestorePoint restorePoint, FileSystem fileSystem)
        {
            var repositories = new List<Repository>();
            foreach (FileInfo file in files)
            {
                var repository = new Repository();
                repository.AddStorages(new List<FileInfo>() { file });
                repositories.Add(repository);
            }

            saver.Save(repositories, restorePoint, fileSystem);
        }
    }
}