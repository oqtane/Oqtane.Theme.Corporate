using Oqtane.Models;
using Oqtane.Modules;

namespace Oqtane.Module.Corporate.Portfolio
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Corporate Theme - Portfolio",
            Description = "Add a Portfolio section to your Corporate Theme",
            Version = "10.2.6",
            PackageName = "Oqtane.Theme.Corporate"
        };
    }
}
