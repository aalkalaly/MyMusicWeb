using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyMusicWeb.Infrastructure;
using MyMusicWeb.Services.Data;
using MyMusicWeb.Services.Data.Interfaces;
using MyMusicWeb.Services.Mapping;
using MyMusicWebData;
using MyMusicWebData.Configurations;
using MyMusicWebData.Seeder;
using MyMusicWebData.Seeder.DataTransferObject;
using MyMusicWebDataModels;
using MyMusicWebViewModels;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
string jsonPathEvent = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                builder.Configuration.GetValue<string>("Seed:EventJson")!);
string jsonPathGenra = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                builder.Configuration.GetValue<string>("Seed:GenraJson")!);
string jsonPathLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                builder.Configuration.GetValue<string>("Seed:LocationJson")!);
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
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager<SignInManager<IdentityUser>>()
    .AddUserManager<UserManager<IdentityUser>>();
builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.LoginPath = "/Identity/Account/Login";
});

builder.Services.RegisterRepostitories(typeof(ApplicationUser).Assembly);
builder.Services.AddScoped<IMusicInstrumentsService, MusicInstrumentsService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<MyMusicWeb.Services.Data.Interfaces.IUserService,
                          MyMusicWeb.Services.Data.UserService>();

builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly, typeof(ImportEventDto).Assembly, typeof(ImportLocationDto).Assembly, typeof(ImportGenraDto).Assembly);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


using(var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    AssignAdminRole.AdminRoleSeeder(service);
    await DbSeeder.SeedEventAsync(service, jsonPathEvent, jsonPathGenra, jsonPathLocation);

}

app.Run();