using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCSQ014_RazorViews.Data;
using MVCSQ014_RazorViews.Extensions;
using MVCSQ014_RazorViews.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IBookService, BookService>();
ServiceExtensions.AddDbContext(builder.Services, builder);
ServiceExtensions.AddIdentity(builder.Services);
ServiceExtensions.AddAuth(builder.Services);
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("CanEdit", policy => policy.RequireClaim("CanEdit", new string[] { "True" }));
});
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
