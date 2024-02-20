using Microsoft.EntityFrameworkCore;

using UkukhulaAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using UkukhulaAPI.Data.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UkukhulaAPI.Services;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using UkukhulaAPI.Swagger;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
    };
});

builder.Services.AddAuthorization();


var connectionString = builder.Configuration.GetConnectionString("DBConnectionString");
builder.Services.AddDbContext<UkukhulaContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddTransient<UsersService>();

builder.Services.AddTransient<NewApplicationService>();
builder.Services.AddTransient<BbdadministratorService>();
builder.Services.AddTransient<LoginService>();


builder.Services.AddTransient<ApplicationService>();


builder.Services.AddTransient<UniversityApplicationService>();
builder.Services.AddTransient<HeadOfDepartmentService>();

builder.Services.AddTransient<StudentService>();


builder.Services.AddTransient<UniversityService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();