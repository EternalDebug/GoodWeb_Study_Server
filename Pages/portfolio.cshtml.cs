using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serv3.Data;
using System.IO;
using System.Text.Json;
using static Serv3.Data.JsonContext;
using static Serv3.Pages.PortModel;

namespace Serv3.Pages
{
    public class PortModel : PageModel
    {
        private readonly ILogger<PortModel> _logger;
        private readonly JsonContext _JsonContext;
        public List<Portfolio> portfolios { get; set; }

        public PortModel(ILogger<PortModel> logger, JsonContext jc)
        {
            _logger = logger;
            _JsonContext = jc;
        }

        public void OnGet()
        {
            portfolios = _JsonContext.portfolios;
        }
    }
}