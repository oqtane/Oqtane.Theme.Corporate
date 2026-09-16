using Oqtane.Models;
using Oqtane.Modules;

namespace Oqtane.Module.Corporate.FAQ
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Corporate Theme - FAQs",
            Description = "Add an FAQs section to your Corporate Theme",
            Version = "10.2.6",
            PackageName = "Oqtane.Theme.Corporate"
        };
    }
}
