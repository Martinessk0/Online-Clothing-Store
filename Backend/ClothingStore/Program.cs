using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Auth;
using ClothingStore.Core.Models.Cloudinary;
using ClothingStore.Core.Models.Email;
using ClothingStore.Core.Models.Paypal;
using ClothingStore.Core.Models.Speedy;
using ClothingStore.Core.Services;
using ClothingStore.Infrastructure;
using ClothingStore.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using ClothingStore.Core.Models.Email;
using ClothingStore.Infrastructure.Data.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});


string connectionString;

if (builder.Environment.IsDevelopment())
{
    connectionString = builder.Configuration["Database:Dev"];
}
else
{
    connectionString = builder.Configuration["Database:Prod"];
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<CloudinarySettings>(
    builder.Configuration.GetSection("Cloudinary"));

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JWTSettingDev"));

builder.Services.Configure<SpeedyOptions>(
    builder.Configuration.GetSection("Speedy"));

builder.Services.Configure<PayPalOptions>(
    builder.Configuration.GetSection("PayPal"));

builder.Services.Configure<PayPalCleanupOptions>(
    builder.Configuration.GetSection("PayPalCleanup"));

builder.Services.Configure<EmailOptions>(
    builder.Configuration.GetSection("Email"));

var jwtSettings = builder.Configuration
    .GetSection("JWTSettingDev")
    .Get<JwtSettings>();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.ValidIssuer,
            ValidAudience = jwtSettings.ValidAudience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.SecurityKey)),
            RoleClaimType = ClaimTypes.Role,
            NameClaimType = ClaimTypes.Name,
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ConfirmedEmail", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.Requirements.Add(new ConfirmedEmailRequirement());
    });
});

builder.Services.AddScoped<IAuthorizationHandler, ConfirmedEmailHandler>();


builder.Services.AddControllers()
     .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
     });
builder.Services.AddApplicationServices();
builder.Services.AddHttpClient<ISpeedyService, SpeedyService>((sp, http) =>
{
    var opt = sp.GetRequiredService<IOptions<SpeedyOptions>>().Value;
    http.BaseAddress = new Uri(opt.BaseUrl.TrimEnd('/') + "/");
});
builder.Services.AddHttpClient<IPayPalService, PayPalService>((sp, http) =>
{
    var opt = sp.GetRequiredService<IOptions<PayPalOptions>>().Value;
    http.BaseAddress = new Uri(opt.BaseUrl.TrimEnd('/') + "/");
});
builder.Services.AddHostedService<PendingPayPalOrdersCleanupService>();

builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapGet("/", () => Results.Redirect("/swagger"))
          .ExcludeFromDescription();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
