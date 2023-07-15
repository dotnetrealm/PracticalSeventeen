using Microsoft.EntityFrameworkCore;
using PracticalSeventeen.Data.Interfaces;
using PracticalSeventeen.Data.Models;
using PracticalSeventeen.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

//Configure DBContext
builder.Services.AddDbContextPool<ApplicationDBContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Create authentication schema
builder.Services.AddAuthentication("AccountCookie").AddCookie("AccountCookie", opt =>
{
    opt.Cookie.Name = "AccountCookie";
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    opt.AccessDeniedPath = "/Account/AccessDenied";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    //Global exception page
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Account/PageNotFound");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
