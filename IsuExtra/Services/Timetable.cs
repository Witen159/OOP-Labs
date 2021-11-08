using System.Collections.Generic;
using System.Linq;
using Isu.Services;

namespace IsuExtra.Services
{
    public class Timetable
    {
        private List<Couple> _shedule;
        public Timetable(Group group, List<Couple> shedule)
        {
            Group = group;
            _shedule = shedule;
        }

        public Group Group { get; }
        public IReadOnlyList<Couple> Shedule => _shedule;
    }
}