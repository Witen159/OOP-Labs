using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            //TODO: implement
            _isuService = new IsuService();
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            Group newGroup = _isuService.AddGroup("M3204");
            _isuService.AddStudent(newGroup, "Bespalov Denis");
            Assert.IsNotNull(newGroup.GetAllStudents()[0].StudentsGroup);
            Assert.IsNotEmpty(newGroup.GetAllStudents());
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group newGroup = _isuService.AddGroup("M3204");
                string student = "Student ";
                for (int i = 1; i <= 31; i++)
                    _isuService.AddStudent(newGroup, student + i.ToString());
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                Group newGroup = _isuService.AddGroup("M32004");
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Group oldGroup = _isuService.AddGroup("M3204");
            Group newGroup = _isuService.AddGroup("M3200");
            _isuService.AddStudent(oldGroup, "Bespalov Denis");
            Group studentsOldGroup = oldGroup.GetAllStudents()[0].StudentsGroup;
            _isuService.ChangeStudentGroup(_isuService.FindStudent("Bespalov Denis"), newGroup);
            Assert.Contains(_isuService.FindStudent("Bespalov Denis"), newGroup.GetAllStudents());
            Assert.IsEmpty(oldGroup.GetAllStudents());
            Assert.True(studentsOldGroup != _isuService.FindStudent("Bespalov Denis").StudentsGroup);
        }
    }
}