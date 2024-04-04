using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serv3.Data;

namespace Serv3.Pages
{
    public class AboutUsModel : PageModel
    {
        private readonly ILogger<AboutUsModel> _logger;
        private readonly DatabaseContext _context;
        public List<Testimonial> Testimonials { get; set; }

        public AboutUsModel(ILogger<AboutUsModel> logger, DatabaseContext db)
        {
            _logger = logger;
            _context = db;
        }

        public void OnGet()
        {
            Testimonials = _context.tests.AsNoTracking().ToList();
        }
    }
}