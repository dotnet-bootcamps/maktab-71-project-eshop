using App.Domain.AppServices.Product;
using App.Domain.Core.ProductAgg.Contracts.ApplicationServices;
using App.Domain.Core.ProductAgg.Contracts.Repositories;
using App.Domain.Core.ProductAgg.Contracts.Services;
using App.Domain.Core.UserAgg.Contracts.Repositories;
using App.Domain.Services.Product;
using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer("Data Source=MASOUD;Initial Catalog=DotNetShop;Persist Security Info=True;User ID=sa;Password=25915491");
});

builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IColorRepository,ColorEfRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();
builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IBrandApplicationService, BrandApplicationService>();


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
