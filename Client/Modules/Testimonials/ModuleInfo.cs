using Oqtane.Models;
using Oqtane.Modules;

namespace Oqtane.Module.Corporate.Testimonials
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Corporate Theme - Testimonials",
            Description = "Add a Testimonials section to your Corporate Theme",
            Version = "10.2.6",
            PackageName = "Oqtane.Theme.Corporate"
        };
    }
}
