using System;
using System.Collections.Generic;
using Isu.Services;
using IsuExtra.Services;

namespace IsuExtra
{
    internal class Program
    {
        private static void Main()
        {
            IsuExtraService isuExtraService = new IsuExtraService();
            Group group = isuExtraService.AddGroup("M3204");
            isuExtraService.SetTimetableForGroup(group, new List<Couple>()
                { new Couple(new CoupleTime(2, 3), "Povish", 106) });
            Student student = isuExtraService.AddStudent(group, "Bespalov Denis");
            Ognp ognp = isuExtraService.AddNewOgnp("N", "second");
            Flow flow = isuExtraService.AddNewFlow(ognp, "1/1", new List<Couple>()
                { new Couple(new CoupleTime(3, 4), "Suslina", 201) });
            Console.WriteLine(flow.AllStudents.Count);
            isuExtraService.EnrollStudentToFlow(student, flow);
            Console.WriteLine(flow.AllStudents.Count);
            Console.WriteLine(isuExtraService.GetStudentsChoice(student).Flows.Count);
            isuExtraService.RemoveStudentFromFlow(student, flow);
            Console.WriteLine(flow.AllStudents.Count);
            Console.WriteLine(isuExtraService.GetStudentsChoice(student).Flows.Count);
        }
    }
}
