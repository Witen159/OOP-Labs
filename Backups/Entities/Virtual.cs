using System.Collections.Generic;
using Backups.Interfaces;

namespace Backups.Entities
{
    public class Virtual : ISaver
    {
        public void Save(List<Repository> repositories, RestorePoint restorePoint, FileSystem fileSystem)
        {
            throw new System.NotImplementedException();
        }
    }
}