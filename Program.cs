using Microsoft.EntityFrameworkCore;
using Serv3.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

PopulateDB();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton(new JsonContext());

//builder.Services.AddEntityFrameworkSqlite().AddDbContext<DatabaseContext>();
//using (var client = new DatabaseContext())
//{
//    client.Database.EnsureCreated();
//}

builder.Services.AddSqlite<DatabaseContext>(
                builder.Configuration.GetConnectionString("Default"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


static void PopulateDB()
{
    IConfiguration config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
    .Build();

    var options = new DbContextOptionsBuilder<DatabaseContext>()
        .UseSqlite(config.GetConnectionString("Default"))
    .Options;

    using (var context = new DatabaseContext(options))
    {
        context.Database.EnsureCreated();
        context.Database.Migrate();

        InitBD(context);

        context.SaveChanges();
    }
}

static void InitBD(DatabaseContext context)
{
    if (context.tests.Count() == 0)
    {
        var test = new Testimonial[]
        {
            new Testimonial{ title = " Wonderful Support!",
                text = "They have got my project on time with the competition with a sed highly skilled, and experienced & professional team.",
                src = "testi_01.png", name = "James Fernando ", Occ = "- Manager of Racer"},
            new Testimonial{ title = " Awesome Services!",
                text = "Explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you completed.",
                src = "testi_02.png", name = "Jacques Philips ", Occ = "- Designer"},
            new Testimonial{ title = " Great & Talented Team!",
                text = "The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure. ",
                src = "testi_03.png", name = "Venanda Mercy ", Occ = "- Newyork City"}
        };

        context.tests.AddRange(test);
        context.SaveChanges();

    }
    else return;
}
