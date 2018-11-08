using RCommerce.Module.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;

namespace RCommerce.Module.Core.Modules
{
    public interface IModuleConfigurationManager
    {
        IEnumerable<ModuleInfo> GetModules(string moduleFolder);

    }

    public class ModuleConfigurationManager : IModuleConfigurationManager
    {
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
