using Oqtane.Models;
using Oqtane.Modules;

namespace Oqtane.Module.Corporate.WhyUs
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Corporate Theme - Why Us",
            Description = "Add a Why Us section to your Corporate Theme",
            Version = "10.2.6",
            PackageName = "Oqtane.Theme.Corporate"
        };
    }
}
