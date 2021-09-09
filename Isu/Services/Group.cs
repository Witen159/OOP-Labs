using System;
using System.Collections.Generic;

namespace Isu.Services
{
    public class Group
    {
        private readonly CourseNumber _groupCourse;
        private readonly int _groupNumber;
        private readonly string _groupName;
        private readonly string _groupSpecialisation;
        private readonly List<Student> _groupStudents;

        public Group(string groupName)
        {
            _groupName = groupName;
            _groupNumber = int.Parse(groupName[3..]);
            _groupCourse = new CourseNumber(int.Parse(groupName[2].ToString()));
            _groupSpecialisation = groupName[..1];
            _groupStudents = new List<Student>();
        }

        public List<Student> GetAllStudents()
        {
            return _groupStudents;
        }

        // public void AddNewStudent(Student newStudent)
        // {
        //     _groupStudents.Add(newStudent);
        // }
        public string GetGroupName()
        {
            return _groupName;
        }

        public int GetGroupNumber()
        {
            return _groupNumber;
        }

        public string GetGroupSpecialisation()
        {
            return _groupSpecialisation;
        }

        public CourseNumber GetCourse()
        {
            return _groupCourse;
        }
    }
}