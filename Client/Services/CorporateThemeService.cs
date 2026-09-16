using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;

namespace Oqtane.Theme.Corporate.Services
{
    public interface ICorporateThemeService
    {
        Task UpdateStylesheetAsync(int siteId);
    }

    public class CorporateThemeService : ServiceBase, ICorporateThemeService, IService
    {
        public CorporateThemeService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("CorporateTheme");

        public async Task UpdateStylesheetAsync(int siteId)
        {
            await PutAsync($"{Apiurl}/{siteId}");
        }
    }
}
