using System;
using System.Collections.Generic;

namespace Isu.Services
{
    public class Isu : IIsuService
    {
        private List<Group> _groups;

        public Isu()
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
            var newStudent = new Student(name);
            group.GetAllStudents().Add(newStudent);
            return newStudent;
        }

        public Student RemoveStudent(Group group, string name)
        {
            var removedStudent = new Student(name);
            if (!group.GetAllStudents().Remove(removedStudent))
                throw new Exception("No student with name " + name.ToString() + " in group " + group.GetGroupName());
            return removedStudent;
        }

        public Student GetStudent(int id)
        {
            foreach (Group group in _groups)
            {
                foreach (Student student in group.GetAllStudents())
                {
                    if (id == student.GetId())
                        return student;
                }
            }

            throw new Exception("No student with ID " + id.ToString());
        }

        public Student FindStudent(string name)
        {
            foreach (Group group in _groups)
            {
                foreach (Student student in group.GetAllStudents())
                {
                    if (name == student.GetName())
                        return student;
                }
            }

            throw new Exception("No student with name " + name.ToString());
        }

        public List<Student> FindStudents(string groupName)
        {
            foreach (Group group in _groups)
            {
                if (groupName == group.GetGroupName())
                    return group.GetAllStudents();
            }

            throw new Exception("No group with name " + groupName.ToString());
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var studentsInCourse = new List<Student>();

            foreach (Group group in _groups)
            {
                if (courseNumber == group.GetCourse())
                {
                    studentsInCourse.AddRange(group.GetAllStudents());
                }
            }

            if (studentsInCourse.Count == 0)
                throw new Exception("No students in course " + courseNumber.GetCourseNumber().ToString());
            return studentsInCourse;
        }

        public Group FindStudentsGroup(Student student)
        {
            foreach (Group group in _groups)
            {
                foreach (Student studentInGroup in group.GetAllStudents())
                {
                    if (studentInGroup == student)
                        return group;
                }
            }

            throw new Exception("No student" + student.GetName() + " in groups");
        }

        public Group FindGroup(string groupName)
        {
            foreach (Group group in _groups)
            {
                if (groupName == group.GetGroupName())
                    return group;
            }

            throw new Exception("No group with name " + groupName.ToString());
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            var groupsInCourse = new List<Group>();

            foreach (Group group in _groups)
            {
                if (courseNumber == group.GetCourse())
                {
                    groupsInCourse.Add(group);
                }
            }

            if (groupsInCourse.Count == 0)
                throw new Exception("No groups in course " + courseNumber.GetCourseNumber().ToString());
            return groupsInCourse;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            RemoveStudent(FindStudentsGroup(student), student.GetName());
            AddStudent(newGroup, student.GetName());
        }
    }
}