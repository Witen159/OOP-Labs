using System;
using System.Collections.Generic;
using Isu.Services;
using Isu.Tools;
using IsuExtra.Services;
using NUnit.Framework;

namespace IsuExtra.Tests
{
    public class Tests
    {
        private IsuExtraService _isuExtraService;

        [SetUp]
        public void Setup()
        {
            _isuExtraService = new IsuExtraService();
        }

        [Test]
        public void EnrollStudentToFlow()
        {
            Group group = _isuExtraService.AddGroup("M3204");
            
            _isuExtraService.SetTimetableForGroup(group, new List<Couple>() 
                { new Couple(new CoupleTime(2, 3), "Povish", 106)});
            
            Student student = _isuExtraService.AddStudent(group, "Bespalov Denis");
            Ognp anotherOgnp = _isuExtraService.AddNewOgnp("N", "second");
            
            Flow normalFlow = _isuExtraService.AddNewFlow(anotherOgnp, "1/1", new List<Couple>() 
                { new Couple(new CoupleTime(3, 4), "Suslina", 201) });

            _isuExtraService.EnrollStudentToFlow(student, normalFlow);
            Assert.IsTrue(normalFlow.AllStudents[0].Id == student.Id);
            Assert.IsTrue(_isuExtraService.GetStudentsChoice(student).Flows[0].Name == normalFlow.Name);

            // Same couples
            Flow sameCoupleFlow = _isuExtraService.AddNewFlow(anotherOgnp, "1/2", new List<Couple>() 
                { new Couple(new CoupleTime(2, 3), "Suslina", 201) });
            
            Assert.Catch<IsuException>(() =>
            {
                _isuExtraService.EnrollStudentToFlow(student, sameCoupleFlow);
            });
            
            // Same ognp
            Ognp studentsOgnp = _isuExtraService.AddNewOgnp("M", "first");
            Flow sameOgnpFlow = _isuExtraService.AddNewFlow(studentsOgnp, "1/1", new List<Couple>() 
                { new Couple(new CoupleTime(1, 2), "Suslina", 201) });
            
            Assert.Catch<IsuException>(() =>
            {
                _isuExtraService.EnrollStudentToFlow(student, sameOgnpFlow);
            });
            
            // Exceeded the number of ognp
            Flow secondFlow = _isuExtraService.AddNewFlow(anotherOgnp, "1/2", new List<Couple>() 
                { new Couple(new CoupleTime(1, 2), "Suslina", 201) });
            Flow thirdFlow = _isuExtraService.AddNewFlow(anotherOgnp, "1/3", new List<Couple>() 
                { new Couple(new CoupleTime(1, 1), "Suslina", 201) });
            
            Assert.Catch<IsuException>(() =>
            {
                _isuExtraService.EnrollStudentToFlow(student, secondFlow);
                _isuExtraService.EnrollStudentToFlow(student, thirdFlow);
            });
        }

        [Test]
        public void RemoveStudentFromFlow()
        {
            Group group = _isuExtraService.AddGroup("M3204");
            
            _isuExtraService.SetTimetableForGroup(group, new List<Couple>() 
                { new Couple(new CoupleTime(2, 3), "Povish", 106)});
            
            Student student = _isuExtraService.AddStudent(group, "Bespalov Denis");
            Ognp ognp = _isuExtraService.AddNewOgnp("N", "second");
            
            Flow flow = _isuExtraService.AddNewFlow(ognp, "1/1", new List<Couple>() 
                { new Couple(new CoupleTime(3, 4), "Suslina", 201) });

            _isuExtraService.EnrollStudentToFlow(student, flow);
            _isuExtraService.RemoveStudentFromFlow(student, flow);
            
            Assert.IsTrue(flow.AllStudents.Count == 0);
            Assert.IsTrue(_isuExtraService.GetStudentsChoice(student).Flows.Count == 0);
        }

        [Test]
        public void GetOgnpsFlows()
        {
            Ognp ognp = _isuExtraService.AddNewOgnp("N", "second");
            Flow firstFlow = _isuExtraService.AddNewFlow(ognp, "1/3", new List<Couple>() 
                { new Couple(new CoupleTime(1, 1), "Suslina", 201) });
            Flow secondFlow = _isuExtraService.AddNewFlow(ognp, "1/2", new List<Couple>() 
                { new Couple(new CoupleTime(1, 2), "Suslina", 201) });
            List<Flow> ognpsFlows = _isuExtraService.GetOgnpsFlows(ognp);
            Assert.IsTrue(ognpsFlows[0].Name == firstFlow.Name && ognpsFlows[1].Name == secondFlow.Name);
        }

        [Test]
        public void GetFlowsStudents()
        {
            Group group = _isuExtraService.AddGroup("M3204");
            _isuExtraService.SetTimetableForGroup(group, new List<Couple>() 
                { new Couple(new CoupleTime(2, 3), "Povish", 106)});
            
            Student firstStudent = _isuExtraService.AddStudent(group, "Bespalov Denis");
            Student secondStudent = _isuExtraService.AddStudent(group, "Semen");
            
            Ognp ognp = _isuExtraService.AddNewOgnp("N", "second");
            Flow flow = _isuExtraService.AddNewFlow(ognp, "1/3", new List<Couple>() 
                { new Couple(new CoupleTime(1, 1), "Suslina", 201) });
            
            _isuExtraService.EnrollStudentToFlow(firstStudent, flow);
            _isuExtraService.EnrollStudentToFlow(secondStudent, flow);
            
            List<Student> students = _isuExtraService.GetFlowsStudents(flow);
            Assert.IsTrue(students[0].Id == firstStudent.Id && students[1].Id == secondStudent.Id);
        }

        [Test]
        public void GetNotEnrolledStudents()
        {
            Group group = _isuExtraService.AddGroup("M3204");
            _isuExtraService.SetTimetableForGroup(group, new List<Couple>() 
                { new Couple(new CoupleTime(2, 3), "Povish", 106)});
            
            Student firstStudent = _isuExtraService.AddStudent(group, "Bespalov Denis");
            Student secondStudent = _isuExtraService.AddStudent(group, "Semen");
            
            Ognp ognp = _isuExtraService.AddNewOgnp("N", "second");
            Flow flow = _isuExtraService.AddNewFlow(ognp, "1/3", new List<Couple>() 
                { new Couple(new CoupleTime(1, 1), "Suslina", 201) });
            
            _isuExtraService.EnrollStudentToFlow(firstStudent, flow);
            List<Student> notEnrolledStudents = _isuExtraService.GetNotEnrolledStudents(group);
            Assert.IsTrue(notEnrolledStudents.Count == 1);
            Assert.IsTrue(notEnrolledStudents[0].Id == secondStudent.Id);
        }
    }
}