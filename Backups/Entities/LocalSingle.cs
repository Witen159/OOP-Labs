using System.IO;
using System.IO.Compression;
using Backups.Interfaces;

namespace Backups.Entities
{
    public abstract class LocalSingle : ISaveLocal
    {
        public void Save(string backupPath, string restorePointName, int id)
        {
            var pointDirectory = new DirectoryInfo($@"{backupPath}\{restorePointName}_{id}");
            pointDirectory.Create();
            ZipFile.CreateFromDirectory($@"{backupPath}\Job objects", @$"{pointDirectory.FullName}/Files_{id}.zip");
        }
    }
}