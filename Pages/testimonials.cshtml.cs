using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Serv3.Pages
{
    public class TestiModel : PageModel
    {
        private readonly ILogger<TestiModel> _logger;

        public TestiModel(ILogger<TestiModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
