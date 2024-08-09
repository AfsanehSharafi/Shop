using Application.Interfaces.Contexts;
using Application.Visitors.GetTodayReport;
using Infrastructure.MappingProfile;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Contexts.MongoContext;
using Persistence.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IGetTodayReportService, GetTodayReportService>();
builder.Services.AddTransient(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));



#region connection String SqlServer
builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
string connection = builder.Configuration["ConnectionString:SqlServer"];
builder.Services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(connection));
#endregion

//mapper
builder.Services.AddAutoMapper(typeof(CatalogMappingProfile));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
