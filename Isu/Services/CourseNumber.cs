namespace Isu.Services
{
    public class CourseNumber
    {
        private readonly int _courseNumber;

        public CourseNumber(int courseNumber)
        {
            _courseNumber = courseNumber;
        }

        public int GetCourseNumber()
        {
            return _courseNumber;
        }
    }
}