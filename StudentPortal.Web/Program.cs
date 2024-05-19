//This is the main file where we configure (set up) everything

using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); 

//Dependency injection vvv AddDbContext method takes in a type which is our connection session of DbContext class 
//Use options to tell the injected Db context which database we are going to create by using a connection string (info needed to connect to a database)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("StudentPortal")));
//After, go to NuGet package manager and type in 'Add-Migration "_Name of migration_"' 
//In order to see our Db, we must type in 'Update=Database'

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
    pattern: "{controller=Home}/{action=Index}/{id?}"); //by default go to home and index where it returns in the view folder, then home folder, and index views

app.Run();
