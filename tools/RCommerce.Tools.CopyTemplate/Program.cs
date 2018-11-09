using System.IO;
using System.Linq;

namespace RCommerce.Tools.CopyTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            var solutionDir = args[0];
            var projectDir = args[1];
            var templatePath = Path.Combine(solutionDir, "templates");
            var src = templatePath;
            var desc = projectDir;

            var exludeDirs = new[] { "node_modules" };

            foreach (string dirPath in Directory.GetDirectories(src, "*", SearchOption.AllDirectories).Where(i => !exludeDirs.Contains(i)))
                Directory.CreateDirectory(dirPath.Replace(src, desc));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(src, "*.*",
                SearchOption.AllDirectories))
            {
                if (exludeDirs.Any(i => newPath.Contains(i))) continue;
                File.Copy(newPath, newPath.Replace(src, desc), true);
            }
        }
    }
}
