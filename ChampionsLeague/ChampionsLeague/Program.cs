using AutoMapper;
using Azure.Identity;
using ChampionLeague.utils.Mail;
using ChampionLeague.utils.Mail.Interfaces;
using ChampionLeague.utils.PDF;
using ChampionLeague.utils.PDF.Interfaces;
using ChampionsLeague.Data;
using ChampionsLeague.Domain.DataDB;
using ChampionsLeague.Domain.EntitiesDB;
using ChampionsLeague.Repository;
using ChampionsLeague.Repository.DAO;
using ChampionsLeague.Repository.Interfaces;
using ChampionsLeague.Services;
using ChampionsLeague.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------------------------------------
// 1. Load Key Vault FIRST
// ---------------------------------------------------------
var keyVaultUrl = builder.Configuration["AzureKeyVault:VaultUri"];

if (!string.IsNullOrWhiteSpace(keyVaultUrl))
{
    builder.Configuration.AddAzureKeyVault(
        new Uri(keyVaultUrl),
        new DefaultAzureCredential());
}

// ---------------------------------------------------------
// 2. Read connection string from Key Vault
// ---------------------------------------------------------
var sqlConn = builder.Configuration["SqlConnectionString"];

if (string.IsNullOrWhiteSpace(sqlConn))
{
    throw new Exception("SqlConnectionString not found in Key Vault or configuration.");
}

// ---------------------------------------------------------
// 3. Email + PDF services
// ---------------------------------------------------------
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddTransient<IEmailSend, EmailSend>();
builder.Services.AddTransient<ICreatePDF, CreatePDF>();

// ---------------------------------------------------------
// 4. Localization
// ---------------------------------------------------------
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllersWithViews()
    .AddDataAnnotationsLocalization()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.SubFolder);

var supportedCultures = new[] { "nl", "en", "fr" };

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.SetDefaultCulture(supportedCultures[0])
           .AddSupportedCultures(supportedCultures)
           .AddSupportedUICultures(supportedCultures);
});

// ---------------------------------------------------------
// 5. Register DbContexts (AFTER Key Vault is loaded)
// ---------------------------------------------------------
builder.Services.AddDbContext<ChampionLeagueDbContext>(options =>
    options.UseSqlServer(sqlConn));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(sqlConn));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// ---------------------------------------------------------
// Identity (FINAL, CLEAN, NO DUPLICATES)
// ---------------------------------------------------------
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders()
.AddDefaultUI(); // Required for Identity UI
// ---------------------------------------------------------
// 7. Register DAOs + Services
// ---------------------------------------------------------
builder.Services.AddScoped<IClubDAO, ClubDAO>();
builder.Services.AddScoped<IDAO<Stadium>, StadiumDAO>();
builder.Services.AddScoped<IOrderDAO, OrderDAO>();
builder.Services.AddScoped<IMatchDAO, MatchDAO>();

builder.Services.AddScoped<IService<Stadium>, StadiumService>();
builder.Services.AddScoped<IService<Order>, OrderService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<IClubService, ClubService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

// ---------------------------------------------------------
// 8. MVC + Swagger
// ---------------------------------------------------------
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---------------------------------------------------------
// Build app
// ---------------------------------------------------------
var app = builder.Build();

app.UseRequestLocalization();

// ---------------------------------------------------------
// 9. Pipeline
// ---------------------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages().WithStaticAssets();

app.Run();
