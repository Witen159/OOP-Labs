using System.IO;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            var rootPath = @"C:\Users\User\source\repos\Programming_1\Witen159\Backups";
            string repositoryName = "TestDir";
            var directory = new DirectoryInfo($@"{rootPath}\{repositoryName}");
            if (!directory.Exists)
                directory.Create();
            var subDirectory = new DirectoryInfo($@"{directory.FullName}\Job objects");
            if (!subDirectory.Exists)
                subDirectory.Create();
        }
    }
}
