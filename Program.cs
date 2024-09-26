using Microsoft.EntityFrameworkCore;
using Web_API.Data;
using Web_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura��o dos servi�os
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ILoginService, LoginService>(); // Registro do servi�o de login
builder.Services.AddDbContext<FilmeContext>(opts =>
    opts.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configura��o do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
