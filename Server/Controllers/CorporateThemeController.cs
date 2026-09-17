using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Oqtane.Controllers;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Oqtane.Models;
using Oqtane.Repository;
using Oqtane.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Xml.Linq;

namespace Oqtane.Theme.Corporate.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class CorporateThemeController : ModuleControllerBase
    {
        private readonly ISettingRepository _SettingRepository;
		private readonly IWebHostEnvironment _environment;
		private readonly Alias _alias;

		public CorporateThemeController(ISettingRepository SettingRepository, IWebHostEnvironment environment, ITenantManager tenantManager, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _SettingRepository = SettingRepository;
			_environment = environment;
            _alias = tenantManager.GetAlias();
		}

        // PUT api/<controller>/##
        [HttpPut("{siteId}")]
		[Authorize(Roles = RoleNames.Admin)]
		public void Put(int siteId)
        {
			if (siteId == _alias.SiteId)
			{
				try
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

					_logger.Log(LogLevel.Information, this, LogFunction.Update, "Corporate Theme Stylesheet Updated");
				}
				catch (Exception ex)
				{
					_logger.Log(LogLevel.Error, this, LogFunction.Update, ex, "Corporate Theme Stylesheet Update Failed");
					HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				}
			}
			else
			{
				_logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Corporate Theme Stylesheet Update Attempt For Site {SiteId}", siteId);
				HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
			}
		}
    }
}
