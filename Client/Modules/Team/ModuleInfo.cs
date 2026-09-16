using Oqtane.Models;
using Oqtane.Modules;

namespace Oqtane.Module.Corporate.Team
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Corporate Theme - Team",
            Description = "Add a Team section to your Corporate Theme",
            Version = "10.2.6",
            PackageName = "Oqtane.Theme.Corporate"
        };
    }
}
