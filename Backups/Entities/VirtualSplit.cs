using System.Collections.Generic;
using System.Linq;
using Backups.Interfaces;

namespace Backups.Entities
{
    public class VirtualSplit : ISaveVirtual
    {
        public List<List<MyFile>> Save(List<MyFile> files)
        {
            return files.Select(file => new List<MyFile> { file }).ToList();
        }
    }
}