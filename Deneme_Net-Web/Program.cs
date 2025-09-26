using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



builder.Services.AddScoped<IKullaniciRepository, CoreKullanicilarRepo>();
builder.Services.AddScoped<IProductRepository, CoreProductRepo>();
builder.Services.AddScoped<ICategoryRepository, CoreCategoryRepo>();
builder.Services.AddScoped<ISizesRepository, CoreSizeRepo>();
builder.Services.AddScoped<IPhotoRepository, CorePhotoRepo>();
builder.Services.AddScoped<IColorsRepository, CoreColorsRepo>();

builder.Services.AddScoped<IKullaniciService, KullaniciManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<ISizesService, SizesManager>();
builder.Services.AddScoped<IPhotoService, PhotoManager>();
builder.Services.AddScoped<IColorService, ColorManager>();


/*Cookie Authentication*/
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opts =>
{
    opts.Cookie.Name = ".Deneme_Net_Web.auth";
    opts.ExpireTimeSpan=TimeSpan.FromMinutes(5);
    opts.SlidingExpiration=true;
    opts.LoginPath = "/Kullanici/Login";
    opts.LogoutPath = "/Kullanici/Logout";
    opts.AccessDeniedPath = "/Home/AccessDenied";//Rolünü kontrol eder



});


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

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=HomeIndex}/{id?}");

app.Run();
