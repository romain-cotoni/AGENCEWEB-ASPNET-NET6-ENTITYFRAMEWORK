using agenceWebEF.Models;
using agenceWebEF.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext configuration
builder.Services.AddDbContext<agencewebContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Authentication and authorization
builder.Services.AddIdentity<Utilisateur, IdentityRole>().AddEntityFrameworkStores<agencewebContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
//builder.Services.AddMvc();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Login/";
    options.AccessDeniedPath = "/Login/Login";
});

builder.Services.AddScoped<IEntrepriseRepository, EntrepriseRepository>();
builder.Services.AddScoped<ICoordonneesRepository, CoordonneesRepository>();
builder.Services.AddScoped<IProjetRepository, ProjetRepository>();

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
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//SEED
AppDbInitializer.Seed(app);
AppDbInitializer.SeedUsersAndRoles(app).Wait();

app.Run();
