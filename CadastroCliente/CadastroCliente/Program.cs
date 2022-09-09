using CadastroCliente.Core.Interfaces;
using CadastroClientes.Infra.Data;
using CadastroCliente.Core.Services;
using CadastroCliente.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options =>
{
    options.Filters.Add<GeneralExcpetionFilter>();
});

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<GarantiaClienteExisteActionFilter>();
builder.Services.AddScoped<VerificandoCpfExisteActionFilter>();
builder.Services.AddScoped<IBenchmarkService, BenchMarkService>();

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
