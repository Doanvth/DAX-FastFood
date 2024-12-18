using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DAX_FastFood.Data;
using DAX_FastFood.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// C?u h?nh DbContext v?i SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// C?u h?nh Identity (�?m b?o s? d?ng IdentityDbContext v?i Entity Framework)
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Th�m d?ch v? cho Controllers v� Views v?i Razor Runtime Compilation
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

// Th�m quy?n v� ch�nh s�ch cho c�c role
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ManagerOrAdmin", policy => policy.RequireRole("Manager", "Admin"));
    options.AddPolicy("EmployeeOnly", policy => policy.RequireRole("Employee"));
});

// C?u h?nh Authentication v?i Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // C?p nh?t ��?ng d?n �?n trang login trong Admin area
        options.LoginPath = "/Admin/Account/Login"; // ��?ng d?n �?n trang ��ng nh?p trong Area Admin
        options.AccessDeniedPath = "/Admin/Account/AccessDenied"; // ��?ng d?n �?n trang t? ch?i quy?n truy c?p
    });

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
app.UseAuthentication();  // �?m b?o r?ng Authentication Middleware ��?c s? d?ng
app.UseAuthorization();   // �?m b?o r?ng Authorization Middleware ��?c s? d?ng

// �?nh ngh?a route m?c �?nh cho Controller v� Action
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ch?y ?ng d?ng
app.Run();
