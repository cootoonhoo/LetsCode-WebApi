using EventAPI.Core.Interfaces;
using EventAPI.Core.Services;
using EventAPI.Filters;
using EventAPI.Filters.ActionFilter;
using EventAPI.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var key = Encoding.ASCII.GetBytes(builder.Configuration["secretKey"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = "APIClientes.com",
            ValidateAudience = true,
            ValidAudience = "APIEvents.com"
        };
    })
    ;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options =>
{
    options.Filters.Add<ExceptionFilter>();
});

builder.Services.AddScoped<IReservationService, EventReservationService>();
builder.Services.AddScoped<IEventService, CityEventService>();
builder.Services.AddScoped<IReservationsRepository, EventReservationRepository>();
builder.Services.AddScoped<IEventRepository, CityEventRepository>();
builder.Services.AddScoped<AudienceVerifyActionFilter>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ITokenService, TokenService>();

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
