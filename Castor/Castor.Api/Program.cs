using Castor.Datos;
using Castor.Datos.Configuracion;
using Castor.Negocio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ConfiguracionConexion>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddScoped<IUsuariodatos, UsuarioDatos>();
builder.Services.AddScoped<IProductoDatos, ProductoDatos>();
builder.Services.AddScoped<IVentaDatos, VentaDatos>();
//builder.Services.AddScoped<IUsuarioNegocio, UsuarioNegocio>();


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
