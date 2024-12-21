<<<<<<< HEAD
using DAX_FastFood.Data;
using Microsoft.EntityFrameworkCore;
using System;
=======
using Microsoft.EntityFrameworkCore;
using DAX_FastFood.Areas.Admin.Data;
>>>>>>> thanhluan

var builder = WebApplication.CreateBuilder(args);


<<<<<<< HEAD
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware c?u h?nh pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();  // Ð?m b?o r?ng Authentication Middleware ðý?c s? d?ng
app.UseAuthorization();   // Ð?m b?o r?ng Authorization Middleware ðý?c s? d?ng

app.UseAuthorization();
<<<<<<< HEAD

app.MapControllerRoute(
   name: "areas",
   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=}/{id?}");

app.Run();
