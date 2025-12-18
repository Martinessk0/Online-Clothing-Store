using ClothingStore.Core.Contracts;
using ClothingStore.Core.Models.Auth;
using ClothingStore.Core.Models.Cloudinary;
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
