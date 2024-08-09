using Application.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Infrastructure.IdentityConfigs;
using Persistence.Contexts.MongoContext;
using Application.Visitors.SaveVisitorInfo;
using Website.Endpoint.Utilities.Filters;
using Website.Endpoint.Hubs;
using Microsoft.AspNetCore.Builder;
using Application.Visitors.VisitorOnline;
using Website.Endpoint.Utilities.Filters.Middlewares;
using Application.Catalogs.CatalogTypes.CrudService;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
#region Connection String
builder.Services.AddControllersWithViews();
var connnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(connnection));
builder.Services.AddDbContext<IdentityDatabaseContext>(option=>option.UseSqlServer(connnection));
builder.Services.AddIdentityService(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.ConfigureApplicationCookie(option =>
{
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    option.LoginPath = "/account/login";
    option.AccessDeniedPath = "/Account/AccessDenied";
    option.SlidingExpiration = true;
});


#endregion
builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
builder.Services.AddTransient<ISaveVisitorInfoService, SaveVisitorInfoService>();
builder.Services.AddScoped<SaveVisitorFilter>();
builder.Services.AddSignalR();
builder.Services.AddTransient<IIVisitorOnlineService, VisitorOnlineService>();
builder.Services.AddTransient<ICatalogTypeService, CatalogTypeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSetVisitorId();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapHub<OnlineVisitorHub>("/chatHub");
});



app.Run();
