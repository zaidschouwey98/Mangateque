using Microsoft.EntityFrameworkCore;
using Mangateque.Models;
using Microsoft.AspNetCore.Identity;
using Mangateque.Data;
<<<<<<< HEAD
using Mangateque.Areas.Identity.Data;
=======
>>>>>>> tmp

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<mangatekContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(builder.Configuration.GetConnectionString("MvcMangaContext"), new MySqlServerVersion(new Version(8, 0, 27)))
// The following three options help with debugging, but should
// be changed or removed for production.
);
<<<<<<< HEAD
builder.Services.AddDefaultIdentity<MangatequeUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AuthContext>();builder.Services.AddDbContext<AuthContext>(options =>
=======


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AuthContext>();

builder.Services.AddDbContext<AuthContext>(options =>
>>>>>>> tmp
    options.UseMySql(builder.Configuration.GetConnectionString("MvcMangaContext"), new MySqlServerVersion(new Version(8, 0, 27))));
// Add services to the container.
builder.Services.AddControllersWithViews();



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

<<<<<<< HEAD
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapRazorPages();

});
=======
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
>>>>>>> tmp

app.Run();
