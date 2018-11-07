using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RCommerce.Tools.CopyModules
{
    class Program
    {
        static void Main(string[] args)
        {
            var projectDir = args[0];
            var targetDir = args[1];

            var modulesFolder = Path.Combine(projectDir, "Modules");
            if (!Directory.Exists(modulesFolder)) Directory.CreateDirectory(modulesFolder);

            var moduleNames = Directory.GetFiles(targetDir, "*.Module.*.dll").Select(i => Path.GetFileName(i));

            Parallel.ForEach(moduleNames, moduleName => {
                var desc = Path.Combine(projectDir, "Modules", moduleName);
                var src = Path.Combine(targetDir, moduleName);
                File.Copy(src, desc, true);
            });
        }
    }
}
