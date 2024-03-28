using System.Collections.Generic;
using System.IO;
using System.Text.Json;
//using static Serv3.Data.JsonContext;
using static Serv3.Pages.PortModel;

namespace Serv3.Data
{
    public class JsonContext
    {
        public class Portfolio
        {
            public string href { get; set; }
            public string text { get; set; }
            public string smalltext { get; set; }
            public string cat { get; set; }

        }

        public JsonContext() 
        {
            var fs = new FileStream("portfolio.json", FileMode.Open);
            portfolios =  JsonSerializer.Deserialize<List<Portfolio>>(fs);
        }

        public List<Portfolio> portfolios { get; set; }

    }
}
