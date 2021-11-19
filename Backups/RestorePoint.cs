using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Backups
{
    public class RestorePoint
    {
        private StorageMethod _method;
        private int _id;
        private string _directoryPath;
        private DirectoryInfo _pointDirectory;
        public RestorePoint(StorageMethod method, int id, string directoryPath)
        {
            _method = method;
            _id = id;
            _directoryPath = directoryPath;
            _pointDirectory = new DirectoryInfo($@"{_directoryPath}/Restore Point {_id}");
            if (_method == StorageMethod.Single)
                Single();
            else if (_method == StorageMethod.Split)
                Split();
            else
                throw new Exception("The storage method is not specified.");
        }

        private void Split()
        {
            _pointDirectory.Create();
            foreach (FileInfo file in new DirectoryInfo($@"{_directoryPath}\Job objects").GetFiles())
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FullName);
                using (ZipArchive zipArchive = ZipFile.Open(@$"{_pointDirectory.FullName}/File_{fileName}_{_id}.zip", ZipArchiveMode.Create))
                {
                    zipArchive.CreateEntryFromFile(file.FullName, file.Name);
                }
            }
        }

        private void Single()
        {
            _pointDirectory.Create();
            ZipFile.CreateFromDirectory($@"{_directoryPath}\Job objects", @$"{_pointDirectory.FullName}/Files_{_id}.zip");
        }
    }
}