using System;
using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Services
{
    public class Group
    {
        private const int MaxNumberOfStudents = 30;
        private readonly List<Student> _groupStudents;
        private int _numberOfStudents;
        public Group(string groupName)
        {
            _numberOfStudents = 0;
            GroupName = groupName;
            GroupNumber = int.Parse(groupName[3..]);
            GroupCourse = new CourseNumber(int.Parse(groupName[2].ToString()));
            GroupSpecialisation = groupName[..1];
            _groupStudents = new List<Student>();
            if (GroupName.Length != 5 || !char.IsUpper(groupName[0]) || !int.TryParse(groupName[1..], out int temp))
                throw new InvalidNameOfGroupIsuException();
        }

        public string GroupName { get; }
        public int GroupNumber { get; }
        public string GroupSpecialisation { get; }
        public CourseNumber GroupCourse { get; }

        public List<Student> GetAllStudents()
        {
            return _groupStudents;
        }

        public void AddStudent(Student newStudent)
        {
            if (_numberOfStudents >= MaxNumberOfStudents)
                throw new ExceededMaxNumberOfStudentIsuException();
            newStudent.StudentsGroup = this;
            _numberOfStudents++;
            _groupStudents.Add(newStudent);
        }

        public void RemoveStudent(Student removedStudent)
        {
            if (!_groupStudents.Remove(removedStudent))
            {
                throw new NoStudentInGroupIsuException();
            }

            removedStudent.StudentsGroup = null;
        }
    }
}