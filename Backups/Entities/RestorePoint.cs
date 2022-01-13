using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Backups.Entities
{
    public class RestorePoint
    {
        private static int _currentId = 1;

        private List<Repository> _repositories;

        public RestorePoint(string restorePointName, string restorePointDirectoryPath, DateTime creationDate)
        {
            Id = _currentId;
            _currentId++;
            Name = restorePointName;
            DirectoryPath = restorePointDirectoryPath;
            _repositories = new List<Repository>();
            PointDirectoryPath = Path.Combine(DirectoryPath, $"{Name} {Id}");
            CreationDate = creationDate;
        }

        public int Id { get; }
        public string DirectoryPath { get; }
        public string PointDirectoryPath { get; }
        public string Name { get; }
        public DateTime CreationDate { get; }

        public IReadOnlyList<Repository> Repositories => _repositories;

        public void AddRepository(Repository repository)
        {
            _repositories.Add(repository);
        }
    }
}