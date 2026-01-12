using ChineseSale.Data;
using ChineseSale.Model;
using ChineseSale.Reposetorys;
using ChineseSale.Repositories;
using ChineseSale.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ===== DB Context =====
builder.Services.AddDbContext<ChineseSaleDbContext>(options =>
    options.UseSqlServer("Server=DESKTOP-P3U8QIP;Database=ChineseSale_329213227;" +
    "Integrated Security=True;Persist Security Info=False;TrustServerCertificate=True;"));
//builder.Services.AddDbContext<ChineseSaleDbContext>(options =>
//    options.UseSqlServer("Server=CYPY;Database=ChineseSale_329213227;" +
//    "Integrated Security=True;Persist Security Info=False;TrustServerCertificate=True;"));

// ===== Services & Repositories =====
builder.Services.AddScoped<IGiftReposetory, GiftReposetory>();
builder.Services.AddScoped<IGiftServices, GiftServices>();
builder.Services.AddScoped<ICategoryReposetory, CategoryReposetory>();
builder.Services.AddScoped<ICategoryServices, CategoryService>();
builder.Services.AddScoped<IDonorReposetory, DonorReposetory>();
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IPackegeReposetory, PackegeReposetory>();
builder.Services.AddScoped<IPackegeService, PackegeService>();
builder.Services.AddScoped<IUserReposerory, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBasketReposetory, BasketReposetory>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IOrderReposetory, OrderReposetory>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPrizeReposetory, PrizeReposetory>();
builder.Services.AddScoped<IPrizeService, PrizeService>();
builder.Services.AddScoped<IEmailService, EmailService>();





builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ===== Swagger עם JWT =====
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChineseSale API V1", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT token"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// ===== JWT Authentication =====
var jwtKey = builder.Configuration["Jwt:Key"]
             ?? throw new InvalidOperationException("JWT key not found in appsettings.json");

var key = Encoding.UTF8.GetBytes(jwtKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});
// ===== CORS =====
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>policy
              .WithOrigins("http://localhost:4200")   // מאפשר כל מקור, אפשר לשנות לכתובת Angular שלך
              .AllowAnyMethod()  
              .AllowAnyHeader()); 
});


// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
        .Build())
    .Enrich.FromLogContext()
    //     .WriteTo.Console()
    //     .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();


builder.Services.AddAuthorization();

var app = builder.Build();

app.UseStaticFiles();

app.UseCors("AllowAngular");


// ===== Middleware =====
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChineseSale API V1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthentication(); // חייב להיות לפני UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.Run();
