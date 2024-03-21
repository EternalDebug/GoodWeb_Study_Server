using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;

namespace Serv3.Pages
{
    [IgnoreAntiforgeryToken]
    public class ContactModel : PageModel
    {
        private readonly ILogger<ContactModel> _logger;

        
        public ContactModel(ILogger<ContactModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public record formDate(string first_name, string last_name, string email, string phone, string select_service, string select_price, string comments);

        public IActionResult OnPost(formDate fd)
        {
            /*using var sw = new StreamWriter("logs.csv", true);
            using var csvw = new CsvWriter(sw, CultureInfo.InvariantCulture);
            csvw.NextRecord();
            csvw.WriteRecord(fd);
            //Message = $"���� ���: {username}";*/
            return Content("<fieldset>" +
                " <div id='success_page'>" +
                " <h1>Email Sent Successfully.</h1> <p>Thank you <strong>$first_name</strong>, your message has been submitted to us.</p>" +
                " </div>" +
                " </fieldset>");
        }
    }
}