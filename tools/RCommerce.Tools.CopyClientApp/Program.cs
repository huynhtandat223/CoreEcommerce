using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RCommerce.Tools.CopyClientApp
{
    class Program
    {
        private static void CopyModules(string src, string desc, IEnumerable<string> exludeDirs)
        {
            var validDirs = Directory.GetDirectories(src, "*", SearchOption.AllDirectories).Where(i => !exludeDirs.Any(exDir => i.Contains(exDir)));
            foreach (string dirPath in validDirs)
                Directory.CreateDirectory(dirPath.Replace(src, desc));

            //Copy all the files & Replaces any files with the same name
            var validFiles = Directory.GetFiles(src, "*.*", SearchOption.AllDirectories).Where(i => !exludeDirs.Any(exDir => i.Contains(exDir)));
            foreach (string srcFile in validFiles)
            {
                if (exludeDirs.Any(i => srcFile.Contains(i))) continue;
                var descFilePath = srcFile.Replace(src, desc);
                if (!File.Exists(descFilePath))
                    File.Copy(srcFile, descFilePath, false);
                else
                {
                    var file = new FileInfo(srcFile);
                    var descFile = new FileInfo(descFilePath);
                    if (file.LastWriteTime > descFile.LastWriteTime)
                    {
                        // now you can safely overwrite it
                        file.CopyTo(descFile.FullName, true);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            var projectPath = args[0];
            var solutionPath = args[1];

            const string clientApp = "ClientApp";
            var exludeDirs = new[] { "node_modules", "dist", "e2e" };

            //check if has clientApp folder, if not exists => copy template.
            var currentProjectClientAppPath = Path.Combine(projectPath, clientApp, "src");
            if (!Directory.Exists(currentProjectClientAppPath))
            {
                var templatePath = Path.Combine(solutionPath, "templates", clientApp);
                var src = templatePath;
                var desc = Path.Combine(projectPath, clientApp);
                CopyModules(src, desc, exludeDirs);
            }

            var srcModule = Path.Combine(solutionPath, "modules", "RCommerce.Module.Authentication", clientApp, "src", "app", "authentication");
            var descModule = Path.Combine(projectPath, clientApp, "src", "app", "authentication");
            CopyModules(srcModule, descModule, exludeDirs);

            //var modulePath = Path.Combine(solutionPath, "modules");
            //var modulesInProjectPath = Path.Combine(projectPath, "Modules");
            //var moduleNamesInProject = Directory.GetFiles(modulesInProjectPath).Select(i => Path.GetFileNameWithoutExtension(i));

            //Parallel.ForEach(moduleNamesInProject, moduleName =>
            //{
            //    var clientAppPath = Path.Combine(modulePath, moduleName, clientApp);

            //    foreach (string dirPath in Directory.GetDirectories(clientAppPath, "*", SearchOption.AllDirectories))
            //        Directory.CreateDirectory(dirPath.Replace(clientAppPath, currentProjectClientAppPath));

            //    //Copy all the files & Replaces any files with the same name
            //    foreach (string newPath in Directory.GetFiles(clientAppPath, "*.*",
            //        SearchOption.AllDirectories))
            //        File.Copy(newPath, newPath.Replace(clientAppPath, currentProjectClientAppPath), true);
            //});
        }
    }
}
