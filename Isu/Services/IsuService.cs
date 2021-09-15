using System;
using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private readonly List<Group> _groups;

        public IsuService()
        {
            _groups = new List<Group>();
        }

        public Group AddGroup(string name)
        {
            var newGroup = new Group(name);
            _groups.Add(newGroup);
            return newGroup;
        }

        public Student AddStudent(Group group, string name)
        {
            if (FindStudent(name) != null)
                throw new AddingExistingStudentIsuException();
            var newStudent = new Student(name);
            group.AddStudent(newStudent);
            return newStudent;
        }

        public Student RemoveStudent(Group group, string name)
        {
            Student removedStudent = FindStudent(name);
            group.RemoveStudent(removedStudent);
            return removedStudent;
        }

        public Student GetStudent(int id)
        {
            foreach (Group group in _groups)
            {
                foreach (Student student in group.GetAllStudents())
                {
                    if (id == student.Id)
                        return student;
                }
            }

            throw new InvalideStudentIsuException();
        }

        public Student FindStudent(string name)
        {
            foreach (Group group in _groups)
            {
                foreach (Student student in group.GetAllStudents())
                {
                    if (name == student.Name)
                        return student;
                }
            }

            // throw new Exception("No student with name " + name.ToString());
            return null;
        }

        public List<Student> FindStudents(string groupName)
        {
            foreach (Group group in _groups)
            {
                if (groupName == group.GroupName)
                    return group.GetAllStudents();
            }

            // throw new Exception("No group with name " + groupName.ToString());
            return new List<Student>();
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var studentsInCourse = new List<Student>();

            foreach (Group group in _groups)
            {
                if (courseNumber.Number == group.GroupCourse.Number)
                {
                    studentsInCourse.AddRange(group.GetAllStudents());
                }
            }

            // if (studentsInCourse.Count == 0)
            //     throw new Exception("No students in course " + courseNumber.Number.ToString());
            return studentsInCourse;
        }

        public Group FindStudentsGroup(Student student)
        {
            return FindGroup(student.StudentsGroupName);

            // throw new Exception("No student" + student.Name + " in groups");
        }

        public Group FindGroup(string groupName)
        {
            foreach (Group group in _groups)
            {
                if (groupName == group.GroupName)
                    return group;
            }

            // throw new Exception("No group with name " + groupName.ToString());
            return null;
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            var groupsInCourse = new List<Group>();

            foreach (Group group in _groups)
            {
                if (courseNumber.Number == group.GroupCourse.Number)
                {
                    groupsInCourse.Add(group);
                }
            }

            // if (groupsInCourse.Count == 0)
            //     throw new Exception("No groups in course " + courseNumber.Number.ToString());
            return groupsInCourse;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            newGroup.AddStudent(RemoveStudent(FindStudentsGroup(student), student.Name));
        }
    }
}