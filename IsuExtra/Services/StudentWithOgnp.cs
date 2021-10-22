using Isu.Services;

namespace IsuExtra.Services
{
    public class StudentWithOgnp : Student
    {
        public StudentWithOgnp(string name)
            : base(name)
        {
            StudentsFlow = null;
        }

        public Flow StudentsFlow { get; set; }
    }
}