using System.Collections.Generic;
using System.IO;
using Backups.Interfaces;

namespace Backups.Entities
{
    public class Single : IMethod
    {
        public void Save(ISaver saver, List<FileInfo> files, RestorePoint restorePoin, FileSystem fileSystemt)
        {
            throw new System.NotImplementedException();
        }
    }
}