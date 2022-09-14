using EventAPI.Core.Interfaces;
using EventAPI.Core.Services;
using EventAPI.Filters;
using EventAPI.Filters.ActionFilter;
using EventAPI.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => {
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

app.UseAuthorization();

app.MapControllers();

app.Run();
