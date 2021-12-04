using System.Collections.Generic;
using Backups.Entities;

namespace Backups.Interfaces
{
    public interface ISaveVirtual
    {
        public abstract List<List<MyFile>> Save(List<MyFile> files);
    }
}