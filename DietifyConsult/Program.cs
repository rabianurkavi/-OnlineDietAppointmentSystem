using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Net;

StripeConfiguration.ApiKey = "sk_test_51PJiMFKxKaGWHxtVtuGR9OoFn9IFe6X7Ggj2uXrxJXY7bXtHg7mAQEScSEdueGg7zBknUvN9PGT1M4iCMfWgKyT400hyyZ2y2a";
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DietifyConsultContext");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();//session için
builder.Services.AddMvc(config =>//authorize iþlemleri
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddMvc();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Login/Index/";

});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.LoginPath = "/Login/Index/";
    options.SlidingExpiration = true;
});
builder.Services.AddDbContext<DietifyConsultContext>();
//builder.Services.AddDbContext<DietifyConsultContext>(options=>
//options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1","?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();//oturum açýp claimleri kaydetmek için
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
