using System;
using System.IO;
using System.IO.Compression;
using Backups.Interfaces;

namespace Backups.Entities
{
    public class RestorePoint
    {
        public RestorePoint(string pointName, StorageType type, int id, string directoryPath, ISaveLocal localSave, ISaveVirtual virtualSave)
        {
            Id = id;
            DirectoryPath = directoryPath;
            PointName = pointName;
        }

        public int Id { get; }
        public string DirectoryPath { get; }
        public string PointName { get; }
    }
}