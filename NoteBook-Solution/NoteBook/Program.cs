using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NoteBook.AccessData;
using NoteBook.BusinessLogic.Services;
using NoteBook.Common.Interfaces.AccessData;
using NoteBook.Common.Interfaces.DataAccess;
using NoteBook.Common.Interfaces.Services;
using NoteBook.Entity.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer( );
builder.Services.AddSwaggerGen(opions =>
{
    opions.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Prasome ivesti validu tokena",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    opions.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{ }
        }
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NoteBookDb")));

builder.Services.AddControllers( ).AddJsonOptions(opts =>
{
    var enumConverter = new JsonStringEnumConverter( );
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
});

builder.Services.AddScoped<IAccountsRepository, AccountsRepository>( );
builder.Services.AddScoped<IAuthService, AuthService>( );
builder.Services.AddScoped<IJwtService, JwtService>( );
// builder.Services.AddScoped<IDbContext, AppDbContext>( );

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters =
    new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,//butinas
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
    });

builder.Services.AddAuthorizationCore( );

var app = builder.Build( );

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment( ))
{
    app.UseSwagger( );
    app.UseSwaggerUI( );
}

app.UseHttpsRedirection( );
app.UseAuthentication( );
app.UseAuthorization( );

app.MapControllers( );

app.Run( );
