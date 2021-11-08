using System.Collections.Generic;
using Isu.Services;
using Isu.Tools;

namespace IsuExtra.Services
{
    public class Flow
    {
        private const int MaxNumberOfStudents = 30;
        private int _numberOfStudents;
        private List<Student> _allStudents;
        private List<Couple> _shedule;
        public Flow(string flowName, List<Couple> schedule)
        {
            _numberOfStudents = 0;
            Name = flowName;
            _allStudents = new List<Student>();
            _shedule = schedule;
        }

        public string Name { get; }
        public Ognp FlowsOgnp { get; set; }
        public IReadOnlyList<Couple> Schedule => _shedule;
        public IReadOnlyList<Student> AllStudents => _allStudents;

        public void AddStudent(Student student)
        {
            if (_numberOfStudents >= MaxNumberOfStudents)
                throw new ExceededMaxNumberOfStudentIsuException();
            _numberOfStudents++;
            _allStudents.Add(student);
        }

        public void RemoveStudent(Student removedStudent)
        {
            if (!_allStudents.Remove(removedStudent))
            {
                throw new IsuException("No such student in flow");
            }
        }

        public bool IsFull()
        {
            return _numberOfStudents == MaxNumberOfStudents;
        }
    }
}