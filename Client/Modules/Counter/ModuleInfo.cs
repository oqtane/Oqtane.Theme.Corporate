using Oqtane.Models;
using Oqtane.Modules;

namespace Oqtane.Module.Corporate.Counter
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Corporate Theme - Counter",
            Description = "Add a Counter section to your Corporate Theme",
            Version = "10.2.6",
            PackageName = "Oqtane.Theme.Corporate"
        };
    }
}
