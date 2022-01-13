using System.IO;
using Backups.Entities;

namespace BackupsExtra.Recovery
{
    public class DifferentLocationRecovery : IRecovery
    {
        private string _path;
        public DifferentLocationRecovery(string path)
        {
            _path = path;
        }

        public void Recovery(RestorePoint restorePoint)
        {
            foreach (Repository repository in restorePoint.Repositories)
            {
                foreach (FileInfo storage in repository.Storages)
                {
                    string filePath = Path.Combine(_path, $"{storage.Name}");
                    storage.CopyTo(filePath, true);
                }
            }
        }
    }
}