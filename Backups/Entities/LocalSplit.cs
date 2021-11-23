using System.IO;
using System.IO.Compression;
using Backups.Interfaces;

namespace Backups.Entities
{
    public class LocalSplit : ISaveLocal
    {
        public void Save(string backupPath, string restorePointName, int id)
        {
            var pointDirectory = new DirectoryInfo($@"{backupPath}\{restorePointName}_{id}");
            pointDirectory.Create();
            foreach (FileInfo file in new DirectoryInfo($@"{backupPath}\Job objects").GetFiles())
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FullName);
                using (ZipArchive zipArchive = ZipFile.Open(@$"{pointDirectory.FullName}/File_{fileName}_{id}.zip", ZipArchiveMode.Create))
                {
                    zipArchive.CreateEntryFromFile(file.FullName, file.Name);
                }
            }
        }
    }
}