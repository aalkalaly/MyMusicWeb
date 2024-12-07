using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyMusicWeb.Infrastructure;
using MyMusicWeb.Services.Data;
using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWeb.Services.Mapping;
using MyMusicWebData;

using MyMusicWebDataModels;
using MyMusicWebViewModels;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})

    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
    //.AddSignInManager<SignInManager<ApplicationUser>>()
    //.AddUserManager<UserManager<ApplicationUser>>();
builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.LoginPath = "/Identity/Account/Login";
});

builder.Services.RegisterRepostitories(typeof(ApplicationUser).Assembly);
builder.Services.AddScoped<IMusicInstrumentsService, MusicInstrumentsService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IEventService, EventService>();

builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using(var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "User", "Organisation" };
    foreach (var role in roles)
    {
        if(!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

app.Run();
