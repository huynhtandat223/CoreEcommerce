﻿using RCommerce.Module.Core.Entities;
using System.Collections.Generic;

namespace RCommerce.Module.Core
{
    public static class GlobalConfiguration
    {
        static GlobalConfiguration()
        {
            Modules = new List<ModuleInfo>();
        }

        public static IList<ModuleInfo> Modules { get; set; } = new List<ModuleInfo>();

        public static IList<SimpleCulture> SimpleCultures { get; set; } = new List<SimpleCulture>();

        public static string WebRootPath { get; set; }

        public static string ContentRootPath { get; set; }
    }
}
