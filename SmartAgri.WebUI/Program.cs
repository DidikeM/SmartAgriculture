using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartAgri.Business.Abstract;
using SmartAgri.Business.Concrete;
using SmartAgri.DataAccess.Abstract;
using SmartAgri.DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var constr = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContextFactory<SmartAgriContext>(option =>
{
    option.UseNpgsql(constr);
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
});

builder.Services.AddSingleton<ITopicDal, EfTopicDal>();
builder.Services.AddSingleton<IReplyDal, EfReplyDal>();

builder.Services.AddSingleton<IFormService, FormService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SmartAgriContext>();
    context.Database.Migrate();
    //SeedData.Initialize(services);
}

app.Run();
