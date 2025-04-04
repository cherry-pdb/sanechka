using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TerminationSystem.Data;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TerminationService", Version = "v1" });
});

services.AddDbContext<TerminationDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "TerminationService v1"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();