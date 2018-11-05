using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RCommerce.BuildManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var buildPath = args[0];
            var modulePath = Path.Combine(args[1], "modules");
            var angularHostPath = Path.Combine(args[2], "ClientApp", "src", "app", "modules");
            var moduleNames = Directory.GetFiles(buildPath, "*.Module.*.dll").Select(i => Path.GetFileNameWithoutExtension(i));
            Parallel.ForEach(moduleNames, moduleName => {
                var moduleClientApp = Path.Combine(modulePath, moduleName, "ClientApp");
                var descModuleName = moduleName.Split('.').Last().ToLower();

                if (!Directory.Exists(moduleClientApp)) return;

                var srcDir = Path.Combine(moduleClientApp, "src", "app", descModuleName);

                if (!Directory.Exists(srcDir)) return;

                
                var descModulePath = Path.Combine(angularHostPath, descModuleName);
                foreach (string newPath in Directory.GetFiles(srcDir, "*.*", SearchOption.AllDirectories))
                {
                    var destName = newPath.Replace(srcDir, descModulePath);

                    if (!Directory.Exists(Path.GetDirectoryName(destName)))
                        Directory.CreateDirectory(Path.GetDirectoryName(destName));
                    
                    File.Copy(newPath, destName, true);
                }
            });
            
        }
        
    }
}
