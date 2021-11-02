using System;
using System.Collections.Generic;
using Isu.Services;
using Isu.Tools;

namespace IsuExtra.Services
{
    public class IsuExtraService : IsuService
    {
        private readonly List<Timetable> _timetables = new List<Timetable>();
        private readonly List<StudentsChoice> _studentsChoises = new List<StudentsChoice>();
        private readonly List<Ognp> _ognps = new List<Ognp>();
        public Ognp AddNewOgnp(string specialization, string ognpName)
        {
            var newOgnp = new Ognp(ognpName, specialization);
            _ognps.Add(newOgnp);
            return newOgnp;
        }

        public List<Flow> GetOgnpsFlows(Ognp ognp)
        {
            if (ognp.AllFlows.Count == 0)
                return null;
            return ognp.AllFlows as List<Flow>;
        }

        public List<Student> GetFlowsStudents(Flow flow)
        {
            if (flow.AllStudents.Count == 0)
                return null;
            return flow.AllStudents as List<Student>;
        }

        public Flow AddNewFlow(Ognp ognp, string flowName, List<Couple> schedule)
        {
            var newFlow = new Flow(flowName, schedule);
            ognp.AddFlow(newFlow);
            return newFlow;
        }

        public void EnrollStudentToFlow(Student student, Flow flow)
        {
            StudentsChoice studentsChoice = GetStudentsChoice(student);
            if (studentsChoice == null)
            {
                studentsChoice = new StudentsChoice(student, GetStudentsShedule(student));
                studentsChoice.Enroll(flow);
                _studentsChoises.Add(studentsChoice);
            }
            else
            {
                studentsChoice.Enroll(flow);
            }
        }

        public void RemoveStudentFromFlow(Student student, Flow flow)
        {
            GetStudentsChoice(student).Remove(flow);
        }

        public List<Student> GetNotEnrolledStudents(Group group)
        {
            var notEnrolledStudents = new List<Student>();
            foreach (Student student in group.GetAllStudents())
            {
                StudentsChoice studentsChoice = GetStudentsChoice(student);
                if (studentsChoice == null || studentsChoice.Flows.Count == 0)
                    notEnrolledStudents.Add(student);
            }

            return notEnrolledStudents.Count == 0 ? null : notEnrolledStudents;
        }

        public Timetable SetTimetableForGroup(Group group, List<Couple> shedule)
        {
            var newTimetable = new Timetable(group, shedule);
            _timetables.Add(newTimetable);
            return newTimetable;
        }

        public StudentsChoice GetStudentsChoice(Student student)
        {
            foreach (StudentsChoice studentsChoice in _studentsChoises)
            {
                if (studentsChoice.Student.Id == student.Id)
                    return studentsChoice;
            }

            return null;
        }

        public List<Couple> GetStudentsShedule(Student student)
        {
            Group studentsGroup = student.StudentsGroup;
            foreach (Timetable timetable in _timetables)
            {
                if (timetable.Group.GroupName == studentsGroup.GroupName)
                {
                    return timetable.Shedule as List<Couple>;
                }
            }

            throw new IsuException("The student's group does not have a schedule set");
        }
    }
}