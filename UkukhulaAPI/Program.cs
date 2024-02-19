using Microsoft.EntityFrameworkCore;

using UkukhulaAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using UkukhulaAPI.Data.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;


using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var connectionString = builder.Configuration.GetConnectionString("DBConnectionString");
builder.Services.AddDbContext<UkukhulaContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddTransient<UsersService>();

builder.Services.AddTransient<NewApplicationService>();
builder.Services.AddTransient<BbdadministratorService>();



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