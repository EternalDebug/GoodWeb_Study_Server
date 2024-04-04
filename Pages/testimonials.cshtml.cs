using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serv3.Data;
using System.Globalization;

namespace Serv3.Pages
{
    [AutoValidateAntiforgeryToken]
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

        public record formTest(string title, string name, string occupation, string test_text);

        public IActionResult OnPost(formTest ft)
        {
            if (ft.name is null)
                return Content("<div class=" + "error_message" + ">Attention! You must enter your name.</div>");
            if (ft.occupation is null)
                return Content("<div class=" + "error_message" + ">Attention! You must enter your occupation.</div>");
            if (ft.test_text is null)
                return Content("<div class=\"error_message\">Attention! Please enter your testimonial.</div>");
            if (ft.title is null)
                return Content("<div class=\"error_message\">Attention! Please enter your testimonial title.</div>");

            string srcA = "ava.png";
            _context.tests.Add(new Testimonial { title = ft.title, name = ft.name, Occ = ft.occupation, text = ft.test_text, src = srcA});
            _context.SaveChanges();

            using var sw = new StreamWriter("logs.csv", true);
            using var csvw = new CsvWriter(sw, CultureInfo.InvariantCulture);
            csvw.NextRecord();
            csvw.WriteRecord(ft);

            /*return Content("<fieldset>" +
                " <div id='success_page'>" +
                " <h1>Email Sent Successfully.</h1> <p>Thank you <strong>" +
                ft.name.ToString() +
                "</strong>, your testimonial has been submitted to us.</p>" +
                " </div>" +
                " </fieldset>");*/
            
            return RedirectToPage("./Testimonials");
        }
    }
}
