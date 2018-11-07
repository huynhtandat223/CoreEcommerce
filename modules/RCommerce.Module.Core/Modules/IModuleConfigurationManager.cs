using Newtonsoft.Json;
using RCommerce.Module.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace RCommerce.Module.Core.Modules
{
    public interface IModuleConfigurationManager
    {
        IEnumerable<ModuleInfo> GetModules();
        IEnumerable<ModuleInfo> GetModules(string moduleFolder);

    }

    public class ModuleConfigurationManager : IModuleConfigurationManager
    {
        public static readonly string ModulesFilename = "module.json";

        public IEnumerable<ModuleInfo> GetModules()
        {
            var modulesPath = Path.Combine(GlobalConfiguration.ContentRootPath, ModulesFilename);
            using (var reader = new StreamReader(modulesPath))
            {
                string content = reader.ReadToEnd();
                dynamic modulesData = JsonConvert.DeserializeObject(content);
                foreach (dynamic module in modulesData)
                {
                    yield return new ModuleInfo
                    {
                        Id = module.id,
                        Version = Version.Parse(module.version.ToString())
                    };
                }
            }
        }

        public IEnumerable<ModuleInfo> GetModules(string moduleFolder)
        {
            return Directory.GetFiles(moduleFolder)
                .Select(i => new ModuleInfo {
                    Id = Path.GetFileName(i),
                    IsBundledWithHost = false,
                    Version = Version.Parse("1.0"),
                    Name = i,
                    Assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(i)
                });
        }
    }
}
