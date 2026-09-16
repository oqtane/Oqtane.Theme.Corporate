using System.Collections.Generic;
using Oqtane.Models;
using Oqtane.Themes;
using Oqtane.Shared;

namespace Oqtane.Theme.Corporate
{
    public class ThemeInfo : ITheme
    {
        public Models.Theme Theme => new Models.Theme
        {
            Name = "Corporate Theme",
            Version = "10.2.6",
            PackageName = "Oqtane.Theme.Corporate",
            ThemeSettingsType = "Oqtane.Theme.Corporate.ThemeSettings, Oqtane.Theme.Corporate.Client.Oqtane",
            ContainerSettingsType = "Oqtane.Theme.Corporate.ContainerSettings, Oqtane.Theme.Corporate.Client.Oqtane",
            Resources = new List<Resource>()
            {
                // Fonts
                new Stylesheet("https://fonts.googleapis.com/css2?family=Open+Sans:ital,wght@0,300;0,400;0,500;0,600;0,700;0,800;1,300;1,400;1,500;1,600;1,700;1,800&family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&family=Jost:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap"),
                // Stylesheets
                new Stylesheet("~/assets/vendor/bootstrap/css/bootstrap.min.css"),
                new Stylesheet("~/assets/vendor/bootstrap-icons/bootstrap-icons.css"),
                new Stylesheet("~/assets/vendor/aos/aos.css"),
                new Stylesheet("~/assets/vendor/glightbox/css/glightbox.min.css"),
                new Stylesheet("~/assets/vendor/swiper/swiper-bundle.min.css"),
                // Main Stylesheet
                new Stylesheet("~/assets/css/main.css"),
				new Stylesheet("~/assets/css/override.css"),
                // JavaScript
                new Script("~/assets/vendor/bootstrap/js/bootstrap.bundle.min.js"),
                new Script("~/assets/vendor/aos/aos.js"),
                new Script("~/assets/vendor/glightbox/js/glightbox.min.js"),
                new Script("~/assets/vendor/swiper/swiper-bundle.min.js"),
                new Script("~/assets/vendor/waypoints/noframework.waypoints.js"),
                new Script("~/assets/vendor/imagesloaded/imagesloaded.pkgd.min.js"),
                new Script("~/assets/vendor/isotope-layout/isotope.pkgd.min.js"),
                new Script("~/assets/vendor/purecounter/purecounter.js"),
                new Script("~/assets/vendor/countdown/countdown.js"),
                // Main JavaScript 
                new Script("~/assets/js/main.js", "", "", ResourceLocation.Body, ResourceLoadBehavior.Always, null, "", "", RenderModes.Static),
                new Script("~/assets/js/interop.js", "", "", ResourceLocation.Body, ResourceLoadBehavior.None, null, "", "", RenderModes.Interactive)
            }
        };
    }
}
