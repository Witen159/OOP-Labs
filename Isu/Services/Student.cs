namespace Isu.Services
{
    public class Student
    {
        private static int _currentId = 311000;
        private readonly int _id;
        private readonly string _name;

        public Student(string name)
        {
            _name = name;
            _id = _currentId;
            _currentId++;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }
    }
}