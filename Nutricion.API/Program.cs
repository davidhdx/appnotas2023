using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Nutricion.API.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => 
    { 
        options.TokenValidationParameters = new TokenValidationParameters 
        { 
            ValidateIssuer = false, 
            ValidateAudience = false, 
            ValidateLifetime = true, 
            ValidateIssuerSigningKey = true, 
            //ValidIssuer = builder.Configuration["Jwt:Issuer"], 
            //ValidAudience = builder.Configuration["Jwt:Issuer"], 
            IssuerSigningKey = new 
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["=9v)th[2[xrw-&~IKl$oZbt7_1qV}c"]!)) 
        }; 
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Agregar el middleware de autenticacion
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
