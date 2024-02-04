using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using APPTEST.Data;
using APPTEST.Areas.Identity.Data;



var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("APPTESTContextConnection") ?? throw new InvalidOperationException("Connection string 'APPTESTContextConnection' not found.");

builder.Services.AddDbContext<APPTESTContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<APPTESTUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<APPTESTContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


app.MapRazorPages(); //*************


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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
