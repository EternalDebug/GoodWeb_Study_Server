using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Serv3.Pages
{
    public class PortModel : PageModel
    {
        private readonly ILogger<PortModel> _logger;

        public PortModel(ILogger<PortModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}