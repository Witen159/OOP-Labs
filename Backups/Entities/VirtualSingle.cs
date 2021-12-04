using System.Collections.Generic;
using Backups.Interfaces;

namespace Backups.Entities
{
    public class VirtualSingle : ISaveVirtual
    {
        public List<List<MyFile>> Save(List<MyFile> files)
        {
            return new List<List<MyFile>> { files };
        }
    }
}