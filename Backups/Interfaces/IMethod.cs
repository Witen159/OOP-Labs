using System.Collections.Generic;
using System.IO;
using Backups.Entities;

namespace Backups.Interfaces
{
    public interface IMethod
    {
        void Save(ISaver saver, List<FileInfo> files, RestorePoint restorePoint, FileSystem fileSystem);
    }
}