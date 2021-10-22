using System.Collections.Generic;
using Isu.Services;

namespace IsuExtra.Services
{
    public class MegaFaculty
    {
        private List<Ognp> _allOgnp;
        private List<Group> _allGroups;
        public MegaFaculty(string name)
        {
            Name = name;
            _allOgnp = new List<Ognp>();
            _allGroups = new List<Group>();
        }

        public IReadOnlyList<Ognp> AllOgnp => _allOgnp;
        public IReadOnlyList<Group> AllGroups => _allGroups;
        public string Name { get; }

        public void AddOgnp(Ognp ognp)
        {
            _allOgnp.Add(ognp);
        }
    }
}