using ChampionsLeague.Data;
using ChampionsLeague.Repository;
using ChampionsLeague.Repository.DAO;
using ChampionsLeague.Repository.Interfaces;
using ChampionsLeague.Services;
using ChampionsLeague.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ChampionsLeague.Domain.DataDB;
using ChampionsLeague.Domain.EntitiesDB;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<ChampionLeagueDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<StadiumSectionDAO>();
builder.Services.AddScoped<MatchDAO>();
builder.Services.AddScoped<IDAO<Club>, ClubDAO>();
builder.Services.AddScoped<IDAO<Stadium>, StadiumDAO>();
builder.Services.AddScoped<IDAO<Order>, OrderDAO>();
builder.Services.AddScoped<IDAO<StadiumSection>, StadiumSectionDAO>();
builder.Services.AddScoped<IDAO<Match>, MatchDAO>();
builder.Services.AddScoped<IService<Stadium>, StadiumService>();
builder.Services.AddScoped<IService<Order>, OrderService>();
builder.Services.AddScoped<IService<StadiumSection>, StadiumSectionService>();
builder.Services.AddScoped<IService<Match>, MatchService>();
builder.Services.AddScoped<IClubDAO, ClubDAO>();
builder.Services.AddScoped<IClubService, ClubService>();
builder.Services.AddScoped<IOrderDAO, OrderDAO>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);








builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();






builder.Services.AddControllersWithViews();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
