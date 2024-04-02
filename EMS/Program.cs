using EMS.Dependency;
using EMS.Services.Implementation;
using EMS.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EMS.ConnectionString;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.RegisterServiceDependencies();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DBConnection>(
 options => options.UseSqlServer("name=ConnectionStrings:IMSConnection"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
   .AddEntityFrameworkStores<DBConnection>()
   .AddDefaultTokenProviders();


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
