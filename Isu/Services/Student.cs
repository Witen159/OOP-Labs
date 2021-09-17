namespace Isu.Services
{
    public class Student
    {
        private static int _currentId = 100000;

        public Student(string name)
        {
            Name = name;
            Id = _currentId;
            _currentId++;
            StudentsGroup = null;
        }

        public string Name { get; }
        public int Id { get; }
        public Group StudentsGroup { get; set; }
    }
}