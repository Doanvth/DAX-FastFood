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
=======
builder.Services.AddDbContext<AppDbContext_Admin>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

>>>>>>> thanhluan
builder.Services.AddControllersWithViews();

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
<<<<<<< HEAD

app.MapControllerRoute(
   name: "areas",
   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=}/{id?}");
=======
app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
>>>>>>> thanhluan

app.Run();
