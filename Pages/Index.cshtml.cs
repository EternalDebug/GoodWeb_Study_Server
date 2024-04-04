using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serv3.Data;

namespace Serv3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DatabaseContext _context;
        public List<Testimonial> Testimonials { get; set; }

        public IndexModel(ILogger<IndexModel> logger, DatabaseContext db)
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