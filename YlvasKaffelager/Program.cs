using YlvasKaffelager.DbContext;
using YlvasKaffelager.DbContext.Interfaces;
using YlvasKaffelager.Repositories;
using YlvasKaffelager.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Samma inom sin 'request' men skiljer sig vid olika 'requests' 
builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
