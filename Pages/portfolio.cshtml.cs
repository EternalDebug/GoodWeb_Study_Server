using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

        private readonly DatabaseContext _context;
        public List<Testimonial> Testimonials { get; set; }

        public PortModel(ILogger<PortModel> logger, JsonContext jc, DatabaseContext db)
        {
            _logger = logger;
            _JsonContext = jc;
            _context = db;
        }

        public void OnGet()
        {
            portfolios = _JsonContext.portfolios;
            Testimonials = _context.tests.AsNoTracking().ToList();
        }
    }
}