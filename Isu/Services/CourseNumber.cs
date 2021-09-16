using Isu.Tools;

namespace Isu.Services
{
    public class CourseNumber
    {
        private const int MaxNumberOfCourses = 4;
        public CourseNumber(int courseNumber)
        {
            if (courseNumber > MaxNumberOfCourses || courseNumber < 1)
                throw new InvalidCourseNumberIsuException();
            Number = courseNumber;
        }

        public int Number { get; }
    }
}