using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Backups.Entities
{
    public class RestorePoint
    {
        private static int _currentId = 1;

        private List<Repository> _repositories;

        public RestorePoint(string restorePointPath)
        {
            Id = _currentId;
            _currentId++;
            Path = restorePointPath;
            _repositories = new List<Repository>();
        }

        public int Id { get; }
        public string Path { get; }

        public IReadOnlyList<Repository> Repositories => _repositories;

        public void AddRepository(Repository repository)
        {
            _repositories.Add(repository);
        }
    }
}