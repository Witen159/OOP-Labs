namespace Isu
{
    internal class Program
    {
        private static void Main()
        {
            var isu = new Services.IsuService();
            isu.AddGroup("M3204");
            isu.AddStudent(isu.FindGroup("M3204"), "Bespalov Denis");
        }
    }
}
