using Oqtane.Models;
using Oqtane.Modules;

namespace Oqtane.Module.Corporate.Skills
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Corporate Theme - Skills",
            Description = "Add a Skills section to your Corporate Theme",
            Version = "10.2.6",
            PackageName = "Oqtane.Theme.Corporate"
        };
    }
}
