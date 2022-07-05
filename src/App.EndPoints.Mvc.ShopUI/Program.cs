using App.Domain.AppServices.BaseData;
using App.Domain.AppServices.Operator;
using App.Domain.AppServices.Product;
using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.Operator.Contract.AppServices;
using App.Domain.Core.Operator.Contract.Repositories;
using App.Domain.Core.Operator.Contract.Services;
using App.Domain.Core.Permission.Contarcts.Repositories;
using App.Domain.Core.Permission.Contarcts.Services;
using App.Domain.Core.Product.Contacts.AppServices;
using App.Domain.Core.Product.Contacts.Repositories.Category;
using App.Domain.Core.Product.Contacts.Repositories.Color;
using App.Domain.Core.Product.Contacts.Repositories.Model;
using App.Domain.Core.Product.Contacts.Repositories.Product;
using App.Domain.Core.Product.Contacts.Services;
using App.Domain.Services.BaseData;
using App.Domain.Services.Operator;
using App.Domain.Services.Permission;
using App.Domain.Services.Product;
using App.Infrastructures.Database.Repos.Ef.BaseData;
using App.Infrastructures.Database.Repos.Ef.Operator;
using App.Infrastructures.Database.Repos.Ef.Permission;
using App.Infrastructures.Database.Repos.Ef.Product.Category;
using App.Infrastructures.Database.Repos.Ef.Product.Color;
using App.Infrastructures.Database.Repos.Ef.Product.Model;
using App.Infrastructures.Database.Repos.Ef.Product.Product;
using App.Infrastructures.Database.SqlServer.Data;

using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer("Data Source=192.168.88.132;Initial Catalog=DotNetShopDb;Persist Security Info=True;User ID=sa;Password=25915491Em?");
});





builder.Services.AddScoped<IProductAppService, ProductAppService>();

#region BaseData
builder.Services.AddScoped<IBaseDataAppService, BaseDataAppService>();
builder.Services.AddScoped<IBaseDataService, BaseDataService>();
builder.Services.AddScoped<IBaseDataCommandRepository, BaseDataCommandRepository>();
builder.Services.AddScoped<IBaseDataQueryRepository, BaseDataQueryRepository>();
#endregion BaseData
#region Brand
builder.Services.AddScoped<IBrandAppService, BrandAppService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IBrandCommandRepository, BrandCommandRepository>();
builder.Services.AddScoped<IBrandQueryRepository, BrandQueryRepository>();
#endregion Brand
#region Product
#region Category
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
builder.Services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
#endregion
#region Color
builder.Services.AddScoped<IColorAppService, ColorAppService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IColorCommandRepository, ColorCommandRepository>();
builder.Services.AddScoped<IColorQueryRepository, ColorQueryRepository>();
#endregion
#region Model 
builder.Services.AddScoped<IModelAppService, ModelAppService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IModelCommandRepository, ModelCommandRepository>();
builder.Services.AddScoped<IModelQueryRepository, ModelQueryRepository>();
#endregion
#region Product 
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
builder.Services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
#endregion
#endregion
#region Operator 
builder.Services.AddScoped<IOperatorAppService, OperatorAppService>();
builder.Services.AddScoped<IOperatorService, OperatorService>();
builder.Services.AddScoped<IOperatorCommandRepository, OperatorCommandRepository>();
builder.Services.AddScoped<IOperatorQueryRepository, OperatorQueryRepository>();
#endregion
#region Permission
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
#endregion Permission



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


//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//      name: "areas",
//      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//    );
//});

app.MapAreaControllerRoute(
    name: "areas",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
