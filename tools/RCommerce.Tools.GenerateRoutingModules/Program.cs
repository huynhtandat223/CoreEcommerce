using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RCommerce.Tools.GenerateRoutingModules
{
    class Program
    {
        static void Main(string[] args)
        {
            var projectPath = args[0];
            var solutionPath = args[1];

            var modulesInProjectPath = Path.Combine(projectPath, "Modules");
            var moduleNamesInProject = Directory.GetFiles(modulesInProjectPath).Select(i => Path.GetFileNameWithoutExtension(i));

            var modulePath = Path.Combine(solutionPath, "modules");
            const string clientApp = "ClientApp";
            Parallel.ForEach(moduleNamesInProject, moduleName => {
                var clientAppPath = Path.Combine(modulePath, moduleName, clientApp);
                if (Directory.Exists(clientAppPath)) //copy client app into current project.
                {
                    var currentProjectClientAppPath = Path.Combine(projectPath, clientApp);

                    foreach (string dirPath in Directory.GetDirectories(clientAppPath, "*", SearchOption.AllDirectories))
                        Directory.CreateDirectory(dirPath.Replace(clientAppPath, currentProjectClientAppPath));

                    //Copy all the files & Replaces any files with the same name
                    foreach (string newPath in Directory.GetFiles(clientAppPath, "*.*",
                        SearchOption.AllDirectories))
                        File.Copy(newPath, newPath.Replace(clientAppPath, currentProjectClientAppPath), true);
                }
            });
        }
    }
}
