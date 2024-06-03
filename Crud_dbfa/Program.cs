using Crud_dbfa.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StudentDBFContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Crud_with_ASP_NET_CORE_DBF"))
//builder.Configuration.GetConnectionString("Crud_with_ASP_NET_CORE_DBF")
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
