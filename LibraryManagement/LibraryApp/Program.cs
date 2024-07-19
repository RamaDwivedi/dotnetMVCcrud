using LibraryInfra;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using LibraryInfra.Interfaces;
using LibraryInfra.Repositories;
using LibraryDomain.Interfaces;
using LibraryDomain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var configuration=new ConfigurationBuilder().SetBasePath(builder.Environment.ContentRootPath)
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

builder.Services.AddDbContext<AppDbContext>(options=>{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});   

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookServices, BookService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
