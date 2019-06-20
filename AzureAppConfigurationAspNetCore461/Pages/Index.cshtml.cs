using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AzureAppConfigurationAspNetCore461.Pages
{
    public class IndexModel : PageModel
    {
        public const string MessageKey = "Message";

        private IConfiguration _configuration;

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void OnGet()
        {
            ViewData[MessageKey] = _configuration[MessageKey];
        }
    }
}
