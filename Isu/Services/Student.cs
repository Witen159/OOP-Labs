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
            StudentsGroupName = null;
        }

        public string Name { get; }
        public int Id { get; }

        // TODO: Group class, not name
        public string StudentsGroupName { get; set; }
    }
}