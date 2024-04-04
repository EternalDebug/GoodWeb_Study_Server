using System.Collections.Generic;
using System.IO;
using System.Text.Json;
//using static Serv3.Data.JsonContext;
using static Serv3.Pages.PortModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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

    public class Testimonial
    {
        public int Id { get; set; }
        public string title { get; set; } //заголовок
        public string text { get; set; } //публикация
        public string src { get; set; } //аватарка
        public string name { get; set; } // кто написал
        public string Occ { get; set; } //его должность?

    }

    public class DatabaseContext : DbContext
    {
        public DbSet<Testimonial> tests { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Filename=MyDatabase.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Testimonial>().ToTable("testimonials");
        }
    }
}
