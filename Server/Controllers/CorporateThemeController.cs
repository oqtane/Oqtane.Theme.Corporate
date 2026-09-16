using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Oqtane.Controllers;
using Oqtane.Infrastructure;
using Oqtane.Models;
using Oqtane.Repository;
using Oqtane.Shared;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Oqtane.Theme.Corporate.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class CorporateThemeController : ModuleControllerBase
    {
        private readonly ISettingRepository _SettingRepository;
		private readonly IWebHostEnvironment _environment;

		public CorporateThemeController(ISettingRepository SettingRepository, IWebHostEnvironment environment, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _SettingRepository = SettingRepository;
			_environment = environment;
        }

        // PUT api/<controller>/##
        [HttpPut("{siteId}")]
		[Authorize(Roles = RoleNames.Admin)]
		public void Put(int siteId)
        {
            var styles = new Dictionary<string, string>();
            var settings = _SettingRepository.GetSettings(EntityNames.Site, siteId);
            foreach (var setting in settings)
			{
				if (setting.SettingName.EndsWith("-color") && !string.IsNullOrEmpty(setting.SettingValue))
				{
					// ie. Namespace:root:--background-color or Namespace:.light-background:--background-color
					var key = setting.SettingName.Split(':');
					styles.Add(((key[1] == "root") ? ":" : "") + key[1], $"{key[2]}: {setting.SettingValue};");
				}
			}
			
            var path = Path.Combine(_environment.ContentRootPath, "wwwroot/Themes/Oqtane.Theme.Corporate/assets/css/override.css");
            var stylesheet = "";
            foreach (var style in styles)
            {
                stylesheet += style.Key + " {\n  " + style.Value + "\n}\n";
			}
			System.IO.File.WriteAllText(path, stylesheet);
        }
    }
}
