using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.Operator.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.AppServices.Product;
using App.Domain.Services.Product;
using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.AppServices.Permission;
using App.Domain.Core.Permission.Contracts.AppServices;
using App.Domain.Core.Permission.Contracts.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB; Initial Catalog=DotNetShopDb; Integrated Security=TRUE");
});

builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IColorRepository,ColorRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();
builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();

builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductSurenessService, ProductSurenessService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
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
