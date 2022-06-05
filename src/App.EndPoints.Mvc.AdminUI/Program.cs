using App.Infrastructures.Database.SqlServer.Data;
using App.Infrastructures.Database.SqlServer.Repositories;
using App.Infrastructures.Database.SqlServer.Repositories.Contract;
using App.Infrastructures.Database.SqlServer.Ripository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer("Data Source=.\\sql2019; Initial Catalog=DotNetShopDb; Integrated Security=TRUE");
});
//builder.Services.AddSingleton<BrandRepository>();
builder.Services.AddScoped<BrandRepository>();
//builder.Services.AddTransient<BrandRepository>();

builder.Services.AddScoped<IColorRepository,ColorEfRepository>();
//builder.Services.AddScoped<IColorRepository,ColorInMemoryRepository>();

builder.Services.AddScoped<ITagRepository, TagRepository>();



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
