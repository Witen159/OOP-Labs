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

        // private void Split()
        // {
        //     _pointDirectory.Create();
        //     foreach (FileInfo file in new DirectoryInfo($@"{_directoryPath}\Job objects").GetFiles())
        //     {
        //         string fileName = Path.GetFileNameWithoutExtension(file.FullName);
        //         using (ZipArchive zipArchive = ZipFile.Open(@$"{_pointDirectory.FullName}/File_{fileName}_{_id}.zip", ZipArchiveMode.Create))
        //         {
        //             zipArchive.CreateEntryFromFile(file.FullName, file.Name);
        //         }
        //     }
        // }
        //
        // private void Single()
        // {
        //     _pointDirectory.Create();
        //     ZipFile.CreateFromDirectory($@"{_directoryPath}\Job objects", @$"{_pointDirectory.FullName}/Files_{_id}.zip");
        // }
    }
}