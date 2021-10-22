using System.Collections.Generic;
using Isu.Services;
using IsuExtra.Tools;

namespace IsuExtra.Services
{
    public class IsuExtraService : IsuService
    {
        public Ognp AddNewOgnp(MegaFaculty megaFaculty, string ognpName)
        {
            var newOgnp = new Ognp(ognpName);
            megaFaculty.AddOgnp(newOgnp);
            return newOgnp;
        }

        public void EnrollStudentToOgnp(StudentWithOgnp student, Ognp ognp)
        {
            bool isStudentEnrolled = false;
            foreach (Flow flow in ognp.AllFlows)
            {
                if (!flow.IsFull())
                {
                    flow.AddStudent(student);
                    isStudentEnrolled = true;
                    break;
                }
            }

            if (!isStudentEnrolled)
                throw new NoAvailableFlowsIsuException();
        }

        public StudentWithOgnp RemoveStudentFromOgnp(StudentWithOgnp student)
        {
            Flow flow = student.StudentsFlow;
            if (flow == null)
                throw new NoStudentInFlowIsuException();
            flow.RemoveStudent(student);
            return student;
        }

        public List<StudentWithOgnp> GetNotEnrolledStudents(Group group)
        {
            var notEnrolledStudents = new List<StudentWithOgnp>();
            foreach (StudentWithOgnp student in group.GetAllStudents())
            {
                if (student.StudentsFlow == null)
                    notEnrolledStudents.Add(student);
            }

            return notEnrolledStudents.Count == 0 ? null : notEnrolledStudents;
        }
    }
}