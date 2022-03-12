using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UOW.Core.Interfaces;
using UOW.Infrastructure;
using UOW.Infrastructure.UOW;
using UOW.Service.AutoMapperProfile;
using UOW.Service.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PMSDbContext>(options =>
    options.UseInMemoryDatabase("demo"));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(ProjectService), typeof(ProjectService));

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

// Add services to the container.
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
