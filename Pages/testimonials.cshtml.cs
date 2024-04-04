using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serv3.Data;

namespace Serv3.Pages
{
    public class TestiModel : PageModel
    {
        private readonly ILogger<TestiModel> _logger;
        private readonly DatabaseContext _context;

        public TestiModel(ILogger<TestiModel> logger, DatabaseContext db)
        {
            _logger = logger;
            _context = db;
        }

        public List<Testimonial> Testimonials { get; set; }

        public void OnGet()
        {
            Testimonials = _context.tests.AsNoTracking().ToList();
        }
    }
}
