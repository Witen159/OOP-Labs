using System.Collections.Generic;
using Isu.Services;
using Isu.Tools;
using IsuExtra.Tools;

namespace IsuExtra.Services
{
    public class Flow
    {
        private const int MaxNumberOfStudents = 30;
        private int _numberOfStudents;
        private List<StudentWithOgnp> _allStudents;
        public Flow(string flowName)
        {
            _numberOfStudents = 0;
            Name = flowName;
            _allStudents = new List<StudentWithOgnp>();
        }

        public string Name { get; }
        public Ognp FlowsOgnp { get; set; }
        public IReadOnlyList<StudentWithOgnp> AllStudents => _allStudents;

        public void AddStudent(StudentWithOgnp student)
        {
            if (_numberOfStudents >= MaxNumberOfStudents)
                throw new ExceededMaxNumberOfStudentIsuException();
            student.StudentsFlow = this;
            _numberOfStudents++;
            _allStudents.Add(student);
        }

        public void RemoveStudent(StudentWithOgnp removedStudent)
        {
            if (!_allStudents.Remove(removedStudent))
            {
                throw new NoStudentInFlowIsuException();
            }

            removedStudent.StudentsFlow = null;
        }

        public bool IsFull()
        {
            return _numberOfStudents == MaxNumberOfStudents;
        }
    }
}