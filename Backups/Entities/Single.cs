using System.Collections.Generic;
using System.IO;
using Backups.Interfaces;

namespace Backups.Entities
{
    public class Single : IMethod
    {
        public void Save(ISaver saver, List<FileInfo> files, RestorePoint restorePoint, FileSystem fileSystem)
        {
            var repository = new Repository();
            repository.AddStorages(files);

            saver.Save(new List<Repository>() { repository }, restorePoint, fileSystem);
        }
    }
}