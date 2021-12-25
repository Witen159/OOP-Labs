using System.Collections.Generic;
using System.IO;
using Backups.Interfaces;

namespace Backups.Entities
{
    public class Virtual : ISaver
    {
        public void Save(List<Repository> repositories, RestorePoint restorePoint, FileSystem fileSystem)
        {
            foreach (Repository repository in repositories)
            {
                restorePoint.AddRepository(repository);
            }
        }
    }
}