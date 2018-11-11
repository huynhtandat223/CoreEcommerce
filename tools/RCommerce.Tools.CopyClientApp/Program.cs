using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RCommerce.Tools.CopyClientApp
{
    class Program
    {
        private static void CopyWithRoboCopy(string src, string desc, IEnumerable<string> exludeDirs)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "robocopy.exe";
            startInfo.Arguments = $"{src} {desc} /XO /NJH /NP /e /xd {string.Join(" ", exludeDirs)}";
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            Process p = Process.Start(startInfo);
            while (!p.HasExited)
            {
                System.Threading.Thread.Sleep(500);
            }
        }
       
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
            //var projectPath = @"D:\works\CoreEcommerce\hosts\RCommerce.AppHost";

            var solutionPath = args[1];
            //var solutionPath = @"D:\works\CoreEcommerce";

            var targetDir = args[2];

            var modulesFolder = Path.Combine(projectPath, "Modules");
            if (!Directory.Exists(modulesFolder)) Directory.CreateDirectory(modulesFolder);

            var moduleNames = Directory.GetFiles(targetDir, "*.Module.*.dll").Select(i => Path.GetFileName(i));
            foreach (var moduleName in moduleNames)
            {
                var _desc = Path.Combine(projectPath, "Modules", moduleName);
                var _src = Path.Combine(targetDir, moduleName);
                File.Copy(_src, _desc, true);
            }
            
            const string clientApp = "ClientApp";
            var exludeDirs = new[] { "node_modules", "dist", "e2e"};

            //check if has clientApp folder, if not exists => copy template.
            var currentProjectClientAppPath = Path.Combine(projectPath, clientApp, "src");
            //if (!Directory.Exists(currentProjectClientAppPath))
            //{
                var templatePath = Path.Combine(solutionPath, "templates", clientApp);
                var src = templatePath;
                var desc = Path.Combine(projectPath, clientApp);
                CopyWithRoboCopy(src, desc, exludeDirs);
            // }

			exludeDirs = new[] { "node_modules", "dist", "e2e", "_internal" };
            var modulePath = Path.Combine(solutionPath, "modules");
            var modulesInProjectPath = Path.Combine(projectPath, "Modules");
            var moduleNamesInProject = Directory.GetFiles(modulesInProjectPath).Select(i => Path.GetFileNameWithoutExtension(i));

            foreach (var moduleName in moduleNamesInProject)
            {
                var clientModuleName = moduleName.Split(".").Last().ToLower();
                var srcModule = Path.Combine(solutionPath, "modules", moduleName, clientApp, "src", "app", clientModuleName);
                if (!Directory.Exists(srcModule)) continue;

                var descModule = Path.Combine(projectPath, clientApp, "src", "app", clientModuleName);

                CopyWithRoboCopy(srcModule, descModule, exludeDirs);
            }

        }
    }
}
