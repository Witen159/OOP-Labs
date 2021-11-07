using System;
using System.Collections.Generic;
using System.Linq;
using Isu.Services;
using Isu.Tools;

namespace IsuExtra.Services
{
    public class StudentsChoice
    {
        private List<Flow> _flows;
        private List<Couple> _shedule;

        public StudentsChoice(Student student, List<Couple> shedule)
        {
            Student = student;
            _shedule = shedule;
            _flows = new List<Flow>();
        }

        public Student Student { get; }

        // public IReadOnlyList<Couple> Shedule { get; }
        public IReadOnlyList<Flow> Flows => _flows;

        public void Enroll(Flow flow)
        {
            if (_flows.Count >= 2)
                throw new IsuException("Exceeded the number of possible Ognp");
            if (Student.StudentsGroup.GroupSpecialisation == flow.FlowsOgnp.Specialization)
                throw new IsuException("The Megafaculty of Ognp is same with student");
            if (CheckIntersectionOfSchedules(flow))
                throw new IsuException("The schedule of this flow intersects with the student's group schedule");
            flow.AddStudent(Student);
            _flows.Add(flow);
        }

        public void Remove(Flow flow)
        {
            if (!_flows.Remove(flow))
            {
                throw new IsuException("The student is not enrolled in this flow");
            }

            flow.RemoveStudent(Student);
        }

        private bool CheckIntersectionOfSchedules(Flow flow)
        {
            return (from flowCouple in flow.Schedule
                from studentsCouple in _shedule
                where Equals(flowCouple, studentsCouple)
                select flowCouple).Any();
        }
    }
}