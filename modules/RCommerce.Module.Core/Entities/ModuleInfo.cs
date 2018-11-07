using System;
using System.Reflection;

namespace RCommerce.Module.Core.Entities
{
    public class ModuleInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Version Version { get; set; }
        public Assembly Assembly { get; set; }
        public bool IsBundledWithHost { get; set; }

    }
}
