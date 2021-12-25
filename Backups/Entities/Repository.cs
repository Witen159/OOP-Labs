using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Backups.Entities
{
    public class Repository
    {
        private List<FileInfo> _storages;

        public Repository()
        {
            _storages = new List<FileInfo>();
        }

        public IReadOnlyList<FileInfo> Storages => _storages;

        public void AddStorages(List<FileInfo> files)
        {
            if (files.Any(file => file == null))
                throw new Exception("File doesn't exist");
            _storages.AddRange(files);
        }
    }
}