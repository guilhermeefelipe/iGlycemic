using iGlycemic.Infrastructure.ServiceExtension;
using iGlycemic.Services;
using iGlycemic.Services.Interfaces;
using iGlycemic.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDIServices(builder.Configuration);
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = Encoding.ASCII.GetBytes(Settings.Secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
