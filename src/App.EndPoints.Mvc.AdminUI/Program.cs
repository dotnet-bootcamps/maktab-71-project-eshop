using Microsoft.EntityFrameworkCore;

using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Permission.Contracts.Repositories;
using App.Domain.Core.Permission.Contracts.Services;
using App.Domain.Core.User.Contracts.Repositories;

using App.Domain.Services.Permission;
using App.Domain.Services.BaseData;
using App.Domain.Services.Product;

using App.Domain.AppServices.Product;
using App.Domain.AppServices.BaseData;

using App.Infrastructures.Database.SqlServer.Data;

using App.Infrastructure.Repos.Ef.BaseData;
using App.Infrastructure.Repos.Ef.Product;
using App.Infrastructure.Repos.Ef.Permission;
using App.Infrastructure.Repos.Ef.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB; Initial Catalog=DotNetShopDb; Integrated Security=TRUE");
});

#region Operator
builder.Services.AddScoped<IOperatorCommandRepository, OperatorCommandRepository>();
builder.Services.AddScoped<IOperatorQueryRepository, OperatorQueryRepository>();
#endregion
#region Permission
builder.Services.AddScoped<IPermissionCommandRepository, PermissionCommandRepository>();
builder.Services.AddScoped<IPermissionQueryRepository, PermissionQueryRepository>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
#endregion
#region Brand
builder.Services.AddScoped<IBrandCommandRepository, BrandCommandRepository>();
builder.Services.AddScoped<IBrandQueryRepository, BrandQueryRepository>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IBrandAppService, BrandAppService>();
#endregion
#region Category
builder.Services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
builder.Services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
#endregion
#region Color
builder.Services.AddScoped<IColorCommandRepository, ColorCommandRepository>();
builder.Services.AddScoped<IColorQueryRepository, ColorQueryRepository>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IColorAppService, ColorAppService>();
#endregion
#region Collection
builder.Services.AddScoped<ICollectionCommandRepository, CollectionCommandRepository>();
builder.Services.AddScoped<ICollectionQueryRepository, CollectionQueryRepository>();
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<ICollectionAppService, CollectionAppService>();
#endregion
#region Model
builder.Services.AddScoped<IModelCommandRepository, ModelCommandRepository>();
builder.Services.AddScoped<IModelQueryRepository, ModelQueryRepository>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IModelAppService, ModelAppService>();
#endregion
#region Tag
builder.Services.AddScoped<ITagCommandRepository, TagCommandRepository>();
builder.Services.AddScoped<ITagQueryRepository, TagQueryRepository>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<ITagAppService, TagAppService>();
#endregion
#region Product
builder.Services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
builder.Services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductAppService, ProductAppService>();
#endregion





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
