using System.Collections.Generic;
using System.IO;
using Backups.Interfaces;

namespace Backups.Entities
{
    public class Split : IMethod
    {
        public void Save(ISaver saver, List<FileInfo> files, RestorePoint restorePoint, FileSystem fileSystem)
        {
            throw new System.NotImplementedException();
        }
    }
}