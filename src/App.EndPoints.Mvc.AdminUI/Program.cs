using App.Domain.AppServices.BaseData;
using App.Domain.AppServices.Product;
using App.Domain.Core.BaseData.Contarcts.AppServices;
using App.Domain.Core.BaseData.Contarcts.Repositories;
using App.Domain.Core.BaseData.Contarcts.Services;
using App.Domain.Core.Operator.Contract.Repositories;
using App.Domain.Core.Permission.Contarcts.Repositories;
using App.Domain.Core.Permission.Contarcts.Services;
using App.Domain.Core.Product.Contacts.AppServices;

using App.Domain.Services.BaseData;
using App.Domain.Services.Permission;
using App.Infrastructures.Database.Repos.Ef.BaseData;
using App.Infrastructures.Database.Repos.Ef.Permission;
using App.Infrastructures.Database.SqlServer.Data;

using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB; Initial Catalog=DotNetShopDb; Integrated Security=TRUE");
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
