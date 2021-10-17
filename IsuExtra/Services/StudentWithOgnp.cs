using Isu.Services;

namespace IsuExtra.Services
{
    public class StudentWithOgnp : Student
    {
        public StudentWithOgnp(string name)
            : base(name)
        {
            StudentsOgnp = null;
        }

        public Ognp StudentsOgnp { get; set; }
    }
}