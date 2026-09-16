using Oqtane.Models;
using Oqtane.Modules;

namespace Oqtane.Module.Corporate.CTA
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Corporate Theme - Call To Action",
            Description = "Add a Call To Action section to your Corporate Theme",
            Version = "10.2.6",
            PackageName = "Oqtane.Theme.Corporate"
        };
    }
}
