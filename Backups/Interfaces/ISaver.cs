using System.Collections.Generic;
using Backups.Entities;

namespace Backups.Interfaces
{
    public interface ISaver
    {
        void Save(List<Repository> repositories, RestorePoint restorePoint, FileSystem fileSystem);
    }
}